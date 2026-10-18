using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tomos_Daria_Naomi_Lab2.Models;
using Tomos_Daria_Naomi_Lab2.Data;

namespace Tomos_Daria_Naomi_Lab2.Pages.BookPages;

public class DeleteModel : PageModel
{
    private readonly Tomos_Daria_Naomi_Lab2Context _context;

    public DeleteModel(Tomos_Daria_Naomi_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
        if (book is null)
        {
            return NotFound();
        }
        else
        {
            Book = book;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var book = await _context.Book.FindAsync(id);
        if (book != null)
        {
            Book = book;
            _context.Book.Remove(Book);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
