using System.Collections.Generic;
using Myob.Fma.BookingLibrary.ResourceManagement;
using Newtonsoft.Json;

namespace FrameworklessApp.APIResponseFactory.GETResponses
{
    public class AllResourcesResponse : IApiGetResponse
    {
        public string GetData(IEnumerable<string> stringParams = null)
        {
            var allResources = ResourceManager.Instance.GetAllResources();
            return JsonConvert.SerializeObject(allResources);
        }
    }
}