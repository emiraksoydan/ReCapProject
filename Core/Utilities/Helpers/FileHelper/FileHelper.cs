using Core.Utilities.Helpers.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public void Delete(string filepath)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        public string Update(IFormFile file, string filepath, string root)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile formFile, string root)
        {
            if(formFile.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extention = Path.GetExtension(formFile.FileName);
                string guid = GuidHelperManager.CreateGuid();
                string filepath = guid + extention;

                using (FileStream fileStream = File.Create(root + filepath))
                {
                    formFile.CopyTo(fileStream);
                    fileStream.Flush();
                    return filepath;
                }
            }
            return null;
        }
    }
}
