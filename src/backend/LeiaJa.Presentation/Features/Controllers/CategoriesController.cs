namespace LeiaJa.Presentation.Features.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(ICategoryService _service) : ControllerBase
    {

        #region <Get>
            [HttpGet("GetCategories"), EndpointSummary("Get All Categories")]
            public async Task<ActionResult> GetCategories()
            {
                try
                {
                    var categories = await _service.GetCategoriesAsync();
                    if(categories == null || categories.Data == null)
                {
                    return NotFound("Não Foram Encontrados Nenhuma Categorias");
                }
                    return Ok(categories);
                }
                catch
                {
                    return Problem("Ocorreu um erro ao processar a solicitação. Tente novamente mais tarde.");
                }
            }
        #endregion </Get>

        #region <GetId>
            [HttpGet("GetCategory"), EndpointSummary("Get Category By Id")]
            public async Task<ActionResult> GetCategoryById(int categoryId)
            {
                if(categoryId <= 0)
                {
                    return BadRequest("Não Deve Ser Negativa ou Zero");
                }
                var category = await _service.GetCategoriaByIdAsync(categoryId);

                if(category == null)
                {
                    return NotFound("Não Foi Encontrado");
                }
                return Ok(category);
            }
        #endregion </GetId>

        #region <Create>
            [HttpPost("CreateCategoria"), EndpointSummary("Create Category On Database")]
            public async Task<ActionResult> CreateCategoria(CategoryPostDTO categoryPostDTO)
            {
                try
                {
                    if(categoryPostDTO == null)
                        return BadRequest("Não deve ser vazia");

                    var autor = await _service.CreateCategoryAsync(categoryPostDTO);
                    return Ok(autor);
                }
                catch
                {
                    return Problem("Ocorreu um erro ao salvar. Tente novamente mais tarde.");
                }
            }
        #endregion </Create>

        #region <Update>
            [HttpPut("UpdateAutor"), EndpointSummary("Update Category On Database")]
            public async Task<ActionResult> UpdateCategory(CategoryDTO categoryDTO)
            {
                try
                {
                    if(categoryDTO == null)
                        return BadRequest("Não deve ser nulo");

                    var category = await _service.UpdateCategoryAsync(categoryDTO);
                    return Ok(category);
                }
                catch
                {
                    return Problem("Ocorreu um erro ao aditar. Tente novamente mais tarde.");
                }
            }
        #endregion </Update>

        #region  <Delete>
            [HttpDelete("DeleteAutor"), EndpointSummary("Delete Category On Database")]
            public async Task<ActionResult> DeleteCategory(int categoryId)
            {
                try
                {
                    if(categoryId <= 0)
                        return BadRequest("Não deve ser nulo ou Negativa");
                        
                    var category = await _service.DeleteCategoryAsync(categoryId);
                    return Ok(category);
                }
                catch
                {
                    return Problem("Ocorreu um erro ao deletar. Tente novamente mais tarde.");
                }
            }
        #endregion </Delete>
    }
}