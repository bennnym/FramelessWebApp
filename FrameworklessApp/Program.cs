using System;
using System.IO;
using System.Linq;
using System.Net;
using FrameworklessApp.APIResponseFactory;
using Myob.Fma.BookingLibrary.MembershipManagement;
using Myob.Fma.BookingLibrary.Memberships;
using Newtonsoft.Json;

namespace FrameworklessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new HttpListener();
            server.Prefixes.Add("http://localhost:8080/");
            server.Start();
            Console.WriteLine("Listening....");


            while (true)
            {
                var context = server.GetContext(); // Gets the request
                var request = context.Request;
                var response = context.Response;

                var apiRequestMethodName = request.Url.Segments[1].Replace("/", "");
                var stringParams = request.Url.Segments.Skip(2).Select(s => s.Replace("/", "")).ToArray();

                Console.WriteLine($"{request.HttpMethod} request made to {context.Request.Url}");


                ProcessHttpMethod(apiRequestMethodName, stringParams, response, request);
            }
        }

        private static void ProcessHttpMethod(string apiRequestMethodName, string[] stringParams, HttpListenerResponse response,
            HttpListenerRequest request)
        {
            if (request.HttpMethod == "GET")
            {
                var queryAction = ApiGetResponseFactory.GetResponseObject(apiRequestMethodName, stringParams);
                ProcessResponse(queryAction.GetData(stringParams), response);
            }

            if (request.HttpMethod == "DELETE")
            {
                var deleteAction = ApiDeleteResponseFactory.GetDeleteResponseObject(apiRequestMethodName, stringParams);
                ProcessResponse(deleteAction.DeleteRecord(stringParams),response);
            }

            if (request.HttpMethod == "POST")
            {

                var body = request.InputStream;
                var encoding = request.ContentEncoding;
                var reader = new StreamReader(body, encoding);

                var requestBody = reader.ReadToEnd();

                var postAction = ApiPostResponseFactory.GetPostResponseObject(apiRequestMethodName, stringParams);
                postAction.PostToDataBase(requestBody);
                
                Console.WriteLine("End of client data...");
                body.Close();
                reader.Close();


                ProcessResponse(requestBody, response);
            }
        }

        private static void ProcessResponse(string responseMessage, HttpListenerResponse response)
        {
            var responseBuffer = System.Text.Encoding.UTF8.GetBytes(responseMessage);

            response.ContentType = "application/json";

            response.ContentLength64 = responseBuffer.Length;
            response.OutputStream.Write(responseBuffer, 0, responseBuffer.Length); // forces send of response
        }
    }
}