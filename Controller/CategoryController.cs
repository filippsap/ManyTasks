using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopASPNet.Model.ShopModel;

namespace ShopASPNet.Controller
{
    
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ApplicationContextShop dbContext;

        public CategoryController(ApplicationContextShop _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet("api/getCategory/{id}")]
        public async Task<IResult> GetCategory(int id)
        {
            var category = await dbContext.Categorys.FirstOrDefaultAsync(p => p.Id == id);

            if (category == null)
            {
                return Results.NotFound();
            }
            else return Results.Json(category);
        }

        [Route("api/getCategorys")]
        [HttpGet]
        public IResult GetCategorys()
        {
            var categorys = dbContext.Categorys;

            if (categorys == null)
            {
                return Results.NotFound();
            }
            else return Results.Json(categorys);
        }

        [HttpGet("api/getProductCategory/{categoryId}")]
        public IResult GetProductCategory([FromRoute] int categoryId)
        {
            var products = dbContext.Products.Where(p => p.CategoryId == categoryId);

            if (products == null)
            {
                return Results.NotFound();
            }
            else return Results.Json(products);
        }
    } 
}
