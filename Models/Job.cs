using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrystalClearRecruitment_FinalProject.Models
{
    //Job Model will handel all info of Jobs - ID, Job Title, Salary etc. 
    //It will then handle a Admin that will be associated with the creation of that job.It will also hold nav for the Job seekers who may apply for a Job.
    //for example if there are two admins - the admin who added the job is the only one who can CRUD that added job
    public class Job
    {
        //PK
        public int JobId { get; set; }  
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }   
        public string ContactNo { get; set; }
        public string EmploymentType { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public int? Status { get; set; }
        public string? AddUser { get; set; }
        public int CategoryId { get; set; }
        public string City { get; set; }    
        public string Country { get; set; }
        public DateTime PostedDate { get; set; }

        //This isn't mapped because CV status will only apply if you have applied for job/if the application has been reviews/if a reponse from Admin
        //Therefore I felt it was uncessisary to store it within my DB
        [NotMapped]
        public string CVStatus { get; set; }    

      //Ref to my category and job seekers 
        public List<JobSeekers>? jobSeekers { get; set; }
        public Category categories { get; set; }
     


    }
}
