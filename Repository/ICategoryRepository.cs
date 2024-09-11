using CrystalClearRecruitment_FinalProject.Models;
//Referal to CRUD of category

namespace CrystalClearRecruitment_FinalProject.Repository
{
    public interface ICategoryRespository
    {
        List<Category> GetAll();
        void CategoryDelete(int id);
        void Add(Category model);
        void Save();
    }
}
