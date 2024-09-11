namespace CrystalClearRecruitment_FinalProject.ViewModel
{
    //This model will enable the user to view jobs by title or location. I put it in this folder as its a model but also a view for a feature on my app. I found nming the folders like so helped me
    //to plan and plot what nneds to be where.
    public class SeekViewModel
    {
        public string Title { get; set; }
        public string CityCountry { get; set; }
    }
}
