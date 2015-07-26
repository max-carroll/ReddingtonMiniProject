using System;
using NUnit.Framework;
using Probability.Models;

namespace Probability.Tests.CalculationTests
{
    [TestFixture]
    public class ConstructorTests
    {

        #region ProbA Tests

        [Test]
        public void Test_001_ProbA_Null_Throws_NullArugmentException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new Calculation(null, "aString", "aString", "aString"));
            Assert.AreEqual("probA", exception.ParamName);
        }

        [TestCase("One")]
        [TestCase(" ")]
        [TestCase("")]
        public void Test_002_ProbA_ThatIsntNumeric_Throws_ArugmentException(string probA)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Calculation(probA, "aString", "aString", "aString"));
            Assert.AreEqual("probA must be numeric", exception.Message);
        }

        [Test]
        public void Test_003_ProbA_IsGreaterThanOne_ArugmentException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Calculation("1.1", "aString", "aString", "aString"));
            Assert.AreEqual("probA must be less than one", exception.Message);
        }

        [Test]
        public void Test_004_ProbA_LessThanZero_ArugmentException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Calculation("-1", "aString", "aString", "aString"));
            Assert.AreEqual("probA must be greater than zero", exception.Message);
        }

        #endregion

        #region ProbB Tests

        [Test]
        public void Test_101_probB_Null_Throws_NullArugmentException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new Calculation("0.2", null, "aString", "aString"));
            Assert.AreEqual("probB", exception.ParamName);
        }

        [TestCase("One")]
        [TestCase(" ")]
        [TestCase("")]
        public void Test_102_probB_ThatIsntNumeric_Throws_ArugmentException(string probB)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Calculation("0.2", probB, "aString", "aString"));
            Assert.AreEqual("probB must be numeric", exception.Message);
        }

        [Test]
        public void Test_103_probB_IsGreaterThanOne_ArugmentException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Calculation("0.2", "1.1", "aString", "aString"));
            Assert.AreEqual("probB must be less than one", exception.Message);
        }

        [Test]
        public void Test_104_probB_LessThanZero_ArugmentException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Calculation("0.2", "-1", "aString", "aString"));
            Assert.AreEqual("probB must be greater than zero", exception.Message);
        }

        #endregion

        #region result Tests


        [Test]
        public void Test_201_result_Null_Throws_NullArugmentException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new Calculation("0.2", "0.2", null, "aString"));
            Assert.AreEqual("result", exception.ParamName);
        }

        [TestCase("One")]
        [TestCase(" ")]
        [TestCase("")]
        public void Test_202_result_ThatIsntNumeric_Throws_ArugmentException(string result)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Calculation("0.2", "0.2", result, "aString"));
            Assert.AreEqual("result must be numeric", exception.Message);
        }

        [Test]
        public void Test_203_result_IsGreaterThanOne_ArugmentException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Calculation("0.2", "0.2", "1.1", "aString"));
            Assert.AreEqual("result must be less than one", exception.Message);
        }

        [Test]
        public void Test_204_result_LessThanZero_ArugmentException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Calculation("0.2", "0.2", "-1", "aString"));
            Assert.AreEqual("result must be greater than zero", exception.Message);
        }

        #endregion

        #region CalculationTypeTests

        [Test]
        public void Test_301_calculationType_Null_Throws_NullArugmentException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new Calculation("0.2", "0.2", "0.2", null));
            Assert.AreEqual("calculationType", exception.ParamName);
        }

        [Test]
        public void Test_302_calculationType_Combined_SetsEnum()
        {
            Calculation calc = new Calculation("0.2", "0.2", "0.2", "Combined");
            Assert.AreEqual(CalculationType.Combined.ToString(), calc.CalculationType.ToString());
        }

        [Test]
        public void Test_303_calculationType_Either_SetsEnum()
        {
            Calculation calc = new Calculation("0.2", "0.2", "0.2", "Either");
            Assert.AreEqual(CalculationType.Either.ToString(), calc.CalculationType.ToString());
        }

        [TestCase("NotACalculationType")]
        public void Test_304_InvalidCalculationType_Throws_ArgurmentException(string calculationType)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Calculation("0.2", "0.2", "0.2", calculationType));
            Assert.AreEqual("Not a valid calculationType", exception.Message);
        }





        #endregion


    }
}
