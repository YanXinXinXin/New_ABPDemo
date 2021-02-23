using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Authors;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Books
{
    [Authorize(BookStorePermissions.Books.Default)]
    public class BookAppService :
        CrudAppService<
            Book, //The Book entity
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookDto>, //Used to create/update a book
        IBookAppService //implement the IBookAppService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly BookManger _bookManger;

        public BookAppService(
            IBookRepository bookRepository,
            IRepository<Book, Guid> repository,
            IAuthorRepository authorRepository, BookManger bookManger)
            : base(repository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _bookManger = bookManger;
            GetPolicyName = BookStorePermissions.Books.Default;
            GetListPolicyName = BookStorePermissions.Books.Default;
            CreatePolicyName = BookStorePermissions.Books.Create;
            UpdatePolicyName = BookStorePermissions.Books.Edit;
            DeletePolicyName = BookStorePermissions.Books.Create;
        }

        public override async Task<BookDto> GetAsync(Guid id)
        {
            //Prepare a query to join books and authors
            var query = from book in Repository
                join author in _authorRepository on book.AuthorId equals author.Id
                where book.Id == id
                select new { book, author };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Book), id);
            }

            var bookDto = ObjectMapper.Map<Book, BookDto>(queryResult
                .book);
            bookDto.AuthorName = queryResult.author.Name;
            return bookDto;
        }

        public override async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Prepare a query to join books and authors
            var query = from book in Repository
                join author in _authorRepository on book.AuthorId equals author.Id
                orderby input.Sorting //TODO: Can not sort like that!
                select new {book, author};

            query = query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //异步执行查询并获取列表 
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //将查询结果转换为BookDto对象列表 
            var bookDtos = queryResult.Select(x =>
            {
                var bookDto = ObjectMapper.Map<Book, BookDto>(x.book);
                bookDto.AuthorName = x.author.Name;
                return bookDto;
            }).ToList();

            //使用另一个查询获取总数 
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<BookDto>(
                totalCount,
                bookDtos
            );

        }

        public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
        {
            var authors = await _authorRepository.GetListAsync();

            return new ListResultDto<AuthorLookupDto>(
                ObjectMapper.Map<List<Author>, List<AuthorLookupDto>>(authors)
            );
        }
        [Authorize(BookStorePermissions.Books.Create)]
        public async Task<BookDto> CreateBookAsync(CreateUpdateBookDto input)
        {
         var data = await _bookManger.CreateBook(input.Name, input.Type, input.PublishDate, input.Price,input.AuthorId);
            await _bookRepository.InsertAsync(data);

           return ObjectMapper.Map<Book,BookDto>(data);
        }

      public  async Task DeleteByBookIdAsync(Guid id)
        {
            var result = await AuthorizationService.AuthorizeAsync("BookStore.Authors.Delete");
            if (result.Succeeded == false)
            {
                throw new AbpAuthorizationException("报错啦");
            }
            await   _bookRepository.DeleteAsync(id);
        }
        [Authorize(BookStorePermissions.Books.Edit)]
        public async Task UpdateByBookIdAsync(Guid id, CreateUpdateBookDto input)
        {
            var data = await _bookRepository.GetAsync(id);
            if (data==null)
            {
                throw new BookAlreadyExistsException(id.ToString());
            }
            ///新输入的书名不能同名 也不能与数据库同名
              var  FindBook = await _bookRepository.FindByNameAsync(input.Name);
            if (data.Name != input.Name && FindBook== null)
            {
                await _bookManger.ChangeNameAsync(data, input.Name);
                data.AuthorId = input.AuthorId;
                //data.Name = input.Name;
                data.Price = input.Price; data.Type = input.Type;
                data.PublishDate = input.PublishDate;
                await _bookRepository.UpdateAsync(data);
            }
            else
            {
                 throw new BookAlreadyExistsException(input.Name);
            }

            //var book = await _bookRepository.FindByNameAsync(input.Name);
            //if (book==null)
            //{
            //    await _bookManger.ChangeNameAsync(data, input.Name);
            //    //throw new  BookAlreadyExistsException(input.Name);
            //}
         
           
        }
    } 
}
