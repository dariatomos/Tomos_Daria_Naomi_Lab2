using Tomos_Daria_Naomi_Lab2.Models;

namespace Tomos_Daria_Naomi_Lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}