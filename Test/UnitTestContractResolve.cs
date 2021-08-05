using Code.ContractResolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class UnitTestContractResolve
    {


        [TestMethod]
        public void Should_IgnoreProperties_Ignore_a_property_with_valueZero_when_converting_the_json()
        {
            Model model = new Model()
            {
                Description = "Example",
                Value = "0",
                Price = "Example price",
                Model2 = new Model2() { Description = "Example model 2", Value = "Example name model2" }
            };

            List<string> ignoreColumnsValueZero = new List<string>();
            ignoreColumnsValueZero.Add("Value");


            var JSON = Consumer.IgnoreProperties(model, ignoreColumnsValueZero);

            JObject jObject = JObject.Parse(JSON);

            Assert.AreEqual(null, jObject["Value"]);
            Assert.AreEqual("Example", jObject["Description"]);
        }


        [TestMethod]
        public void Should_IgnoreProperties_Ignore_a_property_with_valueZero_accordingArray_when_converting_the_json()
        {
            Model model = new Model()
            {
                Description = "Example",
                Value = "0",
                Price = "0",
                Model2 = new Model2() { Description = "Example model 2", Value = "Example name model2" }
            };

            List<string> ignoreColumnsValueZero = new List<string>();
            ignoreColumnsValueZero.Add("Value");


            var JSON = Consumer.IgnoreProperties(model, ignoreColumnsValueZero);

            JObject jObject = JObject.Parse(JSON);

            Assert.AreEqual(null, jObject["Value"]);
            Assert.AreEqual("0", jObject["Price"]);
        }


        [TestMethod]
        public void Should_IgnoreProperties_Ignore_properties_with_valueZero_accordingArray_when_converting_the_json()
        {
            Model model = new Model()
            {
                Description = "Example",
                Value = "0",
                Price = "0",
                Model2 = new Model2() { Description = "Example model 2", Value = "Example name model2" }
            };

            List<string> ignoreColumnsValueZero = new List<string>();
            ignoreColumnsValueZero.Add("Value");
            ignoreColumnsValueZero.Add("Price");


            var JSON = Consumer.IgnoreProperties(model, ignoreColumnsValueZero);

            JObject jObject = JObject.Parse(JSON);

            Assert.AreEqual(null, jObject["Value"]);
            Assert.AreEqual(null, jObject["Price"]);
        }
    }
}
