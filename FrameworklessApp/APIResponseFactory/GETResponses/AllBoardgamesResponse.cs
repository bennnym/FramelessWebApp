using System.Collections.Generic;
using Myob.Fma.BookingLibrary.ResourceManagement;
using Newtonsoft.Json;

namespace FrameworklessApp.APIResponseFactory.GETResponses
{
    public class AllBoardgamesResponse : IApiGetResponse
    {
        public string GetData(IEnumerable<string> stringParams)
        {
            var allBoardgamesResources = ResourceManager.Instance.GetAllBoardGames();
            return JsonConvert.SerializeObject(allBoardgamesResources);
        }
    }
}