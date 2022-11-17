using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace GameStore.Application.External.MediaStorage
{
    internal class CloudinaryStorage : IExternalMediaStorage
    {
        public CloudinaryStorage(IOptions<AccountSettings> options)
        {
            cloudinary = new Cloudinary(options.Value);
        }

        private readonly Cloudinary cloudinary;

        public async Task<string> UploadImageAsync(Stream image, string name, string folder)
        {
            var response = await cloudinary.UploadAsync(new ImageUploadParams
            {
                Folder = Path.Combine(FolderNames.Root, folder),
                File = new FileDescription(name, image)
            });

            return response.Url.OriginalString;
        }
    }
}
