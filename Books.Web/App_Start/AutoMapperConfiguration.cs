using AutoMapper;
using Books.Models;
using Books.Web.ViewModels;

namespace Books.Web
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Book, BookViewModel>()
                    .ForMember(d => d.Image, o => o.Ignore())
                    .ForMember(d => d.HasImage, o => o.MapFrom(p => p.Image != null));
                cfg.CreateMap<BookViewModel, Book>();
                cfg.CreateMap<Author, AuthorViewModel>();
                cfg.CreateMap<AuthorViewModel, Author>();
            });
        }
    }
}
