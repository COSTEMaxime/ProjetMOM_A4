using ContractWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class ServiceJEEResponse : IService
    {
        /*
         * Input Data Layout :
         *      - data[0] : documentName (string)
         *      - data[1] : key (string)
         *      - data[2] : guuid (string)
         *      - data[3] : secret (string)
         *      - data[4] : confidence (float)
         *
         * Output Data Layout :
         */
        public Message ExecuteService(Message message)
        {
            return BusinessAccessLayer.Dispatch(message);
        }
    }
}
