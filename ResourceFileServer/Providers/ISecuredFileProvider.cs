using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFileServer.Providers
{
    public interface ISecuredFileProvider
    {
        bool FileIdExists(string id);

        bool HasUserClaimToAccessFile(string fileId, bool isSecureFilesAdmin);

        List<string> GetFileIdForUser(bool isSecuredFileAdmin);
        string GetFileIdForUseOnceAccessId(string oneTimeToken);
        string AddFileIdForUseOnceAccessId(string filePath);
    }
}
