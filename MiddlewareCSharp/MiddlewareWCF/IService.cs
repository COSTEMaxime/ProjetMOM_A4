using ContractWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    interface IService
    {
        Message ExecuteService(Message message);
    }
}
