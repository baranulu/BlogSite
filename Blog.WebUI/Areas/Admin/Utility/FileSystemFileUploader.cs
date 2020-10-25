using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Areas.Admin.Utility
{
    public class FileSystemFileUploader : IFileUpload
    {

        private readonly string _filePath;

        public FileSystemFileUploader()
        {
            this._filePath = "images";
        }
        public FileSystemFileUploader(string filePath)
        {
            this._filePath = filePath;
        }
        public FileUploadResult Upload(IFormFile file)
        {
            FileUploadResult result = new FileUploadResult();
            result.FileResult = FileResult.Error;
            result.Message = "yükleme esnasında hata meydana geldi";

            if (file.Length > 0)
            {
                var fileName = $"<{Guid.NewGuid()}{Path.GetExtension(file.FileName)}"; //getextension methotu dosyanın uzantısını alır. png,jpg gibi
                result.OriginalName = file.FileName;
                var pyschalPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/admin/{_filePath}.", fileName); //projenini bağlı bulundu klasörü veriyor. daha sonra içeride bulunan wwwroot klasörüne pathte gönderilen filename isimli dosyayı birleştirir


                if (File.Exists(pyschalPath)) //belirtilen konumda verilen pyschalPath ile aynı isimde dosya varsa true yoksa dönmeyecektir! yok ise  $"/{_filepath}/{fileName}" dosyanın yolunu alıyoruz.
                {
                    result.Message = "dizin içerisinde böyle bir dosya mevcuttur";
                }
                else
                {
                    result.FileUrl = $"/{_filePath}/{fileName}";
                    result.Base64 = null;
                    try //sunucuya dosya yüklerken bağlatı kopması gibi hatalar olabilir.                    
                    {
                        using var stream = new FileStream(pyschalPath, FileMode.Create);
                        file.CopyTo(stream);
                        result.Message = "dosya kaydedildi!";
                        result.FileResult = FileResult.Succeded;
                    }
                    catch
                    {
                        result.Message = "dosya eklenemedi.Lütfen tekrar deneyiniz!";
                        result.FileResult = FileResult.Error;
                    }
                }
            }
            return result;

        }
    }
}
