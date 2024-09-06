using CrystalClearRecruitment_FinalProject.Models;

namespace CrystalClearRecruitment_FinalProject.Repository
{
    public interface IJobRepository
    {
        void Add(Job model);
        void Update(Job model);
        void Delete(int JobID);

        Job GetApplicationsbyJobs(int jobid);
        void Apply(int jobid, string user);
        List<Job> GetAll(string user);
        List<Job> GetAll();
        List<Job> GetAppliedJobs();
        List<JobSeekers> GetAppliedJobsbyUser(string user);
        List<Job> GetAllbyCityCountry(string Title, string City);
        List<Job> GetAllActiveJobs();
        void CVApproveDecline(int jobid, int appid, int jsid);
        Job GetbyJobID(int JobId);

        List<Category> GetCategouries();
        Category GetCategouries(int id);

        void Save();
    }
}
