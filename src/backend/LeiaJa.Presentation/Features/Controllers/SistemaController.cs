namespace LeiaJa.Presentation.Features.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SistemaController : ControllerBase
{
    private readonly ISistemaService _service;
    public SistemaController(ISistemaService service)
    {
        _service = service;
    }

    #region DASHBOARD
    [HttpGet("Dashboard")]
    public async Task<ActionResult> Dashboard()
    {
        var quantidadeItemsDTO = await _service.GetQtdItems();

        var result = $" Total de Autor: {quantidadeItemsDTO.QtdAutor} \n Total de Categoria: {quantidadeItemsDTO.QtdCategoria}";
        return Ok(result);
    }
    #endregion
}
