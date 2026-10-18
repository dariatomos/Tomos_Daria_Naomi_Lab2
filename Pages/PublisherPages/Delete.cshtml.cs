using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tomos_Daria_Naomi_Lab2.Models;
using Tomos_Daria_Naomi_Lab2.Data;

namespace Tomos_Daria_Naomi_Lab2.Pages.PublisherPages;

public class DeleteModel : PageModel
{
    private readonly Tomos_Daria_Naomi_Lab2Context _context;

    public DeleteModel(Tomos_Daria_Naomi_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Publisher Publisher { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
        if (publisher is null)
        {
            return NotFound();
        }
        else
        {
            Publisher = publisher;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var publisher = await _context.Publisher.FindAsync(id);
        if (publisher != null)
        {
            Publisher = publisher;
            _context.Publisher.Remove(Publisher);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
