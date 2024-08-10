namespace calculator.models
{
    /// <summary>
    /// 四則演算を行うクラス
    /// </summary>
    public static class Calculator
    {
        public static decimal Calculate(decimal a, Operator ope, decimal b)
        {
            return ope switch
            {
                Operator.Plus => a + b,
                Operator.Minus => a - b,
                Operator.Multiply => a * b,
                Operator.Divide => a / b,
                _ => throw new Exception("不正"),
            };
        }
    }
}
