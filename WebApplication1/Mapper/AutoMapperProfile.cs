using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Model;

namespace WebApplication1.Mapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Incident, IncidentDto>().ReverseMap();// для того щоб ми могли перетворити з сіті до дто і навпаки 

            CreateMap<Account, AccountDto>().ReverseMap();

            CreateMap<Contact, AccountDto>().ReverseMap();


            CreateMap<Account, IncidentDto>()
               .ForMember(
                   u => u.AccontName,
                   o => o.MapFrom(dto => dto.Name)
               );
              
               

        }
    }
}
