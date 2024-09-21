using AutoMapper;
using CustomerManagementAPI.Dto_s;

namespace CustomerManagementAPI.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Incident, IncidentDTO>()
                .ForMember(dest => dest.Accounts, opt => opt.MapFrom(src => src.Accounts));

            CreateMap<Account, AccountDTO>()
            .ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => src.Contacts));

            CreateMap<Contact, ContactDTO>();
        }
    }
}
