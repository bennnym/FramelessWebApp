using System.Collections.Generic;
using Myob.Fma.BookingLibrary.MembershipManagement;
using Newtonsoft.Json;

namespace FrameworklessApp.APIResponseFactory.GETResponses
{
    public class AllMembersResponse : IApiGetResponse
    {
        public string GetData(IEnumerable<string> stringParams = null)
        {
            return JsonConvert.SerializeObject(MembershipManager.Instance.GetAllMemberships());
        }
    }
}