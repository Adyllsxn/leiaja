namespace LeiaJa.Application.UseCase.AthorUseCase;
public class UpdateAthorUseCase(IAthorRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<AthorDTO>> UpdateAthorAsync(AthorDTO athorDTO)
    {
        ResponseModel<AthorDTO> response = new();
        try
        {   
            if(athorDTO == null)
            {
                response.Message = "Os Parâmetros Não Devem Ser Nulos Ou Vazios.";
                response.StatusCode = 400;
                return response;
            }
            var athor = _mapper.Map<AthorEntity>(athorDTO);
            var updateAthor = await _repository.UpdateAthorAsync(athor);
            if(updateAthor == null)
            {
                response.Message = $"Não Exite Esse Autor Com ID {athor.Id}";
                response.StatusCode = 404;
                return response;
            }
            response.Data = _mapper.Map<AthorDTO>(updateAthor);
            response.Message = "Autor Editada Com Sucesso!";
            response.StatusCode = 200;
            return response;
        }
        catch(Exception ex)
        {
            response.Message = $"Falha Ao Editar O Autor. Erro: {ex.Message}";
            response.StatusCode = 500;
            return response;
        }
    }
}
