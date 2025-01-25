using Common.Application;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Common.Web;

public class ImageModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var formFile = bindingContext
            .ActionContext
            .HttpContext
            .Request
            .Form
            .Files
            .FirstOrDefault();

        if (formFile == null)
        {
            bindingContext.Result = ModelBindingResult.Failed();
        }
        else
        {
            var imageRequest = new ImageRequestModel(formFile.OpenReadStream());
            bindingContext.Result = ModelBindingResult.Success(imageRequest);
        }

        return Task.CompletedTask;
    }
}