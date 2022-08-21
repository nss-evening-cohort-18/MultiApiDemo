using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MultiApiDemoLibrary;

namespace MutliApiDemoLibrary;

public class SunProcessor
{
    public static async Task<SunModel> LoadSunInformation(int comicNumber = 0)
    {
        string url = "http://api.sunrise-sunset.org/json?lat=35.7808561097964&lng=-86.90011240252441&date=today";

        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                SunResultModel result = await response.Content.ReadAsAsync<SunResultModel>();

                return result.Results;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
