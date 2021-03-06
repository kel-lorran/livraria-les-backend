using Shared;

namespace Domain.MerchandiseContext
{
    public class CreateBookCommand : ICommand
    {
        public CreateBookCommand()
        {
        }

        public CreateBookCommand(string author, string title, int category, string publishing, string edition, string iSBN, string codeBar, int year, int pageNumber, string synopsis, int height, int width, int length, int weight, int pricingGroup)
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
        public int Active { get => 1; }
    }
}