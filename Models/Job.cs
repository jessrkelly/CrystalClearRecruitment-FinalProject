using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrystalClearRecruitment_FinalProject.Models
{
    //Job Model will handel all info of Jobs - ID, Job Title, Salary etc. 
    //It will then handle a User that will be associated with the creation of the job.It will also hold nav for the Job seekers who may apply for a Job.
    public class Job
    {
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

        [NotMapped]
        public string CVStatus { get; set; }    

      //Ref to my category and job seekers 
        public List<JobSeekers>? jobSeekers { get; set; }
        public Category categories { get; set; }
     


    }
}
