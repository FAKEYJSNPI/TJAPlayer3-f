﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using FDK;

namespace TJAPlayer3
{
	internal class CActComboVoice : CActivity
	{
		// コンストラクタ

		public CActComboVoice()
		{
			base.b活性化してない = true;
		}
		
		// メソッド
		public void t再生( int nCombo, int player )
		{
			if(VoiceIndex[player] < ListCombo[player].Count)
			{
				
				var index = ListCombo[player][VoiceIndex[player]];
				if (nCombo == index.nCombo)
				{
					index.soundComboVoice.t再生を開始する();
					VoiceIndex[player]++;
				}
				
			}
		}

		/// <summary>
		/// カーソルを戻す。
		/// コンボが切れた時に使う。
		/// </summary>
		public void tReset(int nPlayer)
		{
			VoiceIndex[nPlayer] = 0;
		}

		// CActivity 実装

		public override void On活性化()
		{
			for (int i = 0; i < 2; i++)
			{
				ListCombo[i] = new List<CComboVoice>();
			}
			VoiceIndex = new int[] { 0, 0 };
			base.On活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if( !base.b活性化してない )
			{
				// フォルダ内を走査してコンボボイスをListに入れていく
				// 1P、2P コンボボイス
				for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
				{
					var currentDir = CSkin.Path(string.Format(@"Sounds/Combo_{0}P/", i + 1));
					if (Directory.Exists(currentDir))
					{
						foreach (var item in Directory.GetFiles(currentDir))
						{
							var comboVoice = new CComboVoice();
							comboVoice.bFileFound = true;
							comboVoice.nPlayer = i;
							comboVoice.strFilePath = item;
							comboVoice.soundComboVoice = TJAPlayer3.SoundManager.tCreateSound(item, ESoundGroup.Voice);
							if (TJAPlayer3.ConfigIni.nPlayerCount >= 2 && TJAPlayer3.ConfigIni.b2P演奏時のSEの左右) //2020.05.06 Mr-Ojii 左右に出したかったから追加。
							{
								if (i == 0)
									comboVoice.soundComboVoice.nPanning = -100;
								else
									comboVoice.soundComboVoice.nPanning = 100; 
							}
							comboVoice.nCombo = int.Parse(Path.GetFileNameWithoutExtension(item));
							ListCombo[i].Add(comboVoice);
						}
						if(ListCombo[i].Count > 0)
						{
							ListCombo[i].Sort();
						}
					}
				}
				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if( !base.b活性化してない )
			{
				for (int i = 0; i < 2; i++)
				{
					foreach (var item in ListCombo[i])
					{
						if (item.soundComboVoice != null)
						{
							item.soundComboVoice?.t解放する();
							item.soundComboVoice = null;
						}
					}
					ListCombo[i].Clear();
				}

				base.OnManagedリソースの解放();
			}
		}

		#region [ private ]
		//-----------------
		int[] VoiceIndex;
		readonly List<CComboVoice>[] ListCombo = new List<CComboVoice>[2];
		//-----------------
		#endregion
	}

	public class CComboVoice : IComparable<CComboVoice>
	{
		public bool bFileFound;
		public int nCombo;
		public int nPlayer;
		public string strFilePath;
		public CSound soundComboVoice;

		public CComboVoice()
		{
			bFileFound = false;
			nCombo = 0;
			nPlayer = 0;
			strFilePath = "";
			soundComboVoice = null;
		}

		public int CompareTo( CComboVoice other )
		{
			if( this.nCombo > other.nCombo ) return 1;
			else if( this.nCombo < other.nCombo ) return -1;

			return 0;
		}
	}
}
