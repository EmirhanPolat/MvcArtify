using Azure.Storage.Blobs;
using MvcArtify.Models.BlobStorage;

namespace MvcArtify.Services
{
    public class FileService
    {
        private readonly IConfiguration _configuration;
        private readonly string _containerName;
        private readonly string _connectionString;
        private readonly BlobContainerClient _containerClient;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["Storage:StorageConnStr"];
            _containerName = _configuration["Storage:ContainerName"];
            _containerClient = new BlobContainerClient(_connectionString, _containerName);
        }

        public async Task<List<BlobDto>> ListAsync()
        {
            List<BlobDto> files = new List<BlobDto>();

            await foreach (var file in _containerClient.GetBlobsAsync())
            {
                string uri = _containerClient.Uri.ToString();
                var name = file.Name;
                var fullUri = $"{uri}/{name}";

                files.Add(new BlobDto
                {
                    Uri = fullUri,
                    Name = name,
                    ContentType = file.Properties.ContentType
                });
            }

            return files;
        }

        public async Task<BlobResponseDto> UploadAsync(IFormFile file)
        {
            BlobResponseDto response = new();
            BlobClient client = _containerClient.GetBlobClient(file.FileName);

            await using (Stream? data = file.OpenReadStream())
            {
                await client.UploadAsync(data);
            }

            response.Status = $"File {file.FileName} Uploaded Successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = client.Name;

            return response;
        }

        public async Task<BlobDto?> DownloadAsync(string blobFileName)
        {
            BlobClient file = _containerClient.GetBlobClient(blobFileName);

            if (await file.ExistsAsync())
            {
                var data = await file.OpenReadAsync();
                Stream blobContent = data;

                var content = await file.DownloadContentAsync();

                string name = blobFileName;
                string contentType = content.Value.Details.ContentType;

                return new BlobDto { Content = blobContent, Name = name, ContentType = contentType };
            }

            return null;
        }

        public async Task<BlobResponseDto> DeleteAsync(string blobFilename)
        {
            BlobClient file = _containerClient.GetBlobClient(blobFilename);

            await file.DeleteAsync();

            return new BlobResponseDto { Error = false, Status = $"File: {blobFilename} has been successfully deleted" };
        }
    }
}
