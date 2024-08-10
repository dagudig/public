using calculator.models;
using System.Windows;

namespace calculator.viewmodels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // 記憶用変数
        private models.Expression _expression;

        public MainWindowViewModel()
        {
            ZeroZeroCommand = new MinimalCommand(() => { InputNumber(0); InputNumber(0); });
            ZeroCommand = new MinimalCommand(() => { InputNumber(0); });
            OneCommand = new MinimalCommand(() => { InputNumber(1); });
            TwoCommand = new MinimalCommand(() => { InputNumber(2); });
            ThreeCommand = new MinimalCommand(() => { InputNumber(3); });
            FourCommand = new MinimalCommand(() => { InputNumber(4); });
            FiveCommand = new MinimalCommand(() => { InputNumber(5); });
            SixCommand = new MinimalCommand(() => { InputNumber(6); });
            SevenCommand = new MinimalCommand(() => { InputNumber(7); });
            EightCommand = new MinimalCommand(() => { InputNumber(8); });
            NineCommand = new MinimalCommand(() => { InputNumber(9); });

            DotCommand = new MinimalCommand(InputDot);

            PlusCommand = new MinimalCommand(() => { SetOperator(Operator.Plus); });
            MinusCommand = new MinimalCommand(() => { SetOperator(Operator.Minus); });
            MultiplyCommand = new MinimalCommand(() => { SetOperator(Operator.Multiply); });
            DivideCommand = new MinimalCommand(() => { SetOperator(Operator.Divide); });

            CalculateCommand = new MinimalCommand(Calculate);

            CCommand = new MinimalCommand(ResetCurrent);
            ACCommand = new MinimalCommand(ResetAll);

            _expression = new models.Expression();

            // 初期表示
            Notify();
        }

        // 画面に表示する値
        private string _result = string.Empty;
        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                RaisePropertyChanged();
            }
        }

        public MinimalCommand ZeroZeroCommand { get; }
        public MinimalCommand ZeroCommand { get; }
        public MinimalCommand OneCommand { get; }
        public MinimalCommand TwoCommand { get; }
        public MinimalCommand ThreeCommand { get; }
        public MinimalCommand FourCommand { get; }
        public MinimalCommand FiveCommand { get; }
        public MinimalCommand SixCommand { get; }
        public MinimalCommand SevenCommand { get; }
        public MinimalCommand EightCommand { get; }
        public MinimalCommand NineCommand { get; }

        public MinimalCommand DotCommand { get; }

        public MinimalCommand PlusCommand { get; }
        public MinimalCommand MinusCommand { get; }
        public MinimalCommand MultiplyCommand { get; }
        public MinimalCommand DivideCommand { get; }

        public MinimalCommand CalculateCommand { get; }

        public MinimalCommand CCommand { get; }
        public MinimalCommand ACCommand { get; }

        private void InputNumber(int number)
        {
            try
            {
                OneDigitNumber oneDigitNumber = new OneDigitNumber(number);

                _expression = _expression.InputNumber(oneDigitNumber);

                Notify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InputDot()
        {
            try
            {
                _expression = _expression.InputDot();

                Notify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetOperator(Operator ope)
        {
            try
            {
                _expression = _expression.InputOperator(ope);

                Notify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Calculate()
        {
            try
            {
                _expression = _expression.Calculate();

                Notify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetCurrent()
        {
            try
            {
                _expression = _expression.ResetCurrent();

                Notify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetAll()
        {
            try
            {
                _expression = new models.Expression();

                Notify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Notify()
        {
            try
            {
                Result = _expression.Current.StringValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
