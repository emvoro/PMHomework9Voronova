using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrimesTestApp.Tests
{
    public class Testing
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly Uri _baseAddress = new Deserialization.Deserialization("settings.json").BaseAddress;

        public Testing()
        {
            _httpClient.BaseAddress = _baseAddress;
        }

        public async Task TestIsPrimesEndpoint(string query, int expectedStatusCode)
        {
            var response = await _httpClient.GetAsync(query);
            var content = await response.Content.ReadAsStringAsync();
            if (query == "/" || !query.Contains('?'))
                ConsoleWriteResponce(query, expectedStatusCode, (int)response.StatusCode, null);
            else
                ConsoleWriteResponce(query, expectedStatusCode, (int)response.StatusCode, content);
        }

        public void ConsoleWriteResponce(string request, int expectedStatusCode, int actualStatusCode, string content)
        {
            var testResult = new TestResult(request, expectedStatusCode, actualStatusCode, expectedStatusCode == actualStatusCode);
            Console.WriteLine($"\n Request              : {testResult.Request}");
            Console.WriteLine($" Expected Status Code : {testResult.ExpectedStatusCode}");
            Console.WriteLine($" Actual Status Code   : {testResult.ActualStatusCode}");
            if (content != null)
                Console.WriteLine($" Response             : {content}");
            WriteResult(testResult.IsSucceeded);
        }

        public void WriteResult(bool isSucceeded)
        {
            Console.ForegroundColor = isSucceeded ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(isSucceeded ? " SUCCEEDED" : " FAILED");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
