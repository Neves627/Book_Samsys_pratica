using AutoMapper;
using Samsys_Book_Practice.DTOs;
using Samsys_Book_Practice.Entity;

namespace Samsys_Book_Practice.Mappings
{
    public class EntityToDTOMappingProfile : Profile
    {
        public EntityToDTOMappingProfile() { 
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, BookPostDTO>().ReverseMap();
        }
    }
}
