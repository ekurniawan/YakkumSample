using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace DokumenWebApps.Controllers
{
    public class UploadDokumenController : Controller
    {
        private CloudStorageAccount storageAccount;
        private CloudBlobClient blobClient;
        private CloudBlobContainer container;
        //private UploadFileToBlob objUpload;

        //upload to blob
        public UploadDokumenController()
        {
            storageAccount = new CloudStorageAccount(
               new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                   "yakkumstorage", "WUalxetFcSxEc8VxyHPcLxHlFpomwqt3Bk9Ukm2iv9YHSKW+JQpazgMD7+86jPU43Duu2Z5W7cMyPWOipK4PUg=="), true);

            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference("dokumen");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}