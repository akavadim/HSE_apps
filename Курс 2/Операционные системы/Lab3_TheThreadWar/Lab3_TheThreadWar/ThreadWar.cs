using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab3_TheThreadWar
{

    class ThreadWar
    {
        private static object Gameover = new object();
        private static Semaphore BulletSemaphore = new Semaphore(3, 3);
        private static Thread MainThread;
        private static AutoResetEvent StartGame = new AutoResetEvent(false);

        private string badchars = "-\\|/";
        private int hits=0;
        private int miss=0;

        public ThreadWar()
        {

        }

        public void Badguy(object yobj)
        {
            int y = (int)yobj;
            int dir, x;
            // нечетные у появляются слева, четные у появляются справа
            x = y % 2 == 0 ? 0 : Console.BufferWidth-1;
            // установить направление в зависимости от начальной позиции
            dir = x != 0? -1 : 1;

            while ((dir == 1 && x != Console.BufferWidth) || (dir == -1 && x != 0))
            {
                bool hitme = false;

                ConsoleExtensions.WriteChar(x, y, badchars[x % 4]);

                for (int i = 0; i < 15; i++)
                {
                    Thread.Sleep(40);
                    if (ConsoleExtensions.GetAt((short)x, (short)y) == '*')
                    {
                        hitme = true;
                        break;
                    }
                }
                ConsoleExtensions.WriteChar(x, y, ' ');

                if (hitme)
                {
                    // в противника попали!
                    Console.Beep();
                    Interlocked.Increment(ref hits);
                    score();
                    return;
                }
                x += dir;
            }
            // противник убежал!
            Interlocked.Increment(ref miss);
            score();

        }

        void badguys()
        {
            Random random = new Random();


            // ждем сигнала к началу игры в течение 15 секунд
            StartGame.WaitOne(15000);
            // создаем случайного врага
            // каждые 5 секунд появляется шанс создать
            // противника с координатами от 1 до 10
            while (true)
            {
                if (random.Next(0, 100) < (hits + miss) / 25 + 20)
                    // со временем вероятность увеличивается
                    new Thread(new ParameterizedThreadStart(Badguy)).Start(random.Next(0, Console.BufferHeight));
                Thread.Sleep(1000); // каждую секунду
            }
        }

        // Это поток пули, каждая пуля - это отдельный поток
        public void bullet(object _xy_)
        {
            (int x, int y) xy = ((int, int))_xy_;
            if (ConsoleExtensions.GetAt((short)xy.x, (short)xy.y) == '*')
                return;                             // здесь уже есть пуля
                                                    // надо подождать 
                                                    // Проверить семафор
                                                    // если семафор равен 0, выстрела не происходит
            if (BulletSemaphore.WaitOne(0) == false)
                return;

            while (--xy.y!=0)
            {
                ConsoleExtensions.WriteChar(xy.x, xy.y, '*'); // отобразить пулю
                Thread.Sleep(100);
                ConsoleExtensions.WriteChar(xy.x,xy.y, ' ');    // стереть пулю
            }

            // выстрел сделан.- добавить 1 к семафору
            BulletSemaphore.Release();
        }

        void score()
        {
            Console.Title = $"Война потоков - Попаданий:{hits}, Промахов:{miss}";
            if (miss >= 30)
            {
                System.Threading.Monitor.Enter(Gameover);
                MainThread.Suspend();
                MessageBox.Show("Игра окончена", "Thread War");
                Environment.Exit(0);
            }
        }

        public void Start()
        {
            int x, y;
            
            Console.BufferHeight = 25;
            x = Console.BufferWidth / 2;
            y = Console.BufferHeight - 1;
            MainThread = Thread.CurrentThread;

            score();

            new Thread(new ThreadStart(badguys)).Start();

            while (true)
            {

                ConsoleExtensions.WriteChar((short)x, (short)y, '|');
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Spacebar:
                        (int, int) xy = (x, y);
                        new Thread(new ParameterizedThreadStart(bullet)).Start(xy);
                        Thread.Sleep(100);
                        break;
                    case ConsoleKey.LeftArrow:
                        StartGame.Set();
                        ConsoleExtensions.WriteChar(x, y, ' ');
                        if (x != 0)
                            x--;
                        break;
                    case ConsoleKey.RightArrow:
                        StartGame.Set();
                        ConsoleExtensions.WriteChar(x, y, ' ');
                        if(x!=Console.BufferWidth-1)
                            x++;
                        break;
                }
            }
        }
    }
}
