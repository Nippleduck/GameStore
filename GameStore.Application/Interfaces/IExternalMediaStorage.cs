namespace GameStore.Application.Interfaces
{
    public interface IExternalMediaStorage
    {
        Task<string> UploadImageAsync(Stream image, string name, string folder);
    }
}
