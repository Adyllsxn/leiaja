namespace LeiaJa.Presentation.Features.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DashboardController(IDashboardService _service) : ControllerBase
{
    [HttpGet()]
    public async Task<ActionResult> Dashboard()
    {
        var quantityItems = await _service.GetQuantityItems();
        var result = $"=> Total Category: {quantityItems.CategoryItems}\n=> Total Athor: {quantityItems.AthorItems} ";
        return Ok(result);
    }
}
