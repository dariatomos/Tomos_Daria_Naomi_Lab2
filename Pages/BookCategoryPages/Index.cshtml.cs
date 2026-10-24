using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tomos_Daria_Naomi_Lab2.Models;
using Tomos_Daria_Naomi_Lab2.Data;

namespace Tomos_Daria_Naomi_Lab2.Pages.BookCategoryPages;

public class IndexModel : PageModel
{
    private readonly Tomos_Daria_Naomi_Lab2Context _context;

    public IndexModel(Tomos_Daria_Naomi_Lab2Context context)
    {
        _context = context;
    }

    public IList<BookCategory> BookCategory { get; set; } = default!;

    public async Task OnGetAsync()
    {
        BookCategory = await _context.BookCategory.ToListAsync();
    }
}
