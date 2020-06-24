using ContractWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class BusinessAccessLayer
    {
        public Message Dispatch(Message message)
        {
            throw new NotImplementedException();
        }

        private bool CheckAuthorisation(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
