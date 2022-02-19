using RepositoryPatternWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.Core.Dtos
{
    public class BookDetailsDto
    {

        public int Id { get; set; }

        [Required, MaxLength(250)]
        public string Title { get; set; }

        public string AuthorName { get; set; }
        public int AuthorId { get; set; }

       
    }
}
