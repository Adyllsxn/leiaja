namespace LeiaJa.Application.Mapping;
public class DomainToDTOProfile : Profile
{
    public DomainToDTOProfile()
    {
        #region <Livro>
            CreateMap<LivroEntity, LivroDTO>().ReverseMap();
            CreateMap<LivroEntity, LivroPostDTO>().ReverseMap();
        #endregion </Livro>
        
    }
}