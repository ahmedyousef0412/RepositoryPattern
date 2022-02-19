using AutoMapper;
using RepositoryPatternWithUnitOfWork.Core.Dtos;
using RepositoryPatternWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.Core.Helper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Book, BookDetailsDto>();
            //CreateMap<BookDetailsDto, Book>();
        }
    }
}
