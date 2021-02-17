﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using OpenTK;
using OpenTK.Audio.OpenAL;

namespace FDK
{
	internal class CSoundDeviceOpenAL : ISoundDevice
	{
		// プロパティ

		public ESoundDeviceType eOutputDevice
		{
			get;
			protected set;
		}
		public long nOutPutDelayms
		{
			get;
			protected set;
		}
		public long nBufferSizems
		{
			get;
			protected set;
		}

		// CSoundTimer 用に公開しているプロパティ

		public long nElapsedTimems
		{
			get
			{
				if ( ctimer != null )
				{
					AL.GetSource(this.sd経過時間計測用サウンドバッファ.SourceOpen[0], ALSourcef.SecOffset, out float sec);
					int n現在位置 = (int)(sec * 1000);
					long n現在のシステム時刻ms = this.tmSystemTimer.nシステム時刻ms;


					// ループ回数を調整。

					long nシステム時刻での間隔ms = n現在のシステム時刻ms - this.n前に経過時間を測定したシステム時刻ms;

					while ( nシステム時刻での間隔ms >= n単位繰り上げ間隔ms )		// 前回から単位繰り上げ間隔以上経過してるなら確実にループしている。誤差は大きくないだろうから無視。
					{
						this.nループ回数++;
						nシステム時刻での間隔ms -= n単位繰り上げ間隔ms;
					}

					if ( n現在位置 < this.n前回の位置 )							// 単位繰り上げ間隔以内であっても、現在位置が前回より手前にあるなら1回ループしている。
						this.nループ回数++;


					// 経過時間を算出。

					long nElapsedTimems = (long) ( ( this.nループ回数 * n単位繰り上げ間隔ms ) + ( n現在位置 * 1000.0 / ( 44100.0 * 2 * 2 ) ) );


					// 今回の値を次回に向けて保存。

					this.n前に経過時間を測定したシステム時刻ms = n現在のシステム時刻ms;
					this.n前回の位置 = n現在位置;

					return nElapsedTimems;
				}
				else
				{
					long nRet = ctimer.nシステム時刻ms - this.n前に経過時間を測定したシステム時刻ms;
					if ( nRet < 0 )	// カウンタがループしたときは
					{
						nRet = ( ctimer.nシステム時刻ms - long.MinValue ) + ( long.MaxValue - this.n前に経過時間を測定したシステム時刻ms ) + 1;
					}
					this.n前に経過時間を測定したシステム時刻ms = ctimer.nシステム時刻ms;
	
					return nRet;
				}
			}
		}
		public long SystemTimemsWhenUpdatingElapsedTime 
		{
			get { throw new NotImplementedException(); }
		}
		public CTimer tmSystemTimer
		{
			get;
			protected set;
		}

		public int nMasterVolume
		{
			get
			{
				AL.GetListener(ALListenerf.Gain, out float Volume);
				return (int)(Volume * 100f);
			}
			set
			{
				AL.Listener(ALListenerf.Gain, (float)(value / 100f));
			}
		}


		// メソッド

		public unsafe CSoundDeviceOpenAL( IntPtr hWnd, long n遅延時間ms, bool bUseOSTimer )
		{
			Trace.TraceInformation( "OpenAL の初期化を開始します。" );

			this.eOutputDevice = ESoundDeviceType.Unknown;
			this.nBufferSizems = this.nOutPutDelayms = n遅延時間ms;
			this.tmSystemTimer = new CTimer();

			#region[ OpenAL サウンドデバイスの作成]

			//Initialize
			this.device = Alc.OpenDevice(null);
			this.context = Alc.CreateContext(this.device, (int*)null);
			Alc.MakeContextCurrent(this.context);

			//Versionの確認
			var version = AL.Get(ALGetString.Version);
			var vendor = AL.Get(ALGetString.Vendor);
			var renderer = AL.Get(ALGetString.Renderer);
			Console.WriteLine("OpenAL Version=" + version);
			Console.WriteLine("OpenAL Vendor=" + vendor);
			Console.WriteLine("OpenAL Renderer=" + renderer);

			// デバイス作成完了。
			this.eOutputDevice = ESoundDeviceType.OpenAL;
			#endregion

			if ( !bUseOSTimer )
			{
				#region [ 経過時間計測用サウンドバッファを作成し、ループ再生を開始する。]
				//-----------------

				// 単位繰り上げ間隔[秒]の長さを持つ無音のサウンドを作成。

				uint nデータサイズbyte = n単位繰り上げ間隔sec * 44100 * 2 * 2;
				var ms = new MemoryStream();
				var bw = new BinaryWriter( ms );
				bw.Write( (uint) 0x46464952 );						// 'RIFF'
				bw.Write( (uint) ( 44 + nデータサイズbyte - 8 ) );	// ファイルサイズ - 8
				bw.Write( (uint) 0x45564157 );						// 'WAVE'
				bw.Write( (uint) 0x20746d66 );						// 'fmt '
				bw.Write( (uint) 16 );								// バイト数
				bw.Write( (ushort) 1 );								// フォーマットID(リニアPCM)
				bw.Write( (ushort) 2 );								// チャンネル数
				bw.Write( (uint) 44100 );							// サンプリング周波数
				bw.Write( (uint) ( 44100 * 2 * 2 ) );				// bytes/sec
				bw.Write( (ushort) ( 2 * 2 ) );						// blockサイズ
				bw.Write( (ushort) 16 );							// bit/sample
				bw.Write( (uint) 0x61746164 );						// 'data'
				bw.Write( (uint) nデータサイズbyte );				// データ長
				for ( int i = 0; i < nデータサイズbyte / sizeof( long ); i++ )	// PCMデータ
					bw.Write( (long) 0 );
				var byArrWaveFleImage = ms.ToArray();
				bw.Close();
				ms = null;
				bw = null;
				this.sd経過時間計測用サウンドバッファ = this.tCreateSound( byArrWaveFleImage, ESoundGroup.Unknown );

				CSound.listインスタンス.Remove( this.sd経過時間計測用サウンドバッファ );	// 特殊用途なのでインスタンスリストからは除外する。

				// サウンドのループ再生開始。

				this.nループ回数 = 0;
				this.n前回の位置 = 0;
				AL.Source(this.sd経過時間計測用サウンドバッファ.SourceOpen[0], ALSourceb.Looping, true);
				AL.SourcePlay(this.sd経過時間計測用サウンドバッファ.SourceOpen[0]);
				this.n前に経過時間を測定したシステム時刻ms = this.tmSystemTimer.nシステム時刻ms;
				//-----------------
				#endregion
			}
			else
			{
				ctimer = new CTimer();
			}
			Trace.TraceInformation( "OpenAL を初期化しました。({0})", bUseOSTimer? "OStimer" : "FDKtimer" );
		}

		public CSound tCreateSound( string strファイル名, ESoundGroup soundGroup )
		{
			var sound = new CSound(soundGroup);
			sound.tOpenALサウンドを作成する(strファイル名);
			return sound;
		}

		private CSound tCreateSound( byte[] byArrWAVファイルイメージ, ESoundGroup soundGroup )
		{
			var sound = new CSound(soundGroup);
			sound.tOpenALサウンドを作成する(byArrWAVファイルイメージ);
			return sound;
		}

		// 既存のインスタンス（生成直後 or Dispose済み）に対してサウンドを生成する。
		public void tCreateSound( string strファイル名, CSound sound )
		{
			sound.tOpenALサウンドを作成する(strファイル名);
		}
		public void tCreateSound( byte[] byArrWAVファイルイメージ, CSound sound )
		{
			sound.tOpenALサウンドを作成する(byArrWAVファイルイメージ);
		}

		#region [ Dispose-Finallizeパターン実装 ]
		//-----------------
		public void Dispose()
		{
			this.Dispose( true );
			GC.SuppressFinalize( this );
		}
		protected void Dispose( bool bManagedDispose )
		{
			this.eOutputDevice = ESoundDeviceType.Unknown;		// まず出力停止する(Dispose中にクラス内にアクセスされることを防ぐ)
			if ( bManagedDispose )
			{
				#region [ 経緯時間計測用サウンドバッファを解放。]
				//-----------------
				if ( this.sd経過時間計測用サウンドバッファ != null )
				{
					this.sd経過時間計測用サウンドバッファ.tサウンドを停止する();
					C共通.tDisposeする( ref this.sd経過時間計測用サウンドバッファ );
				}
				//-----------------
				#endregion

				C共通.tDisposeする( this.tmSystemTimer );
			}
			if ( ctimer != null )
			{
				C共通.tDisposeする( ref this.ctimer );
			}
			//使わなくなったデータをクリーンアップ
			Alc.MakeContextCurrent(ContextHandle.Zero);
			Alc.DestroyContext(this.context);
			Alc.CloseDevice(this.device);
		}
		~CSoundDeviceOpenAL()
		{
			this.Dispose( false );
		}
		//-----------------
		#endregion

		protected CSound sd経過時間計測用サウンドバッファ = null;
//		protected AutoResetEvent autoResetEvent = new AutoResetEvent( false );
		protected const uint n単位繰り上げ間隔sec = 1;	// [秒]
		protected const uint n単位繰り上げ間隔ms = n単位繰り上げ間隔sec * 1000;	// [ミリ秒]
		protected int nループ回数 = 0;

		private long n前に経過時間を測定したシステム時刻ms = CTimer.nUnused;
		private int n前回の位置 = 0;

		private CTimer ctimer = null;

		//OpenTK
		IntPtr device;
		ContextHandle context;
	}
}