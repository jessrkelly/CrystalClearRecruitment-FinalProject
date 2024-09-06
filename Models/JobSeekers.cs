using System.ComponentModel.DataAnnotations.Schema;

namespace CrystalClearRecruitment_FinalProject.Models
//Will hold all info about Job seekers info to create a profile - name, address, CV upload, profile pic. I am going to follow a similar approach to a mini linkedin profile here. 
//The Job seeker cann upload their most up to date CV meaning others can view this once they apply for a job. It also means the job seeker doesn't have to upload a CV every time
//they want to apply for  a job. This allows for ease to use if no access to desktop files etc to upload a CV - Mobile Frindly approach.

{
    public class JobSeekers
    {
        public int Id { get; set; }
        public string? profileImage { get; set; }
        public string appUsersId { get; set; }
        public AppUsers? appUsers { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string? CVPath { get; set; }
        public string Address { get; set; }
        public string? About { get; set; }

        public List<Job>? job { get; set; }

        [NotMapped]
        public string CVStatus { get; set; }


    }
}
