namespace calculator.test.models
{
    [TestClass]
    public class CalculatorTest
    {
        public static IEnumerable<object[]> TestData { get; } = new List<object[]>
        {
            new object[]{ 7m, 3m },
        };

        [TestMethod]
        [DynamicData(nameof(TestData), DynamicDataSourceType.Property)]
        public void Calculate_Plus(decimal a, decimal b)
        {
            decimal actual = Calculator.Calculate(a, Operator.Plus, b);

            Assert.AreEqual(a + b, actual);
        }

        [TestMethod]
        [DynamicData(nameof(TestData), DynamicDataSourceType.Property)]
        public void Calculate_Minus(decimal a, decimal b)
        {
            decimal actual = Calculator.Calculate(a, Operator.Minus, b);

            Assert.AreEqual(a - b, actual);
        }

        [TestMethod]
        [DynamicData(nameof(TestData), DynamicDataSourceType.Property)]
        public void Calculate_Multiply(decimal a, decimal b)
        {
            decimal actual = Calculator.Calculate(a, Operator.Multiply, b);

            Assert.AreEqual(a * b, actual);
        }

        [TestMethod]
        [DynamicData(nameof(TestData), DynamicDataSourceType.Property)]
        public void Calculate_Divide(decimal a, decimal b)
        {
            decimal actual = Calculator.Calculate(a, Operator.Divide, b);

            Assert.AreEqual(a / b, actual);
        }
    }
}