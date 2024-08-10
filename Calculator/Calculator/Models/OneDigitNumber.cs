namespace calculator.models
{
    /// <summary>
    /// 1桁の数値を表すクラス
    /// </summary>
    public class OneDigitNumber
    {
        public OneDigitNumber(int value)
        {
            if (value < 0 || 9 < value) throw new ArgumentException("0~9までの数値しか扱えません。"); 

            Value = value;
        }

        public int Value { get; }
    }
}
