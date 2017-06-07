using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using SystemInterface.IO;
using SystemWrapper;
using SystemWrapper.IO;

namespace codewars.FolderSort
{
    public class FolderSortTests
    {
        private IDirectory _directory;

        [SetUp]
        public void AforTestRun()
        {
            //_directory = NSubstitute.Substitute.For<IDirectory>();
            _directory = new DirectoryWrap();
        }

        [Test]
        public void FolderSortTest()
        {
            // arrange
            var directoryEins = CreateTestFolder("eins", 1);
            CreateTestFolder("zwei", 2);
            CreateTestFolder("drei", 3);
            CreateTestFolder("vier", 4);
            CreateTestFolder("fünf", 5);

            // act
            var oldestFolder = _directory.GetDirectories(directoryEins.Parent.FullName).OrderByDescending(x => x).First();

            var di =
                new System.IO.DirectoryInfo(directoryEins.Parent.FullName).GetDirectories()
                    .OrderBy(d => d.LastWriteTime)
                    .First();

            // assert
            Assert.That(di.FullName, Does.EndWith("fünf"));
        }

        private IDirectoryInfo CreateTestFolder(string name, int ageInHours)
        {
            var dirToCreate = Path.Combine(TestContext.CurrentContext.WorkDirectory, nameof(CreateTestFolder), name);
            var createdDirectory = _directory.CreateDirectory(dirToCreate);
            createdDirectory.LastWriteTime = new DateTimeWrap(DateTime.Now.AddHours(-ageInHours));
            return createdDirectory;
        }
    }
}