using ContractWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class ServiceLogout : IService
    {
        /*
         * Input Data Layout :
         *      - data[0] : login (string)
         *
         * Output Data Layout :
         */
        public Message ExecuteService(Message message)
        {
            return BusinessAccessLayer.Dispatch(message);
        }
    }
}
