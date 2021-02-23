using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Books
{
    public interface IBookAppService :IApplicationService,
        ICrudAppService< //Defines CRUD methods
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookDto> //Used to create/update a book
    {
        Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();

        Task<BookDto> CreateBookAsync(CreateUpdateBookDto input);

          Task DeleteByBookIdAsync(Guid id);

         Task UpdateByBookIdAsync(Guid id, CreateUpdateBookDto input);
    }
}