using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleGameEngine
{
    public static class KeyboardManager
    {
        private static int GetKeyState()
        {
            byte[] keys = new byte[256];

            for (int i = 0; i < 256; i++)
            {
                byte key = keys[i];

                if ((key & 0x80) != 0)
                {
                    return key;
                }
            }
            return -1;
        }

        [DllImport("user32.dll")]
        static extern short GetKeyState(Keys nVirtKey);

        public static bool IsKeyPressed(Keys testKey)
        {
            bool keyPressed = false;
            short result = GetKeyState(testKey);

            switch (result)
            {
                case 0:
                    keyPressed = false;
                    break;

                case 1:
                    keyPressed = false;
                    break;

                default:
                    keyPressed = true;
                    break;
            }

            return keyPressed;
        }

    }
}
