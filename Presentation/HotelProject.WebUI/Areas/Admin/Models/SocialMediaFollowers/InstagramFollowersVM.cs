namespace HotelProject.WebUI.Areas.Admin.Models.SocialMediaFollowers
{
    public class InstagramFollowersVM
    {

        public class InstagramRootobject
        {
            public Data data { get; set; }
        }

        public class Data
        {
            public int follower_count { get; set; }
            public int following_count { get; set; }
        }
    }
}
