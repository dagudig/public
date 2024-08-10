namespace calculator.models
{
    /// <summary>
    /// ユーザが入力中の式を表すクラス
    /// </summary>
    public class Expression
    {
        // 演算される値
        private readonly Result _preResult;
        // 演算子
        private readonly Operator _operator;
        // 演算する値
        private readonly Result _result;

        public Expression() : this(new Result()) { }

        private Expression(Result result) : this(null, Operator.None, result) { }

        private Expression(Result result, Operator ope) : this(result, ope, new Result()) { }

        private Expression(Result preResult, Operator ope, Result result)
        {
            _preResult = preResult;
            _operator = ope;
            _result = result;
        }

        public Result Current 
        {
            get
            {
                // 何か入力されているならその値を表示
                if (_result.IsDirty) return _result;

                // 何も入力されていないなら、保存中の値があればそれを表示
                return _preResult ?? _result;
            }
        }

        public Expression InputNumber(OneDigitNumber oneDigitNumber)
        {
            Result result = _result.InputNumber(oneDigitNumber);

            return new Expression(_preResult, _operator, result);
        }

        public Expression InputDot()
        {
            Result result = _result.InputDot();

            return new Expression(_preResult, _operator, result);
        }

        public Expression InputOperator(Operator ope)
        {
            // 保存中の値がないとき
            if (_preResult is null)
            {
                if (_result.IsDirty)
                {
                    // 現在の値と演算子を保存
                    return new Expression(_result, ope);
                }
                else
                {
                    return this;
                }
            }

            // 保存中の値があるが、現在の値が入力されていない
            // →演算子のみを変更
            if (_result.IsDirty == false) return new Expression(_preResult, ope);

            // 計算結果と演算子を保存
            Expression calculated = Calculate();
            return new Expression(calculated.Current, ope);
        }

        public Expression Calculate()
        {
            // 保存されている値がなければ何もしない
            if (_preResult is null) return this;

            // 現在の値が入力されていなければ何もしない
            if (_result.IsDirty == false) return this;

            Result calculated = _preResult.Calculate(_operator, _result);
            return new Expression(calculated);
        }

        public Expression ResetCurrent()
        {
            return new Expression(_preResult, _operator);
        }
    }
}
