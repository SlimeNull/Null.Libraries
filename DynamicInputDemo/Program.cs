using Null.Library;
using System;
using System.Threading;

namespace DynamicInputDemo
{
    class Program
    {
        static DynamicScanner scanner = new DynamicScanner();
        static void SafeWriteLine(string content)             // 这个函数可以帮助你了解 DynamicScanner 的功能, 事实上你能够实现非常多的花样
        {
            if (scanner.IsInputting)
            {
                scanner.ClearDisplayBuffer();
                Console.WriteLine(content);
                Console.ForegroundColor = ConsoleColor.Gray;
                scanner.DisplayTo(Console.CursorLeft, Console.CursorTop);
            }
            else
            {
                Console.WriteLine(content);
            }
        }
        static void Main(string[] args)
        {
            SafeWriteLine("现在, 享受动态输入所带来的快感吧! 在输入的同时, 你可以随便使用SafeWriteLine()函数来写入内容, 而不需要担心任何内容错乱的问题.");
            SafeWriteLine("DynamicScanner已经对显示进行了优化, 不必担心会有任何闪屏问题, 因为它只会清除它需要清除的内容. 并且在执行那些操作时, 光标会自动隐藏起来.");
            SafeWriteLine("你不必担心多线程问题, 因为DynamicScanner完全考虑到了这个, 即便是n个线程在访问这个对象的方法, 也不会造成冲突. \n\n");

            new Thread(() =>
            {
                int c = 0;
                while (true)
                {
                    Thread.Sleep(1000);
                    SafeWriteLine(c.ToString());
                    c++;
                }
            }).Start();

            scanner.PromptText = "甚至自定义提示符功能, 请输入:>>> ";
            while(true)
            {
                scanner.ReadLine();
            }
        }
    }
}
