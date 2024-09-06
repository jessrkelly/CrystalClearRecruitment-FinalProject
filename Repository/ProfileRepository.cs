using CrystalClearRecruitment_FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CrystalClearRecruitment_FinalProject.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        ApplicationDbContext _db;
        public ProfileRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(JobSeekers model)
        {
            _db.Add(model);
        }

        public JobSeekers GetProfile(string user)
        {
            return _db.jobSeekers.Include(x => x.appUsers).Where(x => x.appUsers.UserName == user).AsNoTracking().FirstOrDefault();
        }

        //Added this now based off the iprofile 
        public JobSeekers GetProfileById(int id)
        {
            return _db.jobSeekers.Include(x => x.appUsers).FirstOrDefault(x => x.Id == id);
        }


        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(JobSeekers model)
        {
            _db.jobSeekers.Update(model);
        }
    }
}
