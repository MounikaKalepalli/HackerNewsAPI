﻿namespace HackerNewsStoriesAPI.Models
{
    public class HackerNews
    {
        public string by { get; set; }

        public int descendants { get; set; }
        public long id { get; set; }

        public int[] kids { get; set; }

        public int score { get; set; }

        public long time { get; set; }

        public string title { get; set; }

        public string type {  get; set; }

        public string url { get; set; }

    }
}
