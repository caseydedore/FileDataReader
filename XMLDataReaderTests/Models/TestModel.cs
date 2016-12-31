using System.Collections.Generic;
using System.Xml.Serialization;

namespace XMLDataReaderTests.Models
{
    [XmlRoot("TestModel")]
    public class TestModel
    {
        [XmlAttribute]
        public uint ID { get; set; }
        [XmlElement]
        public string Description { get; set; }
        [XmlElement("Model")]
        public List<Model> Models { get; set; }


        public TestModel()
        {
            Models = new List<Model>();
        }
    }

    [XmlRoot("NestedTestModel")]
    public class NestedTestModel
    {
        [XmlAttribute]
        public uint ID { get; set; }

        [XmlElement("TestModel")]
        public List<TestModel> TestModels { get; set; }


        public NestedTestModel()
        {
            TestModels = new List<TestModel>();
        }
    }

    public class Model
    {
        [XmlAttribute]
        public uint ID { get; set; }
    }
}
