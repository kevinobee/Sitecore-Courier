using System.IO;
using MSBuild.Sitecore.Courier.Tasks;
using Microsoft.Build.Framework;

using Moq;
using NUnit.Framework;

namespace MSBuild.Sitecore.Courier.Tests
{
    [TestFixture]
    public class SitecoureCourierTests
    {
        private string _outputUpdateFile;

        [SetUp]
        public void SetUp()
        {
            _outputUpdateFile = @".\Test.update";
        }

        [TearDown]
        public void TearDown()
        {
//            File.Delete(_outputUpdateFile);
        }
        
        [Test]
        public void SitecoreCourier_Execute_Returns_True()
        {
            // Arrange
            var mockBuildEngine = new Mock<IBuildEngine>();
            var task = new SitecoreCourier();
            task.BuildEngine = mockBuildEngine.Object;
            task.ToolPath = @"..\..\..\Sitecore.Courier.Runner\bin\Debug\";
            task.SourceDirectory = @".";
            task.TargetDirectory = @".";
            task.OutputUpdateFile = _outputUpdateFile;

            // Act
            var result = task.Execute();

            // Assert
            Assert.That(result, Is.True, "Execute failed");
        }
    }
}
