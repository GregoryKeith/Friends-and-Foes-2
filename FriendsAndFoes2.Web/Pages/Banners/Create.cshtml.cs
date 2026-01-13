using FriendsAndFoes2.Web.Data;
using FriendsAndFoes2.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FriendsAndFoes2.Web.Pages.Banners;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<IdentityUser> _userManager;

    public CreateModel(ApplicationDbContext db, UserManager<IdentityUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    [BindProperty]
    public Banner Banner { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var userId = _userManager.GetUserId(User);

        Banner.OwnerUserId = userId ?? string.Empty;
        Banner.CreatedUtc = DateTime.UtcNow;

        _db.Banners.Add(Banner);
        await _db.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
