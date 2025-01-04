namespace LeiaJa.Application.Mappings;
public class DomainToDTOProfile : Profile
{
    public DomainToDTOProfile()
    {
        #region AUTOR
            CreateMap<AutorEntity, AutorDTO>().ReverseMap();
            CreateMap<AutorEntity, AutorPostDTO>().ReverseMap();
        #endregion

        #region SISTEMA
            CreateMap<QuantidadeEntity, QuantidadeDTO>().ReverseMap();
        #endregion

        #region SISTEMA
            CreateMap<CategoriaEntity, CategoriaDTO>().ReverseMap();
            CreateMap<CategoriaEntity, CategoriaPostDTO>().ReverseMap();
        #endregion
        
    }
}
