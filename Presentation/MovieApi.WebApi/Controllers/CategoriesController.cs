using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //Bu doğru bir yöntem ama Bunu daha kısa yolu mediator kullanmaktır.
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            return Ok(await _getCategoryQueryHandler.Handle());
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            //await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand { CategoryId = id });
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Silme İşlemi Başarılı!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("Güncelleme İşlemi Başarılı!");

        }
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            //return Ok(await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery { CategoryId = id }));
            return Ok(await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery (id)));
        }



        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok();
        }
       
      
    
    }
}
