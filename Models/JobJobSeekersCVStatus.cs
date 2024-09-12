namespace CrystalClearRecruitment_FinalProject.Models
{
    //Will handle the CV status
    //Name shows the link between js and Cvstat models
    public class JobJobSeekersCVStatus
    {
        //PK
        public int Id { get; set; }
        public int jobId { get; set; }
        public int jobSeekersId { get; set; }
        //?? to use
        public int cVStatusesId { get; set; }
    }
}
