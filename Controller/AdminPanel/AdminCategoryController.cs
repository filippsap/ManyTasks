using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopASPNet.Model.ShopModel;

namespace ShopASPNet.Controller.AdminPanel
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCategoryController : ControllerBase
    {
        private ApplicationContextShop dbContext;

        public AdminCategoryController(ApplicationContextShop _dbContext)
        {
            dbContext = _dbContext;
        }

        [Route("apiAdmin/getCategorys")]
        [HttpGet]
        public IResult GetCategorys()
        {
            return Results.Json(dbContext.Categorys);
        }

        [HttpGet("apiAdmin/getCategory/{id}")]
        public IResult GetCategory(int id)
        {
            return Results.Json(dbContext.Categorys.FirstOrDefault(cat => cat.Id == id));
        }

        [Route("apiAdmin/createCategory")]
        [HttpPost]
        public async Task<IResult> CreateCategory([FromBody] Category category)
        {
            if(category == null)
            {
                return Results.NotFound();
            }
            else
            {
               await dbContext.Categorys.AddAsync(category);
               await dbContext.SaveChangesAsync();
               return  Results.Ok();
            }
        }

        [HttpPut("apiAdmin/changeCategory/{id}")]
        public async Task<IResult> СhangeCategory( [FromBody] Category categoryOld)
        {
            var category = await dbContext.Categorys.FirstOrDefaultAsync(u => u.Id == categoryOld.Id);

            if (category == null) return Results.NotFound(new { message = "Пользователь не найден" });

            category.Name = category.Name;
            await dbContext.SaveChangesAsync();
            return Results.Json(category);
        }

        [HttpDelete("apiAdmin/deleteCategory/{id}")]
        public async Task<IResult> DeleteCategory(int id)
        {
            Category? categor = await dbContext.Categorys.FirstOrDefaultAsync(u => u.Id == id);

            if (categor == null) return Results.NotFound(new { message = "Пользователь не найден" });

            dbContext.Categorys.Remove(categor);
            await dbContext.SaveChangesAsync();
            return Results.Json(categor);
        }
    }
}
