using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DLPCodeCreater
{
    internal class DroneHelper
    {
        string droneUrl = "http://172.20.10.105:9000/";
        string namespaceName = "repos/root/";
        string token = "7VWX7msgMvyd0IFwLre21d8joeAw9vCW";


        async public void getLastStatuse()
        {
            using (HttpClient client = new HttpClient())
            {
                // 設置 Authorization 標頭
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // 發送 GET 請求獲取構建狀態
                string apiUrl = droneUrl + "api/" + namespaceName + "builds";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // 解析回應內容
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JArray builds = JArray.Parse(responseBody);

                    // 取得最新的一次構建
                    if (builds.Count > 0)
                    {
                        var latestBuild = builds[0];
                        Console.WriteLine("Latest Build Status: " + latestBuild["status"]);
                        Console.WriteLine("Build Number: " + latestBuild["number"]);
                        Console.WriteLine("Commit: " + latestBuild["commit"]);
                        Console.WriteLine("Branch: " + latestBuild["branch"]);
                        Console.WriteLine("Started At: " + latestBuild["started_at"]);
                    }
                    else
                    {
                        Console.WriteLine("No builds found for this repository.");
                    }
                }
                else
                {
                    // 顯示錯誤訊息
                    Console.WriteLine($"Error: {response.StatusCode}, {response.ReasonPhrase}");
                }
            }
        }
    }
}
