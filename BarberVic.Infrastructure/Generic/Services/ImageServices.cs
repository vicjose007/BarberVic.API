using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BarberVic.Application.Common.Interfaces;
using BarberVic.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Infrastructure.Generic.Services
{
    public class ImageServices : IImageService
    {
        protected BlobServiceClient blobClient;
        protected BlobClient _client;
        protected BlobContainerClient containerClient;
        public ImageServices()
        {
            blobClient = new BlobServiceClient(StorageAccount.connection);
        }

        public async Task<string> Upload(IFormFile model)
        {
            string fileName = $"{Guid.NewGuid().ToString()}-{model.FileName}";
            containerClient = blobClient.GetBlobContainerClient("upload-file");
            _client = containerClient.GetBlobClient(fileName);
            using (var fileStream = await _client.OpenWriteAsync(true, new BlobOpenWriteOptions()))
            {
                await model.CopyToAsync(fileStream);
                fileStream.Close();
            }
            return _client.Uri.ToString();
        }
    }
}
