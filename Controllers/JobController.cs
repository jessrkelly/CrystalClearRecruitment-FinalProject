
using CrystalClearRecruitment_FinalProject.Models;
using CrystalClearRecruitment_FinalProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

//This controllor manages all the Job aspects (Job,Category, Job search - CRUD actions). It will retrieve the views for the different requests made.
namespace CrystalClearRecruitment_FinalProject.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        private IJobRepository _jobRepository;
        private ICategoryRespository _categoryRespository;
        private IProfileRepository _profileRepository;
        public JobsController(ApplicationDbContext db)
        {
            _jobRepository = new JobRepository(db);
            _categoryRespository = new CategoryRespository(db);
            _profileRepository = new ProfileRepository(db);
        }
        public IActionResult Index()
        {
            var data = _jobRepository.GetAll(User.Identity.Name);

            return View(data);
        }

        public IActionResult Category()
        {
            var data = _jobRepository.GetCategories();
            return View(data);
        }

        public IActionResult Addcategory()
        {
            return View();
        }
        public IActionResult AddcategoryPOST(Category model)
        {
            _categoryRespository.Add(model);
            _categoryRespository.Save();
            return RedirectToAction("Category");
        }
        public IActionResult CategoryDelete(int id)
        {
            _categoryRespository.CategoryDelete(id);
            _categoryRespository.Save();
            return RedirectToAction("Category");
            ;
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Category = _categoryRespository.GetAll();
            var data = _jobRepository.GetbyJobID(id);
            ViewBag.action = "EditPOST";
            return View("AddEdit", data);
        }

        [HttpPost]
        public IActionResult EditPOST(Job model)
        {
            _jobRepository.Update(model);
            _jobRepository.Save();

            return RedirectToAction("index");
        }


        public IActionResult Delete(int id)
        {
            _jobRepository.Delete(id);
            _jobRepository.Save();

            return RedirectToAction("index");
        }

        public IActionResult Mycvs()
        {
            var data = _jobRepository.GetAppliedJobsbyUser(User.Identity.Name);

            return View(data);
        }

        public IActionResult CVApproveDecline(int jobid, int appid, int jsid)
        {
            _jobRepository.CVApproveDecline(jobid, appid, jsid);
            _jobRepository.Save();
            return RedirectToAction("Applications", new { jobid = jobid });
        }
        public IActionResult ApproveDecline(int id, int App)
        {

            var data = _jobRepository.GetbyJobID(id);
            data.Status = App;

            _jobRepository.Update(data);
            _jobRepository.Save();

            return RedirectToAction("index");
        }
        public IActionResult Search(int id)
        {

            return View("Search");
        }

        [AllowAnonymous]
        public IActionResult Seek()
        {
            var data = _jobRepository.GetAllActiveJobs();
            return View(data);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Jobcvs()
        {
            var data = _jobRepository.GetAppliedJobs();
            return View(data);
        }

        public IActionResult Applications(int jobid)
        {

            var data = _jobRepository.GetApplicationsbyJobs(jobid);

            return View("applications", data);
        }

        public IActionResult Apply(int jobid)
        {
            var username = User.Identity.Name;

            var js = _profileRepository.GetProfile(User.Identity.Name);
            if (js == null)
            {
                return RedirectToAction("Profile", "jobseekers");
            }
            _jobRepository.Apply(jobid, username);
            _jobRepository.Save();
            return RedirectToAction("seek");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SeekPOST()
        {
            string title = Request.Form["Title"];
            string city = Request.Form["City"];
            var data = _jobRepository.GetAllbyCityCountry(title, city);
            return View("seek", data);
        }

        [AllowAnonymous]
        public IActionResult View(int jobid)
        {
            ViewBag.Category = _categoryRespository.GetAll();
            var data = _jobRepository.GetbyJobID(jobid);
            ViewBag.view = "true";
            return View("AddEdit", data);
        }
        public IActionResult Add()
        {
            ViewBag.action = "AddPOST";
            ViewBag.Category = _categoryRespository.GetAll();
            return View("AddEdit");
        }

        //If an admin posts a job only cn be seen on their account. (Prevenint another admin from CRUD that poost)
        [HttpPost]
        public IActionResult AddPOST(Job model)
        {
            model.Status = 0;
            model.AddUser = User.Identity.Name;

            model.Status = 1;
            _jobRepository.Add(model);
            _jobRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
