using System.Linq;
using FrameworklessApp.APIResponseFactory.DELETEResponses;
using FrameworklessApp.APIResponseFactory.GETResponses;

namespace FrameworklessApp.APIResponseFactory
{
    public static class ApiDeleteResponseFactory
    {
        public static IApiDeleteResponse GetDeleteResponseObject(string methodName, string[] stringParams)
        {
            if (MembershipRoute(methodName, stringParams))
            {
                return new DeletedMemberResponse();
            }

            if (ResourceRoute(methodName, stringParams))
            {
                return new DeletedResourceResponse();
            }

            return new InvalidRequest();
        }

        private static bool MembershipRoute(string methodName, string[] stringParams)
        {
            return methodName == "memberships" && stringParams.Any();
        }

        private static bool ResourceRoute(string methodName, string[] stringParams)
        {
            return methodName == "resources" && stringParams.Any();
        }
    }
}