using ContractWCF;
using System;

namespace MiddlewareWCF
{
    public class ServiceEntryPoint : IServiceEntryPoint
    {
        public Message AccessService(Message message)
        {
            throw new NotImplementedException();
        }

        private bool CheckAppToken(string appToken)
        {
            throw new NotImplementedException();
        }

        private void DispatchToService(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
