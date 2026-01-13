using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FriendsAndFoes2.Web.Data;
using FriendsAndFoes2.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FriendsAndFoes2.Web.Pages.Banners;
    [Authorize]

    public class IndexModel : PageModel
    {
    private readonly ApplicationDbContext _db;
    private readonly UserManager<IdentityUser> _userManager;

    public IndexModel(ApplicationDbContext db, UserManager<IdentityUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }
    public List<Banner> Banners { get; private set; } = new();
    public async Task OnGetAsync()
    {
        var userId = _userManager.GetUserId(User);
        Banners = await _db.Banners
            .Where(b => b.OwnerUserId == userId)
            .OrderByDescending(b => b.CreatedUtc)
            .ToListAsync();


    }
       
    }

