using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Lab3_ThreadWar
{
    class ThreadWar
    {
        [DllImport("Kernel32", SetLastError = true)]
        static extern IntPtr GetStdHandle(uint nStdHandle);

        [DllImport("Kernel32", SetLastError = true)]
        static extern bool ReadConsoleOutputCharacter(IntPtr hConsoleOutput,
            [Out] StringBuilder lpCharacter, uint nLength, COORD dwReadCoord,
            out uint lpNumberOfCharsRead);

        [StructLayout(LayoutKind.Sequential)]
        struct COORD
        {
            public short X;
            public short Y;
        }


        private object screenlock = new object();

        private async void WriteChar(int x, int y, char c)
        {
            lock (screenlock)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(c);
            }
        }

        private char GetAt(int x, int y)
        {
            lock (screenlock)
            {
                Console.SetCursorPosition(x, y);
                ReadConsoleOutputCharacter(System.Console.han)
            }
        }

        public void Start()
        {

        }
    }
}
