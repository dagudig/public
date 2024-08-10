using System.Windows.Input;

namespace calculator.viewmodels
{
    // ICommandインタフェイス実装のミニマル版
    public class MinimalCommand : ICommand
    {
        private readonly Action _action;

        public MinimalCommand(Action action)
        {
            _action = action;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            _action();
        }
    }
}