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
    public static async Task<SunModel> LoadSunInformation(string latitude, string longitude)
    {
        string url = $"http://api.sunrise-sunset.org/json?lat={latitude}&lng={longitude}&date=today";

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
