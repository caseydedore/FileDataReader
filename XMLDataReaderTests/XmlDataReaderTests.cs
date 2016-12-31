using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataReader;
using XMLDataReaderTests.Models;

namespace XMLDataReaderTests
{
    [TestClass]
    public class XmlDataReaderTests
    {
        private XmlTestDataBuilder modelBuilder = new XmlTestDataBuilder();
        private XmlDataReader reader = new XmlDataReader();


        [TestMethod]
        public void ModelSerialization()
        {
            var model = modelBuilder.GetTestModel();

            var serializedData = reader.Serialize(model);
            var parsedModel = reader.Deserialize<TestModel>(serializedData);

            Assert.AreEqual(model.ID, parsedModel.ID);
            Assert.AreEqual(model.Description, parsedModel.Description);
            Assert.AreEqual(model.Models.Count, parsedModel.Models.Count);

            for(var i = 0; i < model.Models.Count; i++)
            {
                Assert.AreEqual(model.Models[i].ID, parsedModel.Models[i].ID);
            }
        }

        [TestMethod]
        public void NestedModelSerialization()
        {
            var model = modelBuilder.GetNestedTestModel();

            var serializedData = reader.Serialize(model);
            var parsedModel = reader.Deserialize<NestedTestModel>(serializedData);

            Assert.AreEqual(model.ID, parsedModel.ID);
            Assert.AreEqual(model.TestModels.Count, parsedModel.TestModels.Count);

            for(var i = 0; i < model.TestModels.Count; i++)
            {
                Assert.AreEqual(model.TestModels[i].ID, parsedModel.TestModels[i].ID);
                Assert.AreEqual(model.TestModels[i].Description, parsedModel.TestModels[i].Description);

                for (var j = 0; j < model.TestModels[i].Models.Count; j++)
                {
                    Assert.AreEqual(model.TestModels[i].Models[j].ID, parsedModel.TestModels[i].Models[j].ID);
                }
            }
        }
    }
}
