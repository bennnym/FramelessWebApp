using System.Collections.Generic;
using System.Linq;
using Myob.Fma.BookingLibrary.ResourceManagement;
using Myob.Fma.BookingLibrary.Resources;
using Newtonsoft.Json;

namespace FrameworklessApp.APIResponseFactory.GETResponses
{
    public class OneOrMoreBoardgamesResponse : IApiGetResponse
    {
        public string GetData(IEnumerable<string> stringParams)
        {
            var boardgamesData = new List<IResource>();

            var resourceIds = stringParams.Skip(1);

            foreach (var id in resourceIds)
            {
                var resourceId = int.Parse(id);
                boardgamesData.Add(ResourceManager.Instance.GetResource(resourceId));
            }

            return JsonConvert.SerializeObject(boardgamesData);
        }
    }
}