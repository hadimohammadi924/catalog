using IPE.SmsIrClient.Models.Requests;
using System;
using System.Threading.Tasks;

namespace catalog.Controllers
{
    internal class SmsIr
    {
        private string v;

        public SmsIr(string v)
        {
            this.v = v;
        }

        internal Task BulkSendAsync(long v, object text, string[] vs)
        {
            throw new NotImplementedException();
        }

        internal Task VerifySendAsync(string v1, int v2, VerifySendParameter[] verifySendParameters)
        {
            throw new NotImplementedException();
        }
    }
}