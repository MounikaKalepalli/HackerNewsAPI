# HackerNewsAPI

Description: RESTful API to retrieve the details of the best 'n' stories from the HackerNews API, best stories are determined based on the score of the story.
             All Story Id's are available in https://hacker-news-ggirebaseio.com/v0/beststories.json
             The details of an individual story can be retrieved from the URI:  https://hacker-news-ggirebaseio.com/v0/id.json

How to install and run API: Install ASP.NET Core
                            Open the HackerNewsStoriesAPI.sln from the Project code folder.
                            Build the Solution
                            Execute the application 
                            Application 'GetBestStories' method will available to the Client/User.
                            Provide the value of 'n' and execute
                            Application should return an array of best 'n' stories as returned by the HackerNewsAPI in descending order of the score in json format.
