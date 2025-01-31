namespace LeiaJa.Application.Interfaces;
public interface IAthorService
{
    Task<ResponseModel<List<AthorDTO>>> CreateAthorAsync(AthorPostDTO athorPostDTO);
    Task<ResponseModel<List<AthorDTO>>> GetAthorsAsync();
    Task<ResponseModel<AthorDTO>> DeleteAthorAsync(int athorId);
    Task<ResponseModel<AthorDTO>> GetAthorByIdAsync(int athorId);
    Task<ResponseModel<AthorDTO>> UpdateAthorAsync(AthorDTO athorDTO);
    Task<ResponseModel<List<AthorDTO>>> SearchAthorsAsync(string predicate);
}
