using System;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public Guid AuthorId { get; set; }

        public string Name { get; private set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
        internal Book(Guid id, [NotNull]string name, DateTime publishDate, float price, BookType type,Guid authorId)
            :base(id)
        {
            SetName(name);
            PublishDate = publishDate; Price = price;
            Type = type;
            AuthorId = authorId;
        }
        internal Book ChangeBookName([NotNull] string name) {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name, nameof(name)
                );
        }

        private Book()
        {
            

        }


    }
}
