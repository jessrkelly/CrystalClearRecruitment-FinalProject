using CrystalClearRecruitment_FinalProject.Models;
using Microsoft.EntityFrameworkCore;
//Unlike Job Controller the job repo will interact with the requests (same as J cont) but will interact with my DB as opposed to views. 
namespace CrystalClearRecruitment_FinalProject.Repository
{
    public class JobRepository : IJobRepository
    {
        private ApplicationDbContext _db;
        public JobRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Job model)
        {
            model.PostedDate = DateTime.Now;
            _db.Add(model);
        }

        public void Apply(int jobid, string user)
        {
            var userid = _db.Users.Where(x => x.UserName == user).FirstOrDefault().Id;
            var jsid = _db.jobSeekers.Where(x => x.appUsersId == userid).FirstOrDefault().Id;

            List<JobSeekers> jsl = new List<JobSeekers>();
            var job = _db.job.Find(jobid);

            var js = _db.jobSeekers.Find(jsid);
            jsl.Add(js);

            job.jobSeekers = jsl;
            _db.job.Update(job);
            CVApproveDecline(jobid, 1, jsid);

        }

        public void CVApproveDecline(int jobid, int appid, int jsid)
        {

            var data = new JobJobSeekersCVStatus
            {
                jobId = jobid,
                cVStatusesId = appid,
                jobSeekersId = jsid,
            };

            if (_db.jobJobSeekersCVStatuses.Where(x => x.jobId == jobid && x.jobSeekersId == jsid).Count() > 0)
            {
                _db.jobJobSeekersCVStatuses.Remove(_db.jobJobSeekersCVStatuses.Where(x => x.jobId == jobid && x.jobSeekersId == jsid).FirstOrDefault());
            }
            _db.Add(data);
        }

        public void Delete(int JobID)
        {
            _db.job.Remove(_db.job.Find(JobID));


        }

        public List<Job> GetAll(string user)
        {
            return _db.job.Where(x => x.AddUser == user).ToList();
        }

        public List<Job> GetAll()
        {
            return _db.job.Include(x => x.categories).Include(x => x.jobSeekers).ToList();
        }

        public List<Job> GetAllActiveJobs()
        {
            var sss = _db.jobSeekers.Include(x => x.appUsers).FirstOrDefault();
            return _db.job.Include(x => x.categories).Include(x => x.jobSeekers).ThenInclude(y => y.appUsers).Where(x => x.Status == 1).ToList();


        }

        public List<Job> GetAllbyCityCountry(string Title, string City)
        {
            if (City.Trim() != "" || Title.Trim() != "")
            {
                if (Title.Trim() == "")
                {
                    Title = "&667hansnaa...";
                }

                if (City.Trim() == "")
                {
                    City = "sdd4454365(*&^%$%";
                }
            }
            return _db.job.Include(x => x.categories).Include(x => x.jobSeekers).ThenInclude(x => x.appUsers).Where(x => x.Status == 1 && (x.City.Contains(City) || x.Country.Contains(City) || x.JobTitle.Contains(Title))).ToList();

        }

        public Job GetApplicationsbyJobs(int jobid)
        {
            var data = _db.job.Include(x => x.jobSeekers).ThenInclude(x => x.appUsers).Include(x => x.categories).Where(x => x.JobId == jobid).AsQueryable().FirstOrDefault();

            var data2 = (from d1 in data.jobSeekers

                         join jjsc in _db.jobJobSeekersCVStatuses on d1.Id equals jjsc.jobSeekersId into temp

                         from jjsc1 in temp.DefaultIfEmpty()
                         join aa in _db.cVStatuscs on jjsc1.cVStatusesId equals aa.Id
                         where jjsc1.jobId == jobid
                         select new JobSeekers
                         {
                             appUsers = d1.appUsers,
                             appUsersId = d1.appUsersId,
                             About = d1.About,
                             Address = d1.Address,
                             ContactNo = d1.ContactNo,
                             CVPath = d1.CVPath,
                             CVStatus = aa.Name,
                             Email = d1.Email,
                             FirstName = d1.FirstName,

                             Id = d1.Id,
                             job = d1.job,
                             LastName = d1.LastName,
                             profileImage = d1.profileImage,
                         }).ToList();


            data.jobSeekers = data2;


            return data;
        }

        public List<Job> GetAppliedJobs()
        {
            return _db.job.Include(x => x.categories).Include(x => x.jobSeekers).ThenInclude(y => y.appUsers).Where(x => x.jobSeekers.Count() > 0).ToList();

        }

        public List<JobSeekers> GetAppliedJobsbyUser(string user)
        {

            List<JobSeekers> js = new List<JobSeekers>();


            var data = _db.jobSeekers.Where(x => x.appUsers.UserName == user).Include(c => c.job).ThenInclude(x => x.categories).Include(y => y.appUsers).ToList();


            foreach (var d1 in data)
            {
                foreach (var obj2 in d1.job)
                {
                    var status = _db.jobJobSeekersCVStatuses.Where(x => x.jobSeekersId == d1.Id && x.jobId == obj2.JobId).AsQueryable();

                    var data3 = (from d2 in status
                                 join b in _db.cVStatuscs on d2.cVStatusesId equals b.Id
                                 select new JobSeekers
                                 {
                                     appUsers = d1.appUsers,
                                     appUsersId = d1.appUsersId,
                                     About = d1.About,
                                     Address = d1.Address,
                                     ContactNo = d1.ContactNo,
                                     CVPath = d1.CVPath,
                                     CVStatus = b.Name,
                                     Email = d1.Email,
                                     FirstName = d1.FirstName,

                                     Id = d1.Id,
                                     job = _db.job.Where(x => x.JobId == obj2.JobId).ToList(),
                                     LastName = d1.LastName,
                                     profileImage = d1.profileImage,
                                 }).FirstOrDefault();

                    js.Add(data3);
                }
            }

            //var data2 = (from d1 in data

            //             join jjsc in _db.jobJobSeekersCVStatuses on d1.Id equals jjsc.jobSeekersId


            //             join aa in _db.cVStatuscs on jjsc2.cVStatusesId equals aa.Id

            //             select new JobSeekers
            //             {
            //                 appUsers = d1.appUsers,
            //                 appUsersId = d1.appUsersId,
            //                 About = d1.About,
            //                 Address = d1.Address,
            //                 ContactNo = d1.ContactNo,
            //                 CVPath = d1.CVPath,
            //                 CVStatus = aa.Name,
            //                 Email = d1.Email,
            //                 FirstName = d1.FirstName,

            //                 Id = d1.Id,
            //                 job = d1.job,
            //                 LastName = d1.LastName,
            //                 profileImage = d1.profileImage,
            //             }).ToList();

            return js;

        }

        public Job GetbyJobID(int JobId)
        {
            return _db.job.Find(JobId);
        }

        public List<Category> GetCategories()
        {
            return _db.categories.ToList();
        }

        public Category GetCategories(int id)
        {
            return _db.categories.Where(x => x.CategoryId == id).FirstOrDefault();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Job model)
        {
            _db.Update(model);
        }
    }
}
