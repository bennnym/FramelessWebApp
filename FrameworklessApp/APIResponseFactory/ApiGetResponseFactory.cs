using System.Linq;
using System.Resources;
using FrameworklessApp.APIResponseFactory.GETResponses;


namespace FrameworklessApp.APIResponseFactory
{
    public static class ApiGetResponseFactory
    {
        public static IApiGetResponse GetResponseObject(string methodName, string[] stringParams)
        {
            if (AllMembersRoute(methodName, stringParams))
            {
                return new AllMembersResponse();
            }
            if (SpecificMembersRoute(methodName, stringParams))
            {
                return new OneOrMoreMembersResponse();
            }
            if (AllResourcesRoute(methodName, stringParams))
            {
                return new AllResourcesResponse();
            }
            if (AllBooksRoute(methodName, stringParams))
            {
                return new AllBooksResponse();
            }
            if (OneOrMoreBooksRoute(methodName, stringParams))
            {
                return new OneOrMoreBooksResponse();
            }
            if (AllBoardGamesRoute(methodName, stringParams))
            {
                return new AllBoardgamesResponse();
            }
            if (OneOrMoreBoardgamesRoute(methodName, stringParams))
            {
                return new OneOrMoreBoardgamesResponse();
            }
            return new InvalidRequest();
        }

        private static bool AllMembersRoute(string methodName, string[] stringParams)
        {
            return methodName == "memberships" && !stringParams.Any();
        }

        private static bool SpecificMembersRoute(string methodName, string[] stringParams)
        {
            return methodName == "memberships" && stringParams.Any();
        }

        private static bool AllResourcesRoute(string methodName, string[] stringParams)
        {
            return methodName == "resources" && !stringParams.Any();
        }

        private static bool AllBooksRoute(string methodName, string[] stringParams)
        {
            return methodName == "resources" && stringParams.Length == 1 && stringParams.First() == "books";
        }

        private static bool OneOrMoreBooksRoute(string methodName, string[] stringParams)
        {
            return methodName == "resources" && stringParams.Length > 1 && stringParams.First() == "books";
        }

        private static bool AllBoardGamesRoute(string methodName, string[] stringParams)
        {
            return methodName == "resources" && stringParams.Length == 1 && stringParams.First() == "boardgames";
        }

        private static bool OneOrMoreBoardgamesRoute(string methodName, string[] stringParams)
        {
            return methodName == "resources" && stringParams.Length > 1 && stringParams.First() == "boardgames";
        }
    }
}