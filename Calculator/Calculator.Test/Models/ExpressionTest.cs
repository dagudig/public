namespace calculator.test.models
{
    [TestClass]
    public class ExpressionTest
    {
        [TestMethod]
        public void InputNumber_SomeNumber_ReturnUpdated()
        {
            Expression expression = new Expression()
                .InputNumber(3);

            Assert.AreEqual("3", expression.Current.StringValue);
        }

        [TestMethod]
        public void InputDot_ReturnDecimal()
        {
            Expression expression = new Expression()
                .InputDot();

            Assert.AreEqual("0.", expression.Current.StringValue);
        }

        [TestMethod]
        public void InputOperator_IsNotDirty_ReturnNotSet()
        {
            Expression expression = new Expression()
                .InputOperator(Operator.Minus)
                .InputNumber(3)
                .Calculate();

            Assert.AreEqual("3", expression.Current.StringValue);
        }

        [TestMethod]
        public void InputOperator_IsDirty_ReturnSet()
        {
            Expression expression = new Expression()
                .InputNumber(3)
                .InputOperator(Operator.Plus)
                .InputNumber(5)
                .Calculate();

            Assert.AreEqual("8", expression.Current.StringValue);
        }

        [TestMethod]
        public void InputOperator_InsteadOfCalculate_ReturnCalculateAndSet()
        {
            Expression expression1 = new Expression()
                .InputNumber(3)
                .InputOperator(Operator.Plus)
                .InputNumber(5)
                .InputOperator(Operator.Minus);

            Assert.AreEqual("8", expression1.Current.StringValue);

            // ââéZéqÇì¸óÕÇµÇ»Ç¢Ç≈éüÇÃêîílÇì¸óÕ
            Expression expression2 = expression1
                .InputNumber(4)
                .Calculate();

            Assert.AreEqual("4", expression2.Current.StringValue);
        }

        [TestMethod]
        public void InputOperator_ChangeOperator_Changed()
        {
            Expression expression = new Expression()
                .InputNumber(3)
                .InputOperator(Operator.Plus)
                .InputOperator(Operator.Minus)
                .InputNumber(5)
                .Calculate();

            Assert.AreEqual("-2", expression.Current.StringValue);
        }

        [TestMethod]
        public void Calculate_NoOperator_ReturnDoNothing()
        {
            Expression expression = new Expression()
                .InputNumber(3)
                .Calculate();

            Assert.AreEqual("3", expression.Current.StringValue);
        }

        [TestMethod]
        public void Calculate_NoInputAfterInputOperator_ReturnDoNothing()
        {
            Expression expression = new Expression()
                .InputNumber(3)
                .InputOperator(Operator.Plus)
                .Calculate();

            Assert.AreEqual("3", expression.Current.StringValue);
        }

        [TestMethod]
        public void ResetCurrent()
        {
            Expression expression = new Expression()
                .InputNumber(3)
                .InputOperator(Operator.Plus)
                .InputNumber(5)
                .ResetCurrent();

            Assert.AreEqual("3", expression.Current.StringValue);
        }
    }

    
}