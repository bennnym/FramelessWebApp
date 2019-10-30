using System.Collections.Generic;
using Myob.Fma.BookingLibrary.ResourceManagement;
using Newtonsoft.Json;

namespace FrameworklessApp.APIResponseFactory.GETResponses
{
    public class AllBooksResponse : IApiGetResponse
    {
        public string GetData(IEnumerable<string> stringParams)
        {
            var allBookResources = ResourceManager.Instance.GetAllBooks();
            return JsonConvert.SerializeObject(allBookResources);
        }
    }
}