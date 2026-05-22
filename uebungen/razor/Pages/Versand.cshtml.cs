using Microsoft.AspNetCore.Mvc.RazorPages;

public class VersandModel: PageModel{

    public int? LocationID {get; set;}
    public List<string> Locations = ["Deutschland", "EU", "International"];
    public int? Kosten {get; set;}

    public void OnGet(int locationID){
        if(locationID == 0){Kosten = 0;}
        if(locationID == 1){Kosten = 5;}
        if(locationID == 2){Kosten = 15;}
    }

    public void OnPost(int locationID){
        if(locationID == 0){Kosten = 0;}
        if(locationID == 1){Kosten = 5;}
        if(locationID == 2){Kosten = 15;}
    }

}
