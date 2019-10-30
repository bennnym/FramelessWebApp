using System.Collections.Generic;
using Myob.Fma.BookingLibrary.MembershipManagement;
using Newtonsoft.Json;

namespace FrameworklessApp.APIResponseFactory.GETResponses
{
    public class OneOrMoreMembersResponse : IApiGetResponse
    {
        public string GetData(IEnumerable<string> stringParams)
        {
            var responseData = string.Empty;

            foreach (var id in stringParams)
            {
                var membershipId = int.Parse(id);
                responseData += JsonConvert.SerializeObject(MembershipManager.Instance.GetMembership(membershipId));
            }

            return responseData;
        }
    }
}