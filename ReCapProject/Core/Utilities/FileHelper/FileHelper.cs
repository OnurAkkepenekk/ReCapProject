using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        // C:\\ ... \Images path'ini olusturuyor
        static string path = Environment.CurrentDirectory + @"\wwwroot\Images";

        public static IDataResult<string> Add(IFormFile file)
        {
            var result = newFilePath(file);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    File.Move(sourcePath, result);
                    return new SuccessDataResult<string>(result, "Dosya eklendi.");
                }
                else
                {
                    return new ErrorDataResult<string>("Dosya eklenemedi.");
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>(ex.Message);
            }
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static IDataResult<string> Update(IFormFile file, string oldFilePath)
        {
            try
            {
                if (File.Exists(oldFilePath))
                {
                    FileHelper.Delete(oldFilePath);
                    var result = newFilePath(file);

                    var sourcePath = Path.GetTempFileName();

                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    File.Move(sourcePath, result);
                    return new SuccessDataResult<string>(result, "Dosya eklendi.");
                }
                else
                {
                    return new ErrorDataResult<string>("Dosya Bulunamadı.");
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<string>(exception.Message);
            }
        }
        private static string newFilePath(IFormFile file)
        {
            //GUID li dosya ismini oluşturur
            var newGuidPath = Guid.NewGuid().ToString("N") + Path.GetExtension(path + file.FileName);
            string result = $@"{path}\{newGuidPath}";
            return result;
        }
    }
}
