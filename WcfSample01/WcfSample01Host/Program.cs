using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceModel;

// マルチスタートアッププロジェクトでホストとクライアントを同時に起動している
// よくわからない


namespace WcfSample01Client
{
    static class Program
    {

        private const string SERVICE_BASE_ADDRESS = @"http://localhost:8081/WCFSample001";
        private const string ENDPOINT_ADDRESS = "SayHello";


        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        static void Main()
        {

            using (ServiceHost host = CreateServiceHost())
            {

                string address = ENDPOINT_ADDRESS;

                BasicHttpBinding binding = new BasicHttpBinding();

                Type contract = typeof(IMyService);

                host.AddServiceEndpoint(contract, binding, address);

                host.Open();
                Console.WriteLine("サービスを開始しました。");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

                host.Close();

            }






        }

        private static ServiceHost CreateServiceHost()
        {

            Type serviceType = typeof(MyService);
            Uri baseAddress = new Uri(SERVICE_BASE_ADDRESS);

            return new ServiceHost(serviceType, baseAddress);

        }




    }
}
