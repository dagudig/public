namespace calculator.test.models
{
    internal static class ExpressionExtension
    {
        // int型からExpressionを生成
        public static Expression InputNumber(this Expression expression, int value) => expression.InputNumber(new OneDigitNumber(value));
    }
}
