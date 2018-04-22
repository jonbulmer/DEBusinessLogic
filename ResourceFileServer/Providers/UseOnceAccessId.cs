using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFileServer.Providers
{
    internal class UseOnceAccessId
    {
        public UseOnceAccessId(string fileId)
        {
            Created = DateTime.UtcNow;
            AccessId = CreatedAccessId();
            FileId = fileId;
        }

        public DateTime Created { get; }

        public string AccessId { get; }

        public string FileId { get; }

        public string CreatedAccessId ()
        {
            SecureRandom secureRandom = new SecureRandom();
            return secureRandom.Next() + Guid.NewGuid().ToString();
        }
    }
}
