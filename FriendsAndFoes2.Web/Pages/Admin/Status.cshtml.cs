using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace FriendsAndFoes2.Web.Pages.Admin;
[Authorize]

public class StatusModel : PageModel
{
    public string Username => User.Identity?.Name ?? "Anonymous";
 
    public void OnGet()
    {
    }
}
