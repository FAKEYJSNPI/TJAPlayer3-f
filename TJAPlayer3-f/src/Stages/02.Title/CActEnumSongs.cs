﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Globalization;
using FDK;

namespace TJAPlayer3
{
	internal class CActEnumSongs :  CActivity
	{
		public bool bコマンドでの曲データ取得;


		/// <summary>
		/// Constructor
		/// </summary>
		public CActEnumSongs()
		{
			Init( false );
		}

		public CActEnumSongs( bool _bコマンドでの曲データ取得 )
		{
			Init( _bコマンドでの曲データ取得 );
		}
		private void Init( bool _bコマンドでの曲データ取得 )
		{
			base.b活性化してない = true;
			bコマンドでの曲データ取得 = _bコマンドでの曲データ取得;
		}

		// CActivity 実装

		public override void On活性化()
		{
			if ( this.b活性化してる )
				return;
			base.On活性化();

			try
			{
				this.ctNowEnumeratingSongs = new CCounter();	// 0, 1000, 17, CDTXMania.Timer );
				this.ctNowEnumeratingSongs.t開始( 0, 100, 17, TJAPlayer3.Timer );
			}
			finally
			{
			}
		}
		public override void On非活性化()
		{
			if ( this.b活性化してない )
				return;
			base.On非活性化();
			this.ctNowEnumeratingSongs = null;
		}
		public override void OnManagedリソースの作成()
		{
			if ( this.b活性化してない )
				return;

			try
			{
				string[] strMessage = 
				{
					"     曲データの一覧を\n       取得しています。\n   しばらくお待ちください。",
					" Now enumerating songs.\n         Please wait..."
				};
				int ci = ( CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ja" ) ? 0 : 1;
				if ( ( strMessage != null ) && ( strMessage.Length > 0 ) )
				{
					using (CFontRenderer pffont = new CFontRenderer(CFontRenderer.DefaultFontName, 32, SixLabors.Fonts.FontStyle.Bold))
					{
						this.txMessage = TJAPlayer3.tCreateTexture(pffont.DrawText(strMessage[ci], Color.White), true);
						this.txMessage.vcScaling = new System.Numerics.Vector3(0.5f, 0.5f, 1f);
					}
				}
				else
				{
					this.txMessage = null;
				}
			}
			catch ( CTextureCreateFailedException e )
			{
				Trace.TraceError( "テクスチャの生成に失敗しました。(txMessage)" );
				Trace.TraceError( e.ToString() );
				Trace.TraceError( "An exception has occurred, but processing continues." );
				this.txMessage = null;
			}
	
			base.OnManagedリソースの作成();
		}
		public override void OnManagedリソースの解放()
		{
			if ( this.b活性化してない )
				return;

			TJAPlayer3.t安全にDisposeする( ref this.txMessage );
			base.OnManagedリソースの解放();
		}

		public override int On進行描画()
		{
			if ( this.b活性化してない )
			{
				return 0;
			}
			this.ctNowEnumeratingSongs.t進行Loop();
			if ( TJAPlayer3.Tx.Enum_Song != null )
			{
				TJAPlayer3.Tx.Enum_Song.Opacity = (int) ( 176.0 + 80.0 * Math.Sin( (double) (2 * Math.PI * this.ctNowEnumeratingSongs.n現在の値 * 2 / 100.0 ) ) );
				TJAPlayer3.Tx.Enum_Song.t2D描画( TJAPlayer3.app.Device, 18, 7 );
			}
			if ( bコマンドでの曲データ取得 && TJAPlayer3.Tx.Config_Enum_Song != null )
			{
				TJAPlayer3.Tx.Config_Enum_Song.t2D描画( TJAPlayer3.app.Device, 180, 177 );
				this.txMessage.t2D描画( TJAPlayer3.app.Device, 190, 197 );
			}

			return 0;
		}


		private CCounter ctNowEnumeratingSongs;
		private CTexture txMessage;
	}
}
