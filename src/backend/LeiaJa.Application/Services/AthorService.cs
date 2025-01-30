namespace LeiaJa.Application.Services;
public class AthorService(CreateAthorUseCase _create, GetAthorsUseCase _get) : IAthorService
{
    public async Task<ResponseModel<List<AthorDTO>>> CreateAthorAsync(AthorPostDTO athorPostDTO)
    {
        return await _create.CreateAthorAsync(athorPostDTO);
    }

    public async Task<ResponseModel<List<AthorDTO>>> GetAthorsAsync()
    {
        return await _get.GetAthorsAsync();
    }
}
