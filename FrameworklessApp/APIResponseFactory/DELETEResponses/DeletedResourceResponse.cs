using System.Collections.Generic;
using System.Linq;
using Myob.Fma.BookingLibrary.ResourceManagement;
using Newtonsoft.Json;

namespace FrameworklessApp.APIResponseFactory.DELETEResponses
{
    public class DeletedResourceResponse : IApiDeleteResponse
    {
        public string DeleteRecord(IEnumerable<string> stringParams)
        {
            var resourceId = int.Parse(stringParams.First());
            var resourceToDelete = ResourceManager.Instance.GetResource(resourceId);
            ResourceManager.Instance.RemoveResourceFromInventory(resourceToDelete);

            return JsonConvert.SerializeObject(resourceToDelete);
        }
    }
}