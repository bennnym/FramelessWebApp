using System.Collections.Generic;
using System.Linq;
using FrameworklessApp.APIResponseFactory.POSTResponses;

namespace FrameworklessApp.APIResponseFactory
{
    public static class ApiPostResponseFactory
    {
        public static IApiPostResponse GetPostResponseObject(string methodName, string[] stringParams)
        {
            if (NewMembershipRoute(methodName, stringParams))
            {
                return new AddMembersResponse();
            }

            return new AddMembersResponse();
        }

        private static bool NewMembershipRoute(string methodName, IEnumerable<string> stringParams)
        {
            return methodName == "memberships" && stringParams.Any();
        }
    }
}