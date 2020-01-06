

namespace SearchFight.Test
{
    using NUnit.Framework;
    using Moq;
    using SearchFight.SetUp;
    using SearchFight.Model;
    using System.Linq;

    [TestFixture]
    public class SearchResultTest
    {
        readonly Mock<IResolver> mock = new Mock<IResolver>();


        [SetUp]
        public void Init()
        {
            mock.Setup(p => p.GetWinnerByEngine(It.IsAny<string[]>(), It.IsAny <string>()))
            .Returns((string[] a, string b) =>
            {
                if (b == "Google")
                    return DataSourceTest.ListWinnerGoogle().Where(x => x.Engine == "Google").OrderByDescending(x => x.Total).FirstOrDefault();
                else
                    return DataSourceTest.ListWinnerBing().Where(x => x.Engine == "Bing").OrderByDescending(x => x.Total).FirstOrDefault();
            });
        }

        [Test]
        public void GetWinnerByEngine_If_Engine_Is_Google_Should_Return_NET_In_Google() {
            IResolver program = mock.Object;
            var expect = new GeneralResponse() {
                Name = "net",
                Engine = "Google",
                Total = 150
            };
            Assert.AreNotSame(expect, program.GetWinnerByEngine(new string[] { "java", "net" }, "Google"));
        }

        [Test]
        public void GetWinnerByEngine_If_Engine_Is_Bing_Should_Return_JAVA_In_Bing()
        {
            IResolver program = mock.Object;
            var expect = new GeneralResponse()
            {
                Name = "java",
                Engine = "Bing",
                Total = 800
            };
            Assert.AreNotSame(expect, program.GetWinnerByEngine(new string[] { "java", "net", "java script" }, "Bing"));
        }
    }
}
