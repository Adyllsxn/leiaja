namespace LeiaJa.Presentation.Features.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    #region CONFIGERATION
    private readonly ICategoriaService _service;
    public CategoriaController(ICategoriaService service)
    {
        _service = service;
    }
    #endregion

    #region GET ALL CATEGORIA 
    #endregion

    #region GET CATEGORIA BY ID
    #endregion

    #region CREATE CATEGORIA
    #endregion

    #region UPDATE CATEGORIA
    #endregion

    #region DELETE CATEGORIA
    #endregion

}
