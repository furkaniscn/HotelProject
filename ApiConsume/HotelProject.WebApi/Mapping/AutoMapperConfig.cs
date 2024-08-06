using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    //Dto'lar ve Entity'leri bağlayacağımız sınıf olarak oluşturduk.
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddRoomDto, Room>();//AddRoomDto ile Room sınıfı birleştir.
            CreateMap<Room, AddRoomDto>();

            //ReverseMap tersine de mapliyor yukarıda kullanıma gerek kalmıyor.
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
