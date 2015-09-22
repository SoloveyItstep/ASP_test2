﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextSelfHostKatana
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    class Program
    {

        static void Main(string[] args)
        {
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup1>("http://localhost:8080"))
            {
                Console.WriteLine("Сервер запущен. Нажмите любую клавишу для завершения работы...");

                Console.ReadLine();
            }
        }
    }
}
