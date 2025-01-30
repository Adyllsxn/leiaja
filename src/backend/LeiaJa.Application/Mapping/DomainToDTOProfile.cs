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
        #endregion </AthorEntity,>
        
    }
}