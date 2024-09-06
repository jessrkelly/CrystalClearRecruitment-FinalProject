using CrystalClearRecruitment_FinalProject.Models;

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
