using Automapper.DTO_s;
using Automapper.Models;


namespace Automapper.Helpers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Mapping User entity to UserDto
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // Optionally, reverse mapping if needed
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FullName.Split(' ')[0]))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FullName.Split(' ')[1]));
        }
    }
}
