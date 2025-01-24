namespace Common.Application;

public class ImageRequestModel
{
    public ImageRequestModel(Stream content) => Content = content;

    public Stream Content { get; }
}