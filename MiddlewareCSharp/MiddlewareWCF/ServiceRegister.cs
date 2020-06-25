using ContractWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class ServiceRegister : IService
    {
        /*
         * Input Data Layout :
         *      - data[0] : login (string)
         *      - data[1] : password (string)
         *      - data[2] : email (string)
         *      - data[3] : groups (List<string>)
         *
         * Output Data Layout :
         */
        public Message ExecuteService(Message message)
        {
            return BusinessAccessLayer.Dispatch(message);
        }
    }
}
