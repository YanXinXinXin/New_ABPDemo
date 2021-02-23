using Acme.BookStore.Authors;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Books
  
{
    public class BookManger : DomainService
    {
        private readonly IBookRepository _bookRepository;

        public BookManger(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book> CreateBook([NotNull] string name, BookType type, DateTime publishDate, float price, Guid authorId)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existsBook = await _bookRepository.FindByNameAsync(name);
            if (existsBook != null)
            {
                throw new AuthorAlreadyExistsException(name);
            }
            return new Book(
             GuidGenerator.Create(),
             name, publishDate, price, type, authorId);

        }
        //var data = new Book
        //{
        //    Id =
        //GuidGenerator.Create(),

        //}
        //var data = new Book { Name = name, Type = type, PublishDate = publishDate, Price = price ,AuthorId=authorId};
        //return data;
        public async Task  ChangeNameAsync([NotNull]Book book,[NotNull]string name)
        {
            Check.NotNull(book, nameof(book));
            Check.NotNullOrWhiteSpace(name, nameof(name));
            var existingBook = await _bookRepository.FindByNameAsync(name);
            if (existingBook != null)
            {
                throw new AuthorAlreadyExistsException(name);
            }
            book.ChangeBookName(name);
        }
    }
}
