namespace LeiaJa.Application.Services;
public class AutorService : IAutorService
{

    #region <Configuration>
        private readonly IAutorRepository _repository;
        private readonly IMapper _mapper;
        public AutorService(IAutorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    #endregion </Configuration>
    
    #region <Create>
        public async Task<ResponseModel<List<AutorDTO>>> CreateAutorAsync(AutorPostDTO autorDTO)
        {
            ResponseModel<List<AutorDTO>> response = new();
            try
            {
                if(autorDTO == null)
                {
                    response.Message = "Os Parâmetros Não Devem Ser Nulos Ou Vazios.";
                    return response;
                }
                var autor = _mapper.Map<AutorEntity>(autorDTO);
                var createAutor = await _repository.CreateAutorAsync(autor);

                response.Data = _mapper.Map<List<AutorDTO>>(createAutor);
                response.Message = "O Autor Foi Salvo Com Sucesso";
                response.StatusCode = 201;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Salvar O Autor. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
    #endregion </Create>
    
    #region <Delete>
        public async Task<ResponseModel<AutorDTO>> DeleteAutorAsync(int autorId)
        {
            ResponseModel<AutorDTO> response = new();
            try
            {
                if(autorId <= 0)
                {
                    response.Message = "O ID Não Deve Ser Menor Ou Igual A Zero.";
                    return response;
                }
                var deleteAutor = await _repository.DeleteAutorAsync(autorId);
                if(deleteAutor == null)
                {
                    response.Message = $"Nenhum Autor Encontrado Com O ID {autorId}.";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data = _mapper.Map<AutorDTO>(deleteAutor);
                response.Message = "O Autor Foi Deletado Com Sucesso.";
                response.StatusCode = 200;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Deletar O Autor. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
    #endregion </Delete>

    #region <Get>
        public async Task<ResponseModel<PagedList<AutorDTO>>> GetAllAutoresAsync(int pageNumber, int pageSize)
        {
            ResponseModel<PagedList<AutorDTO>> response = new();
            try
            {
                var autores = await _repository.GetAllAutoresAsync(pageNumber, pageSize);
                var autoresDTOs = _mapper.Map<List<AutorDTO>>(autores);
                if(!autoresDTOs.Any())
                {
                    response.Message = "Nenhum Autor Encontrado.";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data =  new PagedList<AutorDTO>(autoresDTOs, pageNumber, pageSize, autores.TotalCount);
                response.Message = "Autores Encontrados";
                response.StatusCode = 200;
                return response;
            }
            catch (Exception ex)    
            {
                response.Message = $"Falha Ao Listar Os Autores. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
    #endregion </Get>
    
    #region <GetId>
        public async Task<ResponseModel<AutorDTO>> GetAutorByIdAsync(int autorId)
        {
            ResponseModel<AutorDTO> response = new();
            try
            {
                if(autorId <= 0)
                {
                    response.Message = "O ID Não Deve Ser Menor Ou Igual A Zero.";
                    return response;
                }
                var autor = await _repository.GetAutorByIdAsync(autorId);
                var autorDTO = _mapper.Map<AutorDTO>(autor);
                if(autorDTO == null)
                {
                    response.Message = $"Não Existe O Autor Com ID {autorId}!";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data = autorDTO;
                response.Message = $"Foi Encontrado Autor Com ID = {autorId}!";
                response.StatusCode = 200;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Obter O Autor. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
    #endregion </GetId>
    
    #region <Update>
        public async Task<ResponseModel<AutorDTO>> UpdateAutorAsync(AutorDTO autorDTO)
        {
            ResponseModel<AutorDTO> response = new();
            try
            {
                if(autorDTO == null)
                {
                    response.Message = "Os Parâmetros Não Devem Ser Nulos Ou Vazios.";
                    return response;
                }
                var autor = _mapper.Map<AutorEntity>(autorDTO);
                var updateAutor = await _repository.UpdateAutorAsync(autor);

                if(updateAutor == null)
                {
                    response.Message = "Não Exite.";
                    response.StatusCode = 404;
                    return response;
                }
                
                response.Data = _mapper.Map<AutorDTO>(updateAutor);
                response.Message = "Autor Editado Com Sucesso!";
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
    #endregion </Update>
}
