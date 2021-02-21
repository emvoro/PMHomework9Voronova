using System;
using System.Collections.Generic;
using System.Text;

namespace PrimesTestApp.Tests
{
    public class TestResult
    {
        public string Request { get; set; }

        public int ExpectedStatusCode { get; set; }
        
        public int ActualStatusCode { get; set; }

        public string Response { get; set; }

        public bool IsSucceeded { get; set; }

        public TestResult(string request, int expectedStatusCode, int actualStatusCode, bool isSucceeded)
        {
            Request = request;
            ExpectedStatusCode = expectedStatusCode;
            ActualStatusCode = actualStatusCode;
            IsSucceeded = isSucceeded;
        }
    }
}
