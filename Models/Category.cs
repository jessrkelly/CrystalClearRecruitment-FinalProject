
namespace CrystalClearRecruitment_FinalProject.Models
{
    //Cat ID and name 
    public class Category
    {
        //ID = PK
        public int CategoryId { get; set; }
        public string Name { get; set; }

        //I want to display as a single Category
        public static implicit operator Category(List<Category> v)
        {
            throw new NotImplementedException();
        }
    }
}


