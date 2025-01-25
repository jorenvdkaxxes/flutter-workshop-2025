namespace Common.Application;

public interface IImageService
{
    Task<ImageResponseModel> Process(ImageRequestModel image);
}