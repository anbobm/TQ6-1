using System.Data.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages;

public class MembersModel : PageModel
{
    public List<Member> Members { get; set; } = new();

    public void OnGet()
    {
        var db = new Db();
        db.Database.EnsureCreated();
        Members = db.Members.ToList();
    }
}