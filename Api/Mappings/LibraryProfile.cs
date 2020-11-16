using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Models;
using AutoMapper;

namespace Api.Mappings
{
    public class LibraryProfile:Profile
    {
        public LibraryProfile()
        {
            //Resource to Domain
            CreateMap<NewBookResourceDto, Book>();
            CreateMap<BorrowBookResourceDto, BookHasStudent>();
            
            //Domain to Resource
            CreateMap<Book, BorrowedBookResourceDto>();
            CreateMap<Book, BookBorrowed>();
            CreateMap<Book, BookResourceDto>();
        }
    }
}
