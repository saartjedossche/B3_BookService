﻿using AutoMapper;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using System.Linq;

namespace BookService.WebAPI.Services.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration(): this("MyProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<PublisherBasic, Publisher>();
            CreateMap<BookBasic, Book>();
            CreateMap<Book, BookDetail>()
                .ForMember(dest => dest.AuthorName,
                           opts => opts.MapFrom(src => $"{src.Author.LastName} {src.Author.FirstName}"));
            CreateMap<Book, BookStatistics>()
                .ForMember(dest => dest.RatingsCount,
                           opts => opts.MapFrom(src => src.Ratings.Count))
                .ForMember(dest => dest.ScoreAverage,
                           opts => opts.MapFrom(src => src.Ratings.Average(r => r.Score)));
        }
    }
}
