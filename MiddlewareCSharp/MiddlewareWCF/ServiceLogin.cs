using ContractWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class ServiceLogin : IService
    {
        public Message ExecuteService(Message message)
        {
            return BusinessAccessLayer.Dispatch(message);
        }
    }
}
