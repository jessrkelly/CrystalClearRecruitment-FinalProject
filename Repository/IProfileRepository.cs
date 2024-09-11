using CrystalClearRecruitment_FinalProject.Models;

//With reference to my IProfilerep (allows to get profile,add,update and save)
namespace CrystalClearRecruitment_FinalProject.Repository
{
    public interface IProfileRepository
    {
        JobSeekers GetProfile(string user);
        void Add(JobSeekers model);
        void Update(JobSeekers model);
        void Save();

        //Added to try get the profile for the Admin viewing user applications
        JobSeekers GetProfileById(int id);
    }
}
