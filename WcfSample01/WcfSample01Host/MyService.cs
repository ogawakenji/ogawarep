using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfSample01Client
{
    class MyService : IMyService
    {
        public string SayHello(string name)
        {
            Console.WriteLine("[CALL] MyService.SayHello()");
            return string.Format("Hello. '{0}'!", name);
        }
    }
}
