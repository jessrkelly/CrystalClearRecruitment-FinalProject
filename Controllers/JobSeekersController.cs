using CrystalClearRecruitment_FinalProject.Models;
using CrystalClearRecruitment_FinalProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

//This model will handle all the JobSeeker interactions (Adding Cv, CU Profile, saving cv to my root folder)
//Added in later in project the feature to GetProfile for an admin when viewing the applications.

namespace CrystalClearRecruitment_FinalProject.Controllers
{
    [Authorize]
    public class JobSeekersController : Controller
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        private IProfileRepository _profileRepository;
        UserManager<AppUsers> _appUser;
        public JobSeekersController(ApplicationDbContext db, UserManager<AppUsers> appUser, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _profileRepository = new ProfileRepository(db);
            _environment = environment;
            _appUser = appUser;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile(string id)
        {
            string usr = "";
            if (id == null)
            {
                usr = User.Identity.Name;
            }
            else
            {
                usr = id;
            }

            var data = _profileRepository.GetProfile(usr);
            if (data == null)
            {
                return View();
            }
            else
            {
                return View(data);
            }
        }

        //ADDED IN to get the profile
        [HttpGet]
        public IActionResult GetProfile(int id)
        {
            var jobSeeker = _profileRepository.GetProfileById(id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            return PartialView("_ProfileDetails", jobSeeker);
        }


        [HttpPost]
        public IActionResult ProfilePOST(JobSeekers model)
        {
            string LocalPath = "";
            string fileName = Guid.NewGuid().ToString();
            string wwwRootPath = _environment.WebRootPath;
            var uploads = Path.Combine(wwwRootPath, @"Images");

            IFormFile profileImage = Request.Form.Files["profileImage"];

            IFormFile CVPath = Request.Form.Files["CVPath"];


            if (profileImage != null)
            {
                var extension = Path.GetExtension(profileImage.FileName);


                LocalPath = "images\\" + fileName + extension;

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    profileImage.CopyTo(fileStreams);
                }

                model.profileImage = LocalPath;
            }

            //CV
            fileName = Guid.NewGuid().ToString();

            wwwRootPath = _environment.WebRootPath;
            uploads = Path.Combine(wwwRootPath, @"cvs");

            if (CVPath != null)
            {
                var extension = Path.GetExtension(CVPath.FileName);


                LocalPath = "cvs\\" + fileName + extension;

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    CVPath.CopyTo(fileStreams);
                }

                model.CVPath = LocalPath;
            }

            AppUsers user = _appUser.GetUserAsync(User).Result;
            var data = _profileRepository.GetProfile(User.Identity.Name);
            model.appUsersId = user.Id;
            if (data == null)
            {
                _profileRepository.Add(model);
            }
            else
            {
                _profileRepository.Update(model);
            }
            _profileRepository.Save();

            return RedirectToAction("Profile");
        }
    }
}
