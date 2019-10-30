using System.Collections.Generic;
using FrameworklessApp.APIResponseFactory.DELETEResponses;
using FrameworklessApp.APIResponseFactory.POSTResponses;

namespace FrameworklessApp.APIResponseFactory.GETResponses
{
    public class InvalidRequest : IApiGetResponse, IApiDeleteResponse
    {
        public string GetData(IEnumerable<string> stringParams = null)
        {
            return "Invalid API Path";
        }

        public string DeleteRecord(IEnumerable<string> stringParams)
        {
            return "Invalid API Path";
        }
    }
}