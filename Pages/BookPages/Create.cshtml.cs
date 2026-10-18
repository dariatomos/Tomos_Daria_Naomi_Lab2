using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tomos_Daria_Naomi_Lab2.Models;
using Tomos_Daria_Naomi_Lab2.Data;

namespace Tomos_Daria_Naomi_Lab2.Pages.BookPages;

public class CreateModel : PageModel
{
    private readonly Tomos_Daria_Naomi_Lab2Context _context;

    public CreateModel(Tomos_Daria_Naomi_Lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName");
        return Page();
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
