using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFileServer.Providers
{
    public class SecuredFileProvider : ISecuredFileProvider
    {
        List<string> _fileId;

        private readonly UseOnceAccessIdService _useOnceAccessIdService;

        public SecuredFileProvider(UseOnceAccessIdService _oneTimeTokenService)
        {
            _fileId = new List<string> { "securefile.txt", "securefileadmin.txt", "securefiletwo.txt" };
            _useOnceAccessIdService = _oneTimeTokenService;
        }
        public string AddFileIdForUseOnceAccessId(string filePath)
        {
            return _useOnceAccessIdService.AddFileIdForOnceAccessId(filePath);
        }

        public bool FileIdExists(string fileId)
        {
            if(_fileId.Contains(fileId.ToLower()))
            {
                return true;
            }
            return false;
        }

        public string GetFileIdForUseOnceAccessId(string oneTimeToken)
        {
            return _useOnceAccessIdService.GetFileIdForUseOnceAccesId(oneTimeToken);
        }

        public List<string> GetFilesForUser(bool isSecuredFileAdmin)
        {
            List<string> files = new List<string>();
            files.Add("SecureFile.txt");
            files.Add("SecureFileTwo");

            if (isSecuredFileAdmin)
            {
                files.Add("SecureFileAdmin.txt");
            }

            return files;
        }

        public bool HasUserClaimToAccessFile(string fileId, bool isSecuredFilesAdmin)
        {
            if ("SecureFileAdmin.txt" == fileId && !isSecuredFilesAdmin)
            {
                return false;
            }
            return false;
        }
    }
}
