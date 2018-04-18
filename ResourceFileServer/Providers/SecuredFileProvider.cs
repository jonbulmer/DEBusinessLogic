using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFileServer.Providers
{
    public class SecuredFileProvider : ISecuredFileProvider
    {
        public string AddFileIdForUseOnceAccessId(string filePath)
        {
            throw new NotImplementedException();
        }

        public bool FileIdExists(string id)
        {
            throw new NotImplementedException();
        }

        public string GetFileIdForUseOnceAccessId(string useOnceAccessId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFileIdForUser(bool isSecuredFileAdmin)
        {
            throw new NotImplementedException();
        }

        public bool HasUsedClaimToAccessFile(string fileId, bool isSecureFilesAdmin)
        {
            throw new NotImplementedException();
        }

        public bool HasUserClaimToAccessFile(string fileId, bool isSecuredFilesAdmin)
        {
            return false;
        }
    }
}
