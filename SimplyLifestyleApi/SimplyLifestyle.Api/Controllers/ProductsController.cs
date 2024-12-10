using Microsoft.AspNetCore.Mvc;
using SimplyLifestyle.Application;

namespace SimplyLifestyleApi.Controllers;

[Route("[controller]/[action]")]
public class ProductsController : ApiController
{
    public ProductsController()
    {

    }

    [HttpGet]
    public async Task<IActionResult> AllProducts()
    {
        var outputResult = await Mediator.Send(new AllProductsQuery());

        return ToActionResult(outputResult);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(CreateProductCommand createProductCommand)
    {
        var outputResult = await Mediator.Send(createProductCommand);

        return ToActionResult(outputResult);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(DeleteProductCommand deleteProductCommand)
    {
        var outputResult = await Mediator.Send(deleteProductCommand);

        return ToActionResult(outputResult);
    }
}
