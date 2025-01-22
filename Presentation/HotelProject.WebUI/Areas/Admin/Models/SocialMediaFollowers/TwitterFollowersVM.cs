namespace HotelProject.WebUI.Areas.Admin.Models.SocialMediaFollowers
{
    public class TwitterFollowersVM
    {
        public string status { get; set; }
        public string profile { get; set; }
        public string rest_id { get; set; }
        public object blue_verified { get; set; }
        public object[] affiliates { get; set; }
        public object business_account { get; set; }
        public string avatar { get; set; }
        public string header_image { get; set; }
        public string desc { get; set; }
        public string name { get; set; }
        public bool _protected { get; set; }
        public string location { get; set; }
        public int friends { get; set; }
        public int sub_count { get; set; }
        public int statuses_count { get; set; }
        public int media_count { get; set; }
        public object[] pinned_tweet_ids_str { get; set; }
        public string created_at { get; set; }
        public string id { get; set; }
    }
}
