using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
           
            dynamic stuff = JsonConvert.DeserializeObject("{ 'Name': 'Jon Smith', 'Address': { 'City': 'New York', 'State': 'NY' }, 'Age': 42 }");

            //string name = stuff.Name;
            //string address = stuff.Address.City;

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
                    Console.WriteLine(name + ": " + value);
                }
            }
        }

        

    }
}
