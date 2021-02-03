﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using FDK;

namespace TJAPlayer3
{
	public class CPad
	{
		// プロパティ

		internal STHIT stDetectedDevices;
		[StructLayout( LayoutKind.Sequential )]
		internal struct STHIT
		{
			public bool Keyboard;
			public bool MIDIIN;
			public bool Joypad;
			public bool Mouse;
			public void Clear()
			{
				this.Keyboard = false;
				this.MIDIIN = false;
				this.Joypad = false;
				this.Mouse = false;
			}
		}


		// コンストラクタ

		internal CPad( CConfigIni configIni, CInput管理 mgrInput )
		{
			this.rConfigIni = configIni;
			this.rInput管理 = mgrInput;
			this.stDetectedDevices.Clear();
		}


		// メソッド

		public List<STInputEvent> GetEvents( EPad pad )
		{
			CConfigIni.CKeyAssign.STKEYASSIGN[] stkeyassignArray = this.rConfigIni.KeyAssign[(int)pad];
			List<STInputEvent> list = new List<STInputEvent>();

			// すべての入力デバイスについて…
			foreach( IInputDevice device in this.rInput管理.list入力デバイス )
			{
				if( ( device.list入力イベント != null ) && ( device.list入力イベント.Count != 0 ) )
				{
					foreach( STInputEvent event2 in device.list入力イベント )
					{
						for( int i = 0; i < stkeyassignArray.Length; i++ )
						{
							switch( stkeyassignArray[ i ].入力デバイス )
							{
								case EInputDevice.KeyBoard:
									if( ( device.eInputDeviceType == EInputDeviceType.Keyboard ) && ( event2.nKey == stkeyassignArray[ i ].Code ) )
									{
										list.Add( event2 );
										this.stDetectedDevices.Keyboard = true;
									}
									break;

								case EInputDevice.MIDIInput:
									if( ( ( device.eInputDeviceType == EInputDeviceType.MidiIn ) && ( device.ID == stkeyassignArray[ i ].ID ) ) && ( event2.nKey == stkeyassignArray[ i ].Code ) )
									{
										list.Add( event2 );
										this.stDetectedDevices.MIDIIN = true;
									}
									break;

								case EInputDevice.Joypad:
									if( ( ( device.eInputDeviceType == EInputDeviceType.Joystick ) && ( device.ID == stkeyassignArray[ i ].ID ) ) && ( event2.nKey == stkeyassignArray[ i ].Code ) )
									{
										list.Add( event2 );
										this.stDetectedDevices.Joypad = true;
									}
									break;

								case EInputDevice.Mouse:
									if( ( device.eInputDeviceType == EInputDeviceType.Mouse ) && ( event2.nKey == stkeyassignArray[ i ].Code ) )
									{
										list.Add( event2 );
										this.stDetectedDevices.Mouse = true;
									}
									break;
							}
						}
					}
					continue;
				}
			}
			return list;
		}
		public bool b押された( EPad pad )
		{
			CConfigIni.CKeyAssign.STKEYASSIGN[] stkeyassignArray = this.rConfigIni.KeyAssign[(int)pad];
			for (int i = 0; i < stkeyassignArray.Length; i++)
			{
				switch (stkeyassignArray[i].入力デバイス)
				{
					case EInputDevice.KeyBoard:
						if (!this.rInput管理.Keyboard.bキーが押された(stkeyassignArray[i].Code))
							break;

						this.stDetectedDevices.Keyboard = true;
						return true;

					case EInputDevice.MIDIInput:
						{
							IInputDevice device2 = this.rInput管理.MidiIn(stkeyassignArray[i].ID);
							if ((device2 == null) || !device2.bキーが押された(stkeyassignArray[i].Code))
								break;

							this.stDetectedDevices.MIDIIN = true;
							return true;
						}
					case EInputDevice.Joypad:
						{
							if (!this.rConfigIni.dicJoystick.ContainsKey(stkeyassignArray[i].ID))
								break;

							IInputDevice device = this.rInput管理.Joystick(stkeyassignArray[i].ID);
							if ((device == null) || !device.bキーが押された(stkeyassignArray[i].Code))
								break;

							this.stDetectedDevices.Joypad = true;
							return true;
						}
					case EInputDevice.Mouse:
						if (!this.rInput管理.Mouse.bキーが押された(stkeyassignArray[i].Code))
							break;

						this.stDetectedDevices.Mouse = true;
						return true;
				}
			}
			
			return false;
		}
		public bool b押されている( EPad pad )
		{
			CConfigIni.CKeyAssign.STKEYASSIGN[] stkeyassignArray = this.rConfigIni.KeyAssign[(int)pad];
			for (int i = 0; i < stkeyassignArray.Length; i++)
			{
				switch (stkeyassignArray[i].入力デバイス)
				{
					case EInputDevice.KeyBoard:
						if (!this.rInput管理.Keyboard.bキーが押されている(stkeyassignArray[i].Code))
						{
							break;
						}
						this.stDetectedDevices.Keyboard = true;
						return true;

					case EInputDevice.Joypad:
						{
							if (!this.rConfigIni.dicJoystick.ContainsKey(stkeyassignArray[i].ID))
							{
								break;
							}
							IInputDevice device = this.rInput管理.Joystick(stkeyassignArray[i].ID);
							if ((device == null) || !device.bキーが押されている(stkeyassignArray[i].Code))
							{
								break;
							}
							this.stDetectedDevices.Joypad = true;
							return true;
						}
					case EInputDevice.Mouse:
						if (!this.rInput管理.Mouse.bキーが押されている(stkeyassignArray[i].Code))
						{
							break;
						}
						this.stDetectedDevices.Mouse = true;
						return true;
				}
			}
			return false;
		}


		// その他

		#region [ private ]
		//-----------------
		private CConfigIni rConfigIni;
		private CInput管理 rInput管理;
		//-----------------
		#endregion
	}
}
