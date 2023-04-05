namespace CWRETAIL.Api.Menus.Profiles
{
    public class MenuProfile : AutoMapper.Profile
    {
        public MenuProfile()
        {
            CreateMap<Db.Menu, Models.Menu>();
            CreateMap<Db.LocationMenu, Models.LocationMenu>()
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Menu.Name))
            .ForMember(d => d.Description, o => o.MapFrom(s => s.Menu.Description))
            .ForMember(d => d.MenuId, o => o.MapFrom(s => s.Menu.MenuId))
            .ForMember(d => d.Category, opt => opt.NullSubstitute(""))
            .ForMember(d => d.MenuStatus, opt => opt.NullSubstitute(""))
            .ForMember(d => d.LocationName, opt => opt.NullSubstitute(""));
            //.ForAllMembers(o => o.Condition((src, dest, value) => value != null));
        }
    }
}
