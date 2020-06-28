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
        /*
         * Input Data Layout :
         *      - data[0] : login (string)
         *      - data[1] : password (string)
         *
         * Output Data Layout :
         *      - data[0] : userToken (string)
         */
        public Message ExecuteService(Message message)
        {
            return BusinessAccessLayer.Dispatch(message);
        }
    }
}
