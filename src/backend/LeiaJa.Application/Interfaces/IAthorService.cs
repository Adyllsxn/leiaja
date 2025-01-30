namespace LeiaJa.Application.Interfaces;
public interface IAthorService
{
    Task<ResponseModel<List<AthorDTO>>> CreateAthorAsync(AthorPostDTO athorPostDTO);
    Task<ResponseModel<List<AthorDTO>>> GetAthorsAsync();
}
