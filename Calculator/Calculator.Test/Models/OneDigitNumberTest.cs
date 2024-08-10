namespace calculator.test.models
{
    [TestClass]
    public class OneDigitNumberTest
    {
        [TestMethod]
        public void Value_LessThanMinimum_ThrowArgumentException()
        {
            Action action = () => { new OneDigitNumber(-1); };

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Value_MoreThanMaximum_ThrowArgumentException()
        {
            Action action = () => { new OneDigitNumber(10); };

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(9)]
        public void Value_Boundary_SetValue(int number)
        {
            OneDigitNumber oneDigitNumber = new OneDigitNumber(number);

            Assert.AreEqual(number, oneDigitNumber.Value);
        }
    }
}