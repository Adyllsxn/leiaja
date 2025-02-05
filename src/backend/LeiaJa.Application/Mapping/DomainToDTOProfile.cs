namespace LeiaJa.Application.Mapping;
public class DomainToDTOProfile : Profile
{
    public DomainToDTOProfile()
    {
        #region <Category>
            CreateMap<CategoryEntity, CategoryDTO>().ReverseMap();
            CreateMap<CategoryEntity, CategoryPostDTO>().ReverseMap();
        #endregion </Category>

        #region <Dashboard>
            CreateMap<DashboardEntity, DashboardDTO>().ReverseMap();
        #endregion </Dashboard>

        #region <Athor>
            CreateMap<AthorEntity, AthorDTO>().ReverseMap();
            CreateMap<AthorEntity, AthorPostDTO>().ReverseMap();
        #endregion </Athor>

        #region <Book>
            CreateMap<BookEntity, BookDto>()
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookAthors.Select(ba => new AuthorDto
            {
                FirstName = ba.Athor.FirstName,
                LastName = ba.Athor.LastName
            })))
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.BookCategories.Select(bc => new CategoryDto
            {
                Category = bc.Category.Category
            }))).ReverseMap();
            CreateMap<AthorEntity, AuthorDto>();
            CreateMap<CategoryEntity, CategoryDto>();

            CreateMap<BookEntity, BookPostDTO>().ReverseMap();

        #endregion </Book>
    }
}