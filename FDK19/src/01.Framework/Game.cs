﻿using System;
using System.ComponentModel;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
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
                return new Device();
            }
        }

        internal static Game Instance = null;

        public Game()
            : base(GameWindowSize.Width, GameWindowSize.Height, GraphicsMode.Default, "TJAP3-f(OpenGL)Alpha")
        {
            Instance = this;
            string osplatform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "win" : (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "osx" : "linux");
            string platform = Environment.Is64BitProcess ? "x64" : "x86";

            FFmpeg.AutoGen.ffmpeg.RootPath = AppContext.BaseDirectory + @"ffmpeg/" + osplatform + "-" + platform + "/";

            DirectoryInfo info = new DirectoryInfo(AppContext.BaseDirectory + @"dll/" + osplatform + "-" + platform + "/");

            //exeの階層にdllをコピー
            foreach (FileInfo fileinfo in info.GetFiles())
            {
                fileinfo.CopyTo(AppContext.BaseDirectory + fileinfo.Name, true);
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//CP932用
        }
    }
}
