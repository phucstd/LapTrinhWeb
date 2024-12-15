using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWayShop.AppData;

namespace TheWayShop.Components
{
    public class CategoryCatBoxViewComponent : ViewComponent
    {
        private readonly AppDBContext _dbContext;

        public CategoryCatBoxViewComponent(AppDBContext db)
        {
            _dbContext = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var categories = await _dbContext.Categories.ToListAsync();
            return View(categories);
        }
    }
}
