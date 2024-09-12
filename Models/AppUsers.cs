using Microsoft.AspNetCore.Identity;

//This model will manage my Users of the App - i will use Identity user tool to set authorization for the dff type of users within my app -DB Context. 
//https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=visual-studio
namespace CrystalClearRecruitment_FinalProject.Models
{ 
    //Identity user acts as my PK
    public class AppUsers : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
