using System.Collections.Generic;

namespace FrameworklessApp.APIResponseFactory.GETResponses
{
    public interface IApiGetResponse
    {
        string GetData(IEnumerable<string> stringParams = null);
    }
}