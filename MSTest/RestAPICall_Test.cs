using System;
using System.Collections.Generic;
using CodingChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace MSTest
{
    [TestClass]
    public class RestAPICall_Test
    {
        [TestMethod]
        public void TestMethod_RestAPICallWithJsonParser()
        {
            RestAPICall restCall = new RestAPICall();
            string testUrl = "https://jsonplaceholder.typicode.com/comments";
            Dictionary<string, string> para = new Dictionary<string, string>();
            para.Add("postId", "1");
            dynamic result = restCall.GetRestObjects(testUrl, para);



            foreach (JObject obj in result.Children<JObject>())
            {
                foreach (JProperty singleProp in obj.Properties())
                {
                    string name = singleProp.Name;
                    string value = singleProp.Value.ToString();
                    //Console.WriteLine(name + ": " + value);
                }
            }
            Assert.IsTrue(result != null);
        }
    }
}
