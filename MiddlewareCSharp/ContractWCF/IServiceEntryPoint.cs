using System;
using System.Collections.Generic;
using System.Text;

namespace ContractWCF
{
    [System.ServiceModel.ServiceContract]
    public interface IServiceEntryPoint
    {
        [System.ServiceModel.OperationContract]
        Message AccessService(Message message);
    }
}
