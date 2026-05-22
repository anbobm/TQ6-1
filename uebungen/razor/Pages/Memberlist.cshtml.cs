using Microsoft.AspNetCore.Mvc.RazorPages;

public class MemberlistModel: PageModel{
    public List<Member>? Members{get; set;}

    public void OnGet(){
        var db = new Db();
        Members = db.member.ToList();
    }
}
