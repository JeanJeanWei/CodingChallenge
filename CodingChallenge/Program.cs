using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;



namespace CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //dynamic stuff = JsonConvert.DeserializeObject("{ 'Name': 'Jon Smith', 'Address': { 'City': 'New York', 'State': 'NY' }, 'Age': 42 }");

            //string name = stuff.Name;
            //string address = stuff.Address.City;

            dynamic stuff = JObject.Parse("{ 'Name': 'Jon Smith', 'Address': { 'City': 'New York', 'State': 'NY' }, 'Age': 42 }");

            string name = stuff.Name;
            string address = stuff.Address.City;

           
        }

        

    }
}
