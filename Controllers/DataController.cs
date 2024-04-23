using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace YourProjectName.Controllers
{
    public class DataController : Controller
    {
        // Action to display all data
        public IActionResult Index()
        {
            // Parse CSV data for likes, visitors, and comments
            var likesCSV = @"LikeDislikeID,VisitorID,PageURL,Action,Timestamp
                             1,2,https://blog.com/post1,Like,19-04-2024 09:10
                             2,3,https://blog.com/post1,Like,19-04-2024 10:10
                             3,4,https://blog.com/post2,Like,19-04-2024 11:10
                             4,5,https://blog.com/post3,Like,19-04-2024 12:10
                             5,6,https://blog.com/post4,Like,19-04-2024 13:10
                             6,7,https://blog.com/post5,Like,19-04-2024 14:10
                             7,8,https://blog.com/post6,Like,19-04-2024 15:10";

            var visitorsCSV = @"VisitorID,Name,Email,Timestamp,Age,Gender,Location
                                1,John,john@example.com,19-04-2024 08:00,30,Male,New York
                                2,Mary,mary@example.com,19-04-2024 09:00,25,Female,Los Angeles
                                3,Alice,alice@example.com,19-04-2024 10:00,35,Female,Chicago
                                4,Bob,bob@example.com,19-04-2024 11:00,28,Male,Houston
                                5,Emma,emma@example.com,19-04-2024 12:00,40,Female,San Francisco
                                6,James,james@example.com,19-04-2024 13:00,45,Male,Miami
                                7,Lily,lily@example.com,19-04-2024 14:00,22,Female,Seattle";

            var commentsCSV = @"CommentID,VisitorID,PageURL,CommentText,Timestamp
                                1,1,https://blog.com/post1,Great tips! Can't wait to try them out,19-04-2024 08:05
                                2,2,https://blog.com/post1,Thanks for the helpful tips!,19-04-2024 09:05
                                3,3,https://blog.com/post2,Interesting article!,19-04-2024 10:05";

            // Parse CSV data into dictionaries
            var likes = ParseCSV(likesCSV);
            var visitors = ParseCSV(visitorsCSV);
            var comments = ParseCSV(commentsCSV);

            // Pass all data to the view
            ViewData["Likes"] = likes;
            ViewData["Visitors"] = visitors;
            ViewData["Comments"] = comments;

            return View();
        }

        // Method to parse CSV data into a list of dictionaries
        private List<Dictionary<string, string>> ParseCSV(string csvData)
        {
            var lines = csvData.Trim().Split('\n').Select(line => line.Trim()).ToList();
            var headers = lines.First().Split(',').Select(header => header.Trim()).ToList();

            var data = new List<Dictionary<string, string>>();

            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(',').Select(value => value.Trim()).ToList();
                var rowData = new Dictionary<string, string>();

                for (int i = 0; i < headers.Count; i++)
                {
                    rowData.Add(headers[i], values[i]);
                }

                data.Add(rowData);
            }

            return data;
        }
    }
}
