using HotelProject.WebUI.Areas.Admin.Models.SocialMediaFollowers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static HotelProject.WebUI.Areas.Admin.Models.SocialMediaFollowers.InstagramFollowersVM;
using static HotelProject.WebUI.Areas.Admin.Models.SocialMediaFollowers.LinkedInFollowerVM;
using static HotelProject.WebUI.Areas.Admin.Models.SocialMediaFollowers.TwitterFollowersVM;

namespace HotelProject.WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class _DashboardFollowersViewPartial : ViewComponent
    {
        private async Task InstagramFollowers()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-scraper-api2.p.rapidapi.com/v1/info?username_or_id_or_url=emir_clrglr"),
                Headers =
                {
                    { "x-rapidapi-key", "c18ad4d8admsha7a40cbcaf75333p13586ajsn799e01380ceb" },
                    { "x-rapidapi-host", "instagram-scraper-api2.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var rootObject = JsonConvert.DeserializeObject<InstagramRootobject>(body);
                ViewBag.InstagramFollowers = rootObject.data.follower_count;
                ViewBag.InstagramFollowing = rootObject.data.following_count;
            }

        }

        private async Task TwitterFollowers()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter-api45.p.rapidapi.com/screenname.php?screenname=eXoDiEnn&rest_id=1156660827451248646"),
                Headers =
                {
                    { "x-rapidapi-key", "c18ad4d8admsha7a40cbcaf75333p13586ajsn799e01380ceb" },
                    { "x-rapidapi-host", "twitter-api45.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TwitterFollowersVM>(body);
                ViewBag.TwitterFollowers = values.sub_count;
                ViewBag.TwitterFollowings = values.friends;
            }
        }

        private async Task LinkedInFollowers()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fmuratyucedag%2F&include_skills=false&include_certifications=false&include_publications=false&include_honors=false&include_volunteers=false&include_projects=false&include_patents=false&include_courses=false&include_organizations=false&include_profile_status=false&include_company_public_url=false"),
                Headers =
                {
                    { "x-rapidapi-key", "c18ad4d8admsha7a40cbcaf75333p13586ajsn799e01380ceb" },
                    { "x-rapidapi-host", "fresh-linkedin-profile-data.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var rootObject = JsonConvert.DeserializeObject<LinkedInRootobject>(body);
                var followerCount = rootObject.data.follower_count;
                ViewBag.LinkedInFollowers = followerCount;
            }
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await TwitterFollowers();
            await InstagramFollowers();
            await LinkedInFollowers();
            return View();
        }
    }
}
