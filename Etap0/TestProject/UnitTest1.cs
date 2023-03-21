using Microsoft.VisualStudio.TestTools.UnitTesting;
using PW.Model;
using PW.Model.Error;
using PW.ViewModel;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StudentContructorTest()
        {
            Student s = new Student("Jan", 20);
            Assert.IsTrue(s.Name == "Jan");
            Assert.IsTrue(s.Age == 20);
        }

        [TestMethod]
        public void EmptyNameTest()
        {
            StudentListVM studentListVM = new()
            {
                display = new TestDisplay()
            };
            studentListVM.AddStudent();
            Assert.AreEqual(studentListVM.StudentList.Count, 0);
        }
    }
}
