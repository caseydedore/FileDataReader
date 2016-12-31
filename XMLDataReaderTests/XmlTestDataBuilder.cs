using System;
using XMLDataReaderTests.Models;

namespace XMLDataReaderTests
{
    public class XmlTestDataBuilder
    {
        private Random random = new Random();

        public TestModel GetTestModel(int numberOfModels = 10)
        {
            var model = new TestModel();

            model.ID = GetRandomID();
            model.Description = Guid.NewGuid().ToString();

            for(var i = 0; i < numberOfModels; i++)
            {
                model.Models.Add(new Model() { ID = GetRandomID() });
            }

            return model;
        }

        public NestedTestModel GetNestedTestModel(int numberOfModels = 10)
        {
            var model = new NestedTestModel();

            model.ID = GetRandomID();

            for (var i = 0; i < numberOfModels; i++)
            {
                model.TestModels.Add(GetTestModel());
            }

            return model;
        }

        private uint GetRandomID()
        {
            return (uint)random.Next(int.MinValue, int.MaxValue);
        }
    }
}
