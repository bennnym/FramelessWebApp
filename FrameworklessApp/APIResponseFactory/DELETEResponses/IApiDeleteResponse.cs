using System.Collections.Generic;

namespace FrameworklessApp.APIResponseFactory.DELETEResponses
{
    public interface IApiDeleteResponse
    {
        string DeleteRecord(IEnumerable<string> stringParams);
    }
}