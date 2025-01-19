namespace LeiaJa.Application.Mappings;
public class DomainToDTOProfile : Profile
{
    public DomainToDTOProfile()
    {
        #region <Autor>
            CreateMap<AutorEntity, AutorDTO>().ReverseMap();
            CreateMap<AutorEntity, AutorPostDTO>().ReverseMap();
        #endregion </Autor>

        #region <Quantidade>
            CreateMap<QuantidadeEntity, QuantidadeDTO>().ReverseMap();
        #endregion </Quantidade>

        #region <Categoria>
            CreateMap<CategoriaEntity, CategoriaDTO>().ReverseMap();
            CreateMap<CategoriaEntity, CategoriaPostDTO>().ReverseMap();
        #endregion <Categoria>
        
    }
}
