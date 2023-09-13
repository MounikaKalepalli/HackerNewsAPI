using HackerNewsStoriesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Tasks;

namespace HackerNewsStoriesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HackerNewsController : ControllerBase
    {

        //contains all stories id
        public string beststoriesURL = "https://hacker-news.firebaseio.com/v0/beststories.json";

        //url for individual story item
        public string storyItemURL = "https://hacker-news.firebaseio.com/v0/item";


        [HttpGet(Name = "GetStoriesFromHackerNewsApi")]
        public async Task<IEnumerable<HackerNews>> GetBestStories(int n)
        {
            List<HackerNews> lstBestStories = new List<HackerNews>();
            await Task.Run(()=>
          {
            //Reading data from url using webclient

            using(WebClient wc=new WebClient())
            {
                int[] arrBestStoriesId = JsonSerializer.Deserialize<int[]>(wc.DownloadString(beststoriesURL));

                if(arrBestStoriesId!=null && arrBestStoriesId.Length>0)
                {
                    foreach(var storyId in arrBestStoriesId)
                    {
                        string formattedStoryItemUrl = string.Format("{0}/{1}.json", storyItemURL, storyId);
                        HackerNews? _hackerNews=JsonSerializer.Deserialize<HackerNews>(wc.DownloadString(formattedStoryItemUrl.ToString()));

                        if(_hackerNews!=null)
                        {
                            lstBestStories?.Add(_hackerNews);
                        }
                    }
                }
            }


        });

             var nBestStories = lstBestStories.OrderByDescending(x => x.score).Take(n);
              return nBestStories;




        }
    }
}