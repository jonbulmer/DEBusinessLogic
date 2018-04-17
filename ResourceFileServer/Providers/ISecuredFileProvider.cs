using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFileServer.Providers
{
    public interface ISecuredFileProvider
    {
        bool FileIdExists(string id);

        bool HasUsedClaimToAccessFile(string fileId, bool isSecureFilesAdmin);

        List<string> GetFileIdForUser(bool isSecuredFileAdmin);
        string GetFileIdForUseOnceAccessId(string useOnceAccessId);
        string AddFileIdForUseOnceAccessId(string filePath);
    }
}
