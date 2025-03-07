﻿/*
* PROJECT:          Aura Operating System Development
* CONTENT:          Consoles
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;

namespace Aura_OS.System.AConsole
{

    [Plug(Target = typeof(Cosmos.System.Console))]
    public abstract class Console
    {
        internal const char LineFeed = '\n';
        internal const char CarriageReturn = '\r';
        internal const char Tab = '\t';
        internal const char Space = ' ';

        public Console()
        {

        }
        
        public bool writecommand = false;
        public int commandindex = -1;
        public string cmd;

        public string Name;

        public ConsoleType Type;

        public abstract int X { get; set; }
        public abstract int Y { get; set; }

        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract int Cols { get; }
        public abstract int Rows { get; }

        public abstract void Clear();

        public abstract void Clear(uint color);

        public abstract void Write(char[] aText);

        public abstract void Write(byte[] aText);

        public abstract void UpdateCursor();

        public abstract ConsoleColor Foreground { get; set; }

        public abstract ConsoleColor Background { get; set; }

        public abstract int CursorSize { get; set; }

        public abstract bool CursorVisible { get; set; }

        public abstract void DrawImage(ushort X, ushort Y, Bitmap image);
    }

    public enum ConsoleType
    {
        Text,
        Graphical
    }

    public static class ConsoleMode
    {
        public enum Mode800x600
        {
            Rows = 87,
            Cols = 37
        };

        public enum Mode1152x864
        {
            Rows = 127,
            Cols = 54
        };

        public enum Mode1280x768
        {
            Rows = 141,
            Cols = 48
        };
		
		public enum Mode1280x800
        {
            Rows = 141,
            Cols = 48
        };

        public enum Mode1360x768
        {
            Rows = 149, //+1?
            Cols = 48
        };

        public enum Mode1366x768
        {
            Rows = 150,
            Cols = 48
        };

        public enum Mode1600x1200
        {
            Rows = 176,
            Cols = 75
        };

        public enum Mode1920x1080
        {
            Rows = 141, // Not good value
            Cols = 48 // Not good value
        };

        public static string GetConsoleInfo()
        {
            if (Kernel.AConsole.Type == ConsoleType.Graphical)
            {
                return Kernel.AConsole.Name + " (" + Kernel.AConsole.Width + "x" + Kernel.AConsole.Height + " - " + global::System.Console.OutputEncoding.BodyName + ")";
            }
            else
            {
                return Kernel.AConsole.Name + " (" + global::System.Console.OutputEncoding.BodyName + ")";
            }
        }
    }
}
