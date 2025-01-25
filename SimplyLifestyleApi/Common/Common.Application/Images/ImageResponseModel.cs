namespace Common.Application;

public class ImageResponseModel
{
    public ImageResponseModel(
        byte[] originalContent,
        byte[] thumbnailContent)
    {
        OriginalContent = originalContent;
        ThumbnailContent = thumbnailContent;
    }

    public byte[] OriginalContent { get; }

    public byte[] ThumbnailContent { get; }
}