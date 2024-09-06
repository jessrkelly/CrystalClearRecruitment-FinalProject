using CrystalClearRecruitment_FinalProject.Models;

namespace CrystalClearRecruitment_FinalProject.Repository
{
    public class CategoryRespository : ICategoryRespository
    {
        private ApplicationDbContext _db;
        public CategoryRespository(ApplicationDbContext db)
        {

            _db = db;

        }

        public void Add(Category model)
        {
            _db.Add(model);
        }

        public void CategoryDelete(int id)
        {
            _db.categories.Remove(_db.categories.Where(x => x.CategoryId == id).FirstOrDefault());
        }

        public List<Category> GetAll()
        {

            return _db.categories.ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
