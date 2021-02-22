using System;
using System.Collections.Generic;
using System.Text;

namespace PrimesTestApp.Tests
{
    public class TestResult
    {
        public string Request { get; }

        public int ExpectedStatusCode { get; }
        
        public int ActualStatusCode { get; }

        public string Response { get; }

        public bool IsSucceeded { get; }

        public TestResult(string request, int expectedStatusCode, int actualStatusCode, bool isSucceeded)
        {
            Request = request;
            ExpectedStatusCode = expectedStatusCode;
            ActualStatusCode = actualStatusCode;
            IsSucceeded = isSucceeded;
        }
    }
}
