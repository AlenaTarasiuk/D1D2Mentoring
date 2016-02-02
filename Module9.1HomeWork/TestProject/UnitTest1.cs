using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Module6HomeWork;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerifyObjCountTest()
        {
            FileSystemVisitor visit = new FileSystemVisitor(@"..\..\Test");
            int actualCount = 0;

            foreach (var element in visit)
                ++actualCount;
            
            int expectCount = 9;
            Assert.AreEqual(expectCount, actualCount);
        }

        [TestMethod]
        public void VerifyCountFilesWithNumber3Test()
        {
            FileSystemVisitor visit = new FileSystemVisitor(@"..\..\Test");
            visit.FileFinded += fileFinded;
            int actualCount = 0;

            foreach (var element in visit)
                ++actualCount;

            int expectCount = 8;
            Assert.AreEqual(expectCount, actualCount);
        }

        [TestMethod]
        public void VerifyCountTextFileTest()
        {
            FileSystemVisitor visit = new FileSystemVisitor(@"..\..\Test", x => x.Extension == ".txt");
            int actualCount = 0;

            foreach (var element in visit)
                ++actualCount;

            int expectCount = 3;
            Assert.AreEqual(expectCount, actualCount);
        }

        [TestMethod]
        public void VerifyCountFoldersWithNumber2Test()
        {
            FileSystemVisitor visit = new FileSystemVisitor(@"..\..\Test");
            visit.DirectoryFinded += directoryFinded;
            int actualCount = 0;

            foreach (var v in visit)
            {
                ++actualCount;
            }

            int expectCount = 6;
            Assert.AreEqual(expectCount, actualCount);
        }

        void directoryFinded(object sender, IterationControlArgs e)
        {
            if (e.CurrentFile.Name.Contains("2"))
                e.Exclude = true;
        }

        void fileFinded(object sender, IterationControlArgs e)
        {
            if (e.CurrentFile.Name.Contains("3"))
                e.Exclude = true;
        }
    }
}
