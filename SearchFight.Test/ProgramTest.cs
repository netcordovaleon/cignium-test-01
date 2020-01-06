
namespace SearchFight.Test
{

    using NUnit.Framework;
    using Moq;
    using SearchFight.SetUp;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using SearchFight.Core;

    [TestFixture]
    public class ProgramTest
    {

        readonly Mock<IResolver> mock = new Mock<IResolver>();

        [SetUp]
        public void Init() {
            mock.Setup(p => p.ValidateArguments(It.IsAny<string[]>()))
               .Returns((string[] c) =>
               {
                   if (c.Length < 1)
                   {
                       throw new ArgumentException("Error enter more than one argument");
                   }
                   
                   if (c.Any(d=> string.IsNullOrEmpty(d))) {
                       throw new SearchFightException("Error");
                   }
                   return true;
               }
           );

            mock.Setup(p => p.FinalResponse(It.IsAny<string[]>())).Returns((string[] c) =>
            {
                if (c.Length < 1)
                {
                    return "";
                }
                string response  = string.Format("java Google Search: {0} BingSearch: {1}", "10000", "60000");
                return response;
            });

        }

        [Test]
        public void ValidateArguments_If_Dont_Have_Thwo_Or_More_Arguments_Should_Return_ArgumentException()
        {
            IResolver program = mock.Object;
            Assert.Throws<ArgumentException>(()=> program.ValidateArguments(new string[] { }));
        }


        [Test]
        public void ValidateArguments_If_Have_Minimum_Thwo_Arguments_Should_Return_True()
        {
            IResolver program = mock.Object;
            Assert.IsTrue(program.ValidateArguments(new string[] { "java", "net" }));
        }


        [Test]
        public void ValidateArguments_If_Have_One_Arguments_Empty_Should_Return_SearchFightException()
        {
            IResolver program = mock.Object;

            Assert.Throws<SearchFightException>(() => program.ValidateArguments(new string[] { "java", "" }));
        }

        [Test]
        public void FinalResponse_When_Is_Empty_Should_Return_Empty()
        {
            IResolver program = mock.Object;
            var response = program.FinalResponse(new string[] { });
            Assert.AreEqual("", response);
        }

        [Test]
        public void FinalResponse_If_Have_A_Body_Should_Return_A_String()
        {
            IResolver program = mock.Object;
            var response = program.FinalResponse(new string[] { "java", ".net" });
            Assert.IsNotEmpty(response);
        }
    }
}
