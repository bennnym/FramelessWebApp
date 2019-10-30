using Myob.Fma.BookingLibrary.MembershipManagement;
using Myob.Fma.BookingLibrary.Memberships;
using Newtonsoft.Json;

namespace FrameworklessApp.APIResponseFactory.POSTResponses
{
    public class AddMembersResponse : IApiPostResponse
    {
        public void PostToDataBase(string requestBody)
        {
            var newMember = JsonConvert.DeserializeObject<Membership>(requestBody);
            MembershipManager.Instance.AddMembership(newMember);
        }
    }
}