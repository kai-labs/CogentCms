namespace CogentCms.Core.Auth
{
    public class AppUserData
    {
        public int AppUserId { get; set; }
        public string FullName { get; set; }
        public string IdProvider { get; set; }
        public string SubjectId { get; set; }
    }
}