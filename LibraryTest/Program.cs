using System;
using System.IO;
using Null.Library;

namespace LibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicScanner scanner = new DynamicScanner();
            scanner.PreviewCharInput += Scanner_PreviewCharInput;
            scanner.CharInput += Scanner_CharInput;
            while(true)
            {
                scanner.PromptText = ">>> ";
                string temp = scanner.ReadLine();
            }
        }

        private static bool Scanner_CharInput(DynamicScanner sender, ConsoleKeyInfo c)
        {
            Console.Title = $"Length: {sender.InputtingString.Length}, Inputed: {sender.InputtingString}";
            return false;
        }

        private static bool Scanner_PreviewCharInput(DynamicScanner sender, ConsoleKeyInfo c)
        {
            if (c.KeyChar >= '0' && c.KeyChar <= '9' || DynamicScanner.IsControlKey(c.Key))
            {
                return false;       // 表示不取消, 即:录入这个字符
            }
            else
            {
                switch (c.Key)       // 通过WSAD按键可以控制输入内容移动
                {
                    case ConsoleKey.W:
                        sender.SetInputStart(sender.StartLeft, sender.StartTop - 1);
                        break;
                    case ConsoleKey.S:
                        sender.SetInputStart(sender.StartLeft, sender.StartTop + 1);
                        break;
                    case ConsoleKey.A:
                        sender.SetInputStart(sender.StartLeft - 1, sender.StartTop);
                        break;
                    case ConsoleKey.D:
                        sender.SetInputStart(sender.StartLeft + 1, sender.StartTop);
                        break;
                }
                return true;
            }
        }
    }
}
