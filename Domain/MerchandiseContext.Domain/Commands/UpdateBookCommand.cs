using Shared;

namespace Domain.MerchandiseContext
{
    public class UpdateBookCommand : ICommand
    {
        public UpdateBookCommand()
        {
        }

        public UpdateBookCommand(string author, string title, int category, string publishing, string edition, string iSBN, string codeBar, int year, int pageNumber, string synopsis, int height, int width, int length, int weight, int pricingGroup)
        {
            Author = author;
            Title = title;
            Category = category;
            Publishing = publishing;
            Edition = edition;
            ISBN = iSBN;
            CodeBar = codeBar;
            Year = year;
            PageNumber = pageNumber;
            Synopsis = synopsis;
            Height = height;
            Width = width;
            Length = length;
            Weight = weight;
            PricingGroup = pricingGroup;
        }

        public string Author { get; set; }
        public string Title { get; set; }
        public int Category { get; set; }
        public string Publishing { get; set; }
        public string Edition { get; set; }
        public string ISBN { get; set; }
        public string CodeBar { get; set; }
        public int Year { get; set; }
        public int PageNumber { get; set; }
        public string Synopsis { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Weight { get; set; }
        public int PricingGroup { get; set; }

        public Book Entity { get; private set; }

        public Book MergeEntity(Book book)
        {
            if (Author != null && Author != book.Author)
                book.Author = Author;
            if (Title != null && Title != book.Title)
                book.Title = Title;
            if (Publishing != null && Publishing != book.Publishing)
                book.Publishing = Publishing;
            if (Edition != null && Edition != book.Edition)
                book.Edition = Edition;
            if (ISBN != null && ISBN != book.ISBN)
                book.ISBN = ISBN;
            if (CodeBar != null && CodeBar != book.CodeBar)
                book.CodeBar = CodeBar;
            if (Year != 0 && Year != book.Year)
                book.Year = Year;
            if (PageNumber != 0 && PageNumber != book.PageNumber)
                book.PageNumber = PageNumber;
            if (Synopsis != null && Synopsis != book.Synopsis)
                book.Synopsis = Synopsis;
            if (Height != 0 && Height != book.Height)
                book.Height = Height;
            if (Width != 0 && Width != book.Width)
                book.Width = Width;
            if (Length != 0 && Length != book.Length)
                book.Length = Length;
            if (Weight != 0 && Weight != book.Weight)
                book.Weight = Weight;
            if (Category != 0 && book.Category.Id != Category)
                book.Category = new Category(Category);
            if (PricingGroup != 0 && book.PricingGroup.Id != PricingGroup)
                book.PricingGroup = new PriceGroup(PricingGroup);

            Entity = book;
            return book;
        }
    }
}