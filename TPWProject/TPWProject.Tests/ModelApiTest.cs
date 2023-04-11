using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPWProject.Presentation.Model;

namespace TPWProject.Tests
{
    [TestClass]
    public class ModelApiTest
    {
        [TestMethod]
        public void ModelAPITest()
        {
            ModelAPI modelAPI = AbstractModelAPI.CreateAPI(100, 100);
            modelAPI.Start(2);
            Assert.AreEqual(modelAPI.GetShapes().Count, 2);
            modelAPI.Stop();
            Assert.AreEqual(modelAPI.GetShapes().Count, 0);
        }
    }
}
