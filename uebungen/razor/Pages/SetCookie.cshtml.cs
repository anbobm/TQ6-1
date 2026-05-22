using Microsoft.AspNetCore.Mvc.RazorPages;

public class SetCookieModel: PageModel{

    public bool CookieSet = false;

    public void OnPost(string keks, string keksfuellung){
        Response.Cookies.Append(keks, keksfuellung);
        CookieSet = true;
    }

}
