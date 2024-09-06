using CrystalClearRecruitment_FinalProject.Models;

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
