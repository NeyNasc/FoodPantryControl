using AutoMapper;
using br.com.ustj.FoodPantryControl.Domain.Item;
using br.com.ustj.FoodPantryControl.Domain.Log;

namespace br.com.ustj.FoodPantryControl.Infrastructure.PostgresDataAccess.AutoMapperProfile
{
    public class InfraDomainProfile : Profile
    {
        public InfraDomainProfile()
        {
            CreateMap<Entities.Log.Log, Log>().ReverseMap();
            CreateMap<Entities.Item.Item, Item>().ReverseMap();
        }
    }
}
