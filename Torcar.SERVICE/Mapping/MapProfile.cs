using AutoMapper;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Torcar.CORE.DTOs;
using Torcar.CORE.Entity;
using Torcar.CORE.Enums;

namespace Torcar.SERVICE.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserRegisterDto>().ForMember(x=>x.Gender,y=>y.MapFrom(z=>z.Gender)).ReverseMap();
            CreateMap<Advert,AdvertDto>().ForMember(x=>x.ActiveState,m=>m.MapFrom(y=>y.ActiveState)).ReverseMap();
            CreateMap<User,UserDto>().ForMember(x=>x.State,y=>y.MapFrom(m=>m.State)).ForMember(x=>x.Verify,y=>y.MapFrom(m=>m.Verify)).ReverseMap();
            CreateMap<Car, CarDto>().ForMember(x => x.Fuel, m => m.MapFrom(y => y.Fuel)).ForMember(x => x.Gear, m => m.MapFrom(y => y.Gear)).ForMember(x => x.Case, y => y.MapFrom(m => m.Case)).ForMember(x => x.Color, y => y.MapFrom(m => m.Color)).ForMember(x => x.CarSerial, m => m.MapFrom(z => z.CarSerial)).ForMember(x=>x.ActiveState,y=>y.MapFrom(z=>z.ActiveState)).ForMember(x=>x.RentState,y=>y.MapFrom(z=>z.RentState)).ReverseMap();
            CreateMap<RequestDto, RentRequest>().ForMember(x => x.ConfirmState, m => m.MapFrom(y => y.ConfirmState)).ReverseMap();
            CreateMap<CarSerial, CarSerialDto>().ForMember(x=>x.CarModel,y=>y.MapFrom(m=>m.CarModel)).ReverseMap();
            CreateMap<CarModel, CarModelDto>().ForMember(X=>X.CarMark,y=>y.MapFrom(z=>z.CarMark)).ReverseMap();
            CreateMap<CarMark, CarMarkDto>().ReverseMap();
            CreateMap<Rent, RentDto>().ReverseMap();
            
        }
    }
}
