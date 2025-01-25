using Common.Application;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Common.Web;

public class ImageModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
        => context.Metadata.ModelType == typeof(ImageRequestModel)
            ? new ImageModelBinder()
            : default;
}