using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Lab3_TheThreadWar
{
    public static class ConsoleExtensions
    {
        [DllImport("Kernel32", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("Kernel32", SetLastError = true)]
        private static extern bool ReadConsoleOutputCharacter(IntPtr hConsoleOutput,
            [Out] StringBuilder lpCharacter, uint nLength, COORD dwReadCoord,
            out uint lpNumberOfCharsRead);

        [DllImport("kernel32.dll")]
        static extern bool WriteConsoleOutputCharacter(IntPtr hConsoleOutput,
            string lpCharacter, uint nLength, COORD dwWriteCoord,
            out uint lpNumberOfCharsWritten);

        //[DllImport("kernel32.dll", EntryPoint = "ReadConsoleInputW", CharSet = CharSet.Unicode)]
        //static extern bool ReadConsoleInput(
        //IntPtr hConsoleInput,
        //[Out] INPUT_RECORD[] lpBuffer,
        //uint nLength,
        //out uint lpNumberOfEventsRead);

        private const int STD_OUTPUT_HANDLE = -11;

        private static System.Threading.Mutex screenlock= new System.Threading.Mutex();

        public static void WriteChar(int x, int y, char c)
        {
            IntPtr intPtr = GetStdHandle(STD_OUTPUT_HANDLE);
            COORD coord = new COORD()
            {
                X = (short)x,
                Y = (short)y
            };
            uint numberOfCharRead;

            screenlock.WaitOne();
            WriteConsoleOutputCharacter(intPtr, c.ToString(), 1, coord, out numberOfCharRead);
            screenlock.ReleaseMutex();
        }

        public static char GetAt(short x, short y)
        {
            IntPtr intPtr = GetStdHandle(STD_OUTPUT_HANDLE);
            StringBuilder stringBuilder = new StringBuilder();
            COORD coord = new COORD()
            {
                X = x,
                Y = y
            };
            uint numberOfCharRead;

            screenlock.WaitOne();
            ReadConsoleOutputCharacter(intPtr, stringBuilder, 1, coord, out numberOfCharRead);
            screenlock.ReleaseMutex();

            return stringBuilder[0];
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct COORD
        {
            public short X;
            public short Y;
        }

        //[StructLayout(LayoutKind.Explicit)]
        //public struct INPUT_RECORD
        //{
        //    [FieldOffset(0)]
        //    public ushort EventType;
        //    [FieldOffset(4)]
        //    public KEY_EVENT_RECORD KeyEvent;
        //    [FieldOffset(4)]
        //    public MOUSE_EVENT_RECORD MouseEvent;
        //    [FieldOffset(4)]
        //    public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;
        //    [FieldOffset(4)]
        //    public MENU_EVENT_RECORD MenuEvent;
        //    [FieldOffset(4)]
        //    public FOCUS_EVENT_RECORD FocusEvent;
        //};

        //[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        //public struct KEY_EVENT_RECORD
        //{
        //    [FieldOffset(0), MarshalAs(UnmanagedType.Bool)]
        //    public bool bKeyDown;
        //    [FieldOffset(4), MarshalAs(UnmanagedType.U2)]
        //    public ushort wRepeatCount;
        //    [FieldOffset(6), MarshalAs(UnmanagedType.U2)]
        //    public ushort wVirtualKeyCode;
        //    [FieldOffset(8), MarshalAs(UnmanagedType.U2)]
        //    public ushort wVirtualScanCode;
        //    [FieldOffset(10)]
        //    public char UnicodeChar;
        //    [FieldOffset(12), MarshalAs(UnmanagedType.U4)]
        //    public ControlKeyState dwControlKeyState;
        //}
        //public enum ControlKeyState
        //{

        //    // /* dwControlKeyState bitmask */
        //    RIGHT_ALT_PRESSED = 1,

        //    LEFT_ALT_PRESSED = 2,

        //    RIGHT_CTRL_PRESSED = 4,

        //    LEFT_CTRL_PRESSED = 8,

        //    SHIFT_PRESSED = 16,

        //    NUMLOCK_ON = 32,

        //    SCROLLLOCK_ON = 64,

        //    CAPSLOCK_ON = 128,

        //    ENHANCED_KEY = 256,
        //}
    }
}
