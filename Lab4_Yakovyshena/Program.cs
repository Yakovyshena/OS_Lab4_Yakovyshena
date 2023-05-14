using System;
using System.Threading;

namespace Lab4_Yakovyshena
{
    public class Program
    {
        static object locker = new object();

        static Fork fork1 = new Fork();
        static Fork fork2 = new Fork();
        static Fork fork3 = new Fork();
        static Fork fork4 = new Fork();
        static Fork fork5 = new Fork();

        static void Main(string[] args)
        {
            Philosopher Aristotel = new Philosopher("1", fork1, fork5);
            Philosopher Socrat = new Philosopher("2", fork2, fork1);
            Philosopher Platon = new Philosopher("3", fork3, fork2);
            Philosopher Confucius = new Philosopher("4", fork4, fork3);
            Philosopher Diogen = new Philosopher("5", fork5, fork4);


            Thread thread1 = new Thread(new ParameterizedThreadStart(Phil));
            Thread thread2 = new Thread(new ParameterizedThreadStart(Phil));
            Thread thread3 = new Thread(new ParameterizedThreadStart(Phil));
            Thread thread4 = new Thread(new ParameterizedThreadStart(Phil));
            Thread thread5 = new Thread(new ParameterizedThreadStart(Phil));

            thread1.Start(Aristotel);
            thread2.Start(Socrat);
            thread3.Start(Platon);
            thread4.Start(Confucius);
            thread5.Start(Diogen);

        }
        static public void Phil(object philosoph)
        {
            Philosopher phil = (Philosopher)philosoph;
            Random rand = new Random();
            while (!Console.KeyAvailable)
            {
                if (!phil.right.Istaken)
                {
                    lock (locker)
                        phil.right.Istaken = true;

                    if (!phil.left.Istaken)
                    {
                        lock (locker)
                            phil.left.Istaken = true;
                        //.Sleep(rand.Next(500, 1000));
                        phil.eat();
                        //зависнути, щоб поїсти 1-5
                        Thread.Sleep(rand.Next(1000, 5000));

                        phil.put_right();
                        phil.put_left();

                        phil.think();

                        //зависнути, щоб подумати 10-15
                        Thread.Sleep(rand.Next(10000, 15000));
                    }
                    else
                    {
                        phil.put_right();
                        phil.think();
                        //зависнути, щоб подумати 7-10
                        Thread.Sleep(rand.Next(7000, 10000));
                    }
                }

            }
            Environment.Exit(0);

        }
    }
}

