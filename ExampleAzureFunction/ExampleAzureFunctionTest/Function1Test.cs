using ExampleAzureFunction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleAzureFunctionTest
{
    [TestClass]
    public class Function1Test
    {
        /// <summary>
        /// Tests if a request without body parameters will be precessed correctly
        /// </summary>
        /// <returns>Task</returns>
        [TestMethod]
        public async Task Run_QueryContainsName()
        {
            // Arrange
            ListLogger logger = new ListLogger();
            Dictionary<string, StringValues> query = new Dictionary<string, StringValues>();
            query["name"] = new StringValues("Abc");
            HttpRequest request = FunctionTest.HttpRequestSetup(query, "");

            // Act
            var response = await Function1.Run(request, logger);
            var resultObject = (OkObjectResult)response;

            // Assert
            Assert.AreEqual("Hello Abc", resultObject.Value);
            Assert.IsTrue(logger.Logs.Contains("C# HTTP trigger function processed a request."));
        }
        /// <summary>
        /// Tests if a request without query parameters will be precessed correctly.
        /// </summary>
        /// <returns>Task</returns>

       [TestMethod]
        public async Task Run_QueryBodyContainsName()
        {
            // Arrange
            ListLogger logger = new ListLogger();
            var query = new Dictionary<string, StringValues>();
            // body should be json format
            string body = "{\"name\":\"Def\"}";
            HttpRequest request = FunctionTest.HttpRequestSetup(query, body);

            // Act
            var response = await Function1.Run(request, logger);
            var resultObject = (OkObjectResult)response;

            //Assert
            Assert.AreEqual("Hello Def", resultObject.Value);
            Assert.IsTrue(logger.Logs.Contains("C# HTTP trigger function processed a request."));

       }
        /// <summary>
        /// Tests if a request without query and body parameters will be processed correctly
        /// </summary>
        /// <returns>Task</returns>

        [TestMethod]
        public async Task Run_NoNameInQueryAndBody()
        {
            // Assert
            ListLogger logger = new ListLogger();
            HttpRequest request = FunctionTest.HttpRequestSetup(new Dictionary<string, StringValues>(), "");

            //act
            var response = await Function1.Run(request, logger);
            var resultObject = (OkObjectResult)response;

            // Assert
            Assert.AreEqual("This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.", resultObject.Value);
            Assert.IsTrue(logger.Logs.Contains("C# HTTP trigger function processed a request."));

        }
    }
}
