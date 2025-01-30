namespace LeiaJa.Application.UseCase.AthorUseCase;
public class GetAthorsUseCase(IAthorRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<List<AthorDTO>>> GetAthorsAsync()
    {
        ResponseModel<List<AthorDTO>> response = new ();
        try
        {       
                var athors = await _repository.GetAthorsAsync();
                var athorDTOs = _mapper.Map<List<AthorDTO>>(athors);
                if(!athorDTOs.Any())
                {
                    response.Message = "Nenhuma autor encontrado.";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data =  athorDTOs.ToList();
                response.Message = "autores encontrados";
                response.StatusCode = 200;
                return response;
        }
        catch (Exception ex)
        {
                response.Message = $"Falha ao listar os autores. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
        }
    }
}
