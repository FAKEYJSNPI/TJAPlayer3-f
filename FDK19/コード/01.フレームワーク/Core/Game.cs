﻿using System;
using System.ComponentModel;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Text;
using OpenTK;
using OpenTK.Graphics;

namespace FDK
{
	/// <summary>
	/// Presents an easy to use wrapper for making games and samples.
	/// </summary>
	public abstract class Game : GameWindow
	{
		/// <summary>
		/// 2020/10/09 Mr-Ojii 勝手に追加
		/// TJAPlayer3.app.DeviceをGame側で実装してしまえ！という試み
		/// </summary>
		public Device Device
		{
			get
			{
				return new Device() { Num = 0 };
			}
		}

		public Game()
			: base(GameWindowSize.Width, GameWindowSize.Height, GraphicsMode.Default, "TJAP3-f(OpenGL)Alpha")
		{
			if (Environment.Is64BitProcess)
			{
				FFmpeg.AutoGen.ffmpeg.RootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"/ffmpeg/x64/";
			}
			else
			{
				FFmpeg.AutoGen.ffmpeg.RootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"/ffmpeg/x86/";
			}

			if (!Directory.Exists(FFmpeg.AutoGen.ffmpeg.RootPath))
				throw new DirectoryNotFoundException("FFmpeg RootPath Not Found.\nPath=" + FFmpeg.AutoGen.ffmpeg.RootPath);
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//CP932用
		}
	}
}
