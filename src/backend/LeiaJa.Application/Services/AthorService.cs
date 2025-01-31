
namespace LeiaJa.Application.Services;
public class AthorService(CreateAthorUseCase _create, GetAthorsUseCase _get, GetAthorByIdUseCase _getId, DeleteAthorUseCase _delete, UpdateAthorUseCase _update, SearchAthorUseCase _search) : IAthorService
{
    public async Task<ResponseModel<List<AthorDTO>>> CreateAthorAsync(AthorPostDTO athorPostDTO)
    {
        return await _create.CreateAthorAsync(athorPostDTO);
    }

    public async Task<ResponseModel<AthorDTO>> DeleteAthorAsync(int athorId)
    {
        return await _delete.DeleteAthorAsync(athorId);
    }

    public async Task<ResponseModel<AthorDTO>> GetAthorByIdAsync(int athorId)
    {
        return await _getId.GetAthorByIdAsync(athorId);
    }

    public async Task<ResponseModel<List<AthorDTO>>> GetAthorsAsync()
    {
        return await _get.GetAthorsAsync();
    }

    public async Task<ResponseModel<List<AthorDTO>>> SearchAthorsAsync(string predicate)
    {
        return await _search.SearchAthorsAsync(predicate);
    }

    public async Task<ResponseModel<AthorDTO>> UpdateAthorAsync(AthorDTO athorDTO)
    {
        return await _update.UpdateAthorAsync(athorDTO);
    }
}
