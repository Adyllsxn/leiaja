namespace LeiaJa.Application.UseCase.AthorUseCase;
public class CreateAthorUseCase(IAthorRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<List<AthorDTO>>> CreateAthorAsync(AthorPostDTO athorPostDTO)
    {
        ResponseModel<List<AthorDTO>> response = new();
        try
        {
            if(athorPostDTO == null)
            {
                response.Message = "Os parâmetros não devem ser nulos ou vazios.";
                return response;
            }
            var athor = _mapper.Map<AthorEntity>(athorPostDTO);
            var createAthor = await _repository.CreateAthorAsync(athor);
            if(createAthor == null)
            {
                response.Message = "Falha Ao salvar o autor. Os Parâmetros Podem Estar Inválidos.";
                response.StatusCode = 400;
                return response;
            }

            response.Data = _mapper.Map<List<AthorDTO>>(await _repository.GetAthorsAsync());
            response.Message = "O Autor Foi Salvo Com Sucesso";
            response.StatusCode = 201;
            return response;
        }
        catch(Exception ex)
        {
            response.Message = $"Falha Ao Salvar o autor. Erro: {ex.Message}";
            response.StatusCode = 500;
            return response;
        }
    }
}
