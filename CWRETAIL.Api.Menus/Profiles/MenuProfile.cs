namespace CWRETAIL.Api.Menus.Profiles
{
    public class MenuProfile : AutoMapper.Profile
    {
        public MenuProfile()
        {
            CreateMap<Db.Menu, Models.Menu>();
            CreateMap<Db.LocationMenu, Models.LocationMenu>();
        }
    }
}
