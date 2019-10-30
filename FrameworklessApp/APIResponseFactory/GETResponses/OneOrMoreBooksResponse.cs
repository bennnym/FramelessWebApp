using System.Collections.Generic;
using System.Linq;
using Myob.Fma.BookingLibrary.ResourceManagement;
using Myob.Fma.BookingLibrary.Resources;
using Newtonsoft.Json;

namespace FrameworklessApp.APIResponseFactory.GETResponses
{
    public class OneOrMoreBooksResponse : IApiGetResponse
    {
        public string GetData(IEnumerable<string> stringParams)
        {
            var booksData = new List<IResource>();

            var resourceIds = stringParams.Skip(1);

            foreach (var id in resourceIds)
            {
                var resourceId = int.Parse(id);
                booksData.Add(ResourceManager.Instance.GetResource(resourceId));
            }

            return JsonConvert.SerializeObject(booksData);
        }
    }
}