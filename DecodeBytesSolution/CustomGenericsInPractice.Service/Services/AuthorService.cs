using CSharpFunctionalExtensions;
using CustomGenericsInPractice.Common;
using CustomGenericsInPractice.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericsInPractice.Service.Services
{
    internal class AuthorService : IService<Author>
    {
        //AddAsync, GetAsync
        public Task<IResult<Author, string>> AddAsync(Author author)
        {
            //check for some business logic
            //add to repository
            throw new NotImplementedException();
        }
        public Task<IResult<Author, string>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
