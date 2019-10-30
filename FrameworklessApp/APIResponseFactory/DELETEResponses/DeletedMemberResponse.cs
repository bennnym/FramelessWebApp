using System.Collections.Generic;
using Myob.Fma.BookingLibrary.MembershipManagement;

namespace FrameworklessApp.APIResponseFactory.DELETEResponses
{
    public class DeletedMemberResponse : IApiDeleteResponse
    {
        public string DeleteRecord(IEnumerable<string> stringParams)
        {
            foreach (var id in stringParams)
            {
                var membershipId = int.Parse(id);
                var membership = MembershipManager.Instance.GetMembership(membershipId);
                MembershipManager.Instance.RemoveMembership(membership);
            }
            return "Successfully Deleted";
        }
    }
}