using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfSample01Client
{
    [ServiceContract(Namespace = "http://Sample.WCF")]
    interface IMyService
    {

        [OperationContract]
        string SayHello(string name);


    }
}
