namespace calculator.test.models
{
    [TestClass]
    public class ResultTest
    {
        [TestMethod]
        public void Value_DefaultValue_0()
        {
            Result result = new Result();

            Assert.AreEqual(new Result(0), result);
        }

        // 最大桁を変更したら正しく機能しない
        [TestMethod]
        public void Value_LengthIs20_SetValue()
        {
            Result result = new Result(12345678901234567890);

            Assert.AreEqual(new Result(12345678901234567890), result);
        }

        // 最大桁を変更したら正しく機能しない
        [TestMethod]
        public void Value_LengthIs21_ThrowException()
        {
            Action action = () => { new Result("123456789012345678901"); };

            Assert.ThrowsException<Exception>(action);
        }

        [TestMethod]
        public void IsDirty_BeforeInput_False()
        {
            Result result = new Result();

            Assert.IsFalse(result.IsDirty);
        }

        [TestMethod]
        public void IsDirty_AfterInput_True()
        {
            Result result = new Result();

            Result after = result.InputNumber(new OneDigitNumber(1));

            Assert.IsTrue(after.IsDirty);
        }

        [TestMethod]
        public void InputNumber_SomeNumberTo0_SomeNumber()
        {
            Result result = new Result();
            OneDigitNumber oneDigitNumber = new OneDigitNumber(7);

            Result actual = result.InputNumber(oneDigitNumber);

            Assert.AreEqual(new Result(7), actual);
        }

        [TestMethod]
        public void InputNumber_SomeNumberToNot0_InsertRight()
        {
            Result result = new Result(5);
            OneDigitNumber oneDigitNumber = new OneDigitNumber(7);

            Result actual = result.InputNumber(oneDigitNumber);

            Assert.AreEqual(new Result(57), actual);
        }

        [TestMethod]
        public void InputDot_ToDecimalEndsWithDot_ReturnDecimal()
        {
            Result result = new Result();

            Result actual = result.InputDot().InputDot();

            Assert.AreEqual(new Result("0."), actual);
        }

        [TestMethod]
        public void InputDot_ToDecimal_ReturnDecimal()
        {
            Result result = new Result("0.5");

            Result actual = result.InputDot().InputDot();

            Assert.AreEqual(new Result("0.5"), actual);
        }

        [TestMethod]
        public void InputDot_ToInteger_ReturnDecimal()
        {
            Result result = new Result();

            Result actual = result.InputDot();

            Assert.AreEqual(new Result("0."), actual);
        }

        [TestMethod]
        public void Calculate()
        {
            Result result = new Result(5);

            Result actual = result.Calculate(Operator.Plus, new Result(10));

            Assert.AreEqual(new Result(15), actual);
        }
    }
}