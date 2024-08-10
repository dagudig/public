namespace calculator.models
{
    /// <summary>
    /// ユーザの入力結果を表すクラス
    /// </summary>
    public class Result : IEquatable<Result>
    {
        private const int MaxDigit = 20;

        public Result() 
        {
            StringValue = $"{0}";
        }

        public Result(decimal value) : this($"{value}") { }

        public Result(string value)
        {
            if (value.Length > MaxDigit) throw new Exception("20桁を超えています。");

            StringValue = value;
            IsDirty = true;
        }

        // 文字列の形式を数値に変換する
        private decimal DecimalValue
        {
            get 
            {
                // 小数点を入力直後は数値として扱えないため末尾を削って扱う
                if (LatestInputIsDot()) return Convert.ToDecimal(StringValue.Substring(0, StringValue.Length - 1));

                return Convert.ToDecimal(StringValue);
            }
        }

        public string StringValue { get; }

        // ユーザの入力がされた値であるかどうか
        public bool IsDirty { get; }

        public bool Equals(Result? other) 
        {
            return DecimalValue == other?.DecimalValue;
        }

        public override int GetHashCode()
        {
            return DecimalValue.GetHashCode();
        }

        // 小数かどうか
        private bool IsDecimal() => StringValue.Contains(".");

        private bool LatestInputIsDot() => StringValue.EndsWith(".");

        public Result InputNumber(OneDigitNumber number)
        {
            int inputNumber = number.Value;
            string afterNumber = DecimalValue == 0 ? $"{inputNumber}" : $"{StringValue}{inputNumber}";

            return new Result(afterNumber);
        }

        public Result InputDot()
        {
            // 小数のときは何もしない
            if (IsDecimal()) return this;

            return new Result($"{StringValue}.");
        }

        public Result Calculate(Operator ope, Result result)
        {
            decimal calculated = Calculator.Calculate(DecimalValue, ope, result.DecimalValue);

            return new Result($"{calculated}");
        }
    }
}
