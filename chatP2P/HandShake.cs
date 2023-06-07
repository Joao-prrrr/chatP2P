using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatP2P
{
    class HandShake
    {

        public string ip;
        public byte[] nonce;
        public byte[] key;
        public bool ok_code;

        public HandShake(string ip, byte[] nonce, byte[] key, bool ok)
        {
            this.ip = ip;
            this.nonce = nonce;
            this.key = key;
            this.ok_code = ok_code;
        }

        
    }
}
