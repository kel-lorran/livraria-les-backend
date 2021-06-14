using Shared;

namespace Domain.MerchandiseContext
{
    public class UpdateStatusBookCommand : ICommand
    {
        public int Active { get; set; }
        public string InativationMessage { get; set; }

        public Book Entity { get; private set; }

        public Book MergeEntity(Book book)
        {
            book.Active = Active;
            book.InativationMessage = InativationMessage;

            Entity = book;
            return book;
        }
    }
}