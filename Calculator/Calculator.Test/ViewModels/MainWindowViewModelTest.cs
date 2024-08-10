namespace calculator.test.viewmodels
{
    [TestClass]
    public class MainWindowViewModelTest
    {
        private readonly MainWindowViewModel _vm = new MainWindowViewModel();

        [TestMethod]
        public void ZeroZeroCommand()
        {
            _vm.OneCommand.Execute(null);

            _vm.ZeroZeroCommand.Execute(null);

            Assert.AreEqual("100", _vm.Result);
        }

        [TestMethod]
        public void ZeroCommand_Execute()
        {
            _vm.OneCommand.Execute(null);

            _vm.ZeroCommand.Execute(null);

            Assert.AreEqual("10", _vm.Result);
        }

        [TestMethod]
        public void OneCommand_Execute()
        {
            _vm.OneCommand.Execute(null);

            Assert.AreEqual("1", _vm.Result);
        }

        [TestMethod]
        public void TwoCommand_Execute()
        {
            _vm.TwoCommand.Execute(null);

            Assert.AreEqual("2", _vm.Result);
        }

        [TestMethod]
        public void ThreeCommand_Execute()
        {
            _vm.ThreeCommand.Execute(null);

            Assert.AreEqual("3", _vm.Result);
        }

        [TestMethod]
        public void FourCommand_Execute()
        {
            _vm.FourCommand.Execute(null);

            Assert.AreEqual("4", _vm.Result);
        }

        [TestMethod]
        public void FiveCommand_Execute()
        {
            _vm.FiveCommand.Execute(null);

            Assert.AreEqual("5", _vm.Result);
        }

        [TestMethod]
        public void SixCommand_Execute()
        {
            _vm.SixCommand.Execute(null);

            Assert.AreEqual("6", _vm.Result);
        }

        [TestMethod]
        public void SevenCommand_Execute()
        {
            _vm.SevenCommand.Execute(null);

            Assert.AreEqual("7", _vm.Result);
        }

        [TestMethod]
        public void EightCommand_Execute()
        {
            _vm.EightCommand.Execute(null);

            Assert.AreEqual("8", _vm.Result);
        }

        [TestMethod]
        public void NineCommand_Execute()
        {
            _vm.NineCommand.Execute(null);

            Assert.AreEqual("9", _vm.Result);
        }

        [TestMethod]
        public void DotCommand_Execute()
        {
            _vm.DotCommand.Execute(null);

            Assert.AreEqual("0.", _vm.Result);
        }

        [TestMethod]
        public void PlusCommand_Execute()
        {
            _vm.ThreeCommand.Execute(null);
            _vm.PlusCommand.Execute(null);
            _vm.TwoCommand.Execute(null);
            _vm.CalculateCommand.Execute(null);

            Assert.AreEqual("5", _vm.Result);
        }

        [TestMethod]
        public void MinusCommand_Execute()
        {
            _vm.ThreeCommand.Execute(null);
            _vm.MinusCommand.Execute(null);
            _vm.TwoCommand.Execute(null);
            _vm.CalculateCommand.Execute(null);

            Assert.AreEqual("1", _vm.Result);
        }

        [TestMethod]
        public void MultiplyCommand_Execute()
        {
            _vm.ThreeCommand.Execute(null);
            _vm.MultiplyCommand.Execute(null);
            _vm.TwoCommand.Execute(null);
            _vm.CalculateCommand.Execute(null);

            Assert.AreEqual("6", _vm.Result);
        }

        [TestMethod]
        public void DivideCommand_Execute()
        {
            _vm.ThreeCommand.Execute(null);
            _vm.DivideCommand.Execute(null);
            _vm.TwoCommand.Execute(null);
            _vm.CalculateCommand.Execute(null);

            Assert.AreEqual("1.5", _vm.Result);
        }

        [TestMethod]
        public void CalculateCommand_Execute()
        {
            // 演算子のテストで実施済み
        }

        [TestMethod]
        public void CCommand_Execute()
        {
            _vm.OneCommand.Execute(null);
            _vm.PlusCommand.Execute(null);
            _vm.TwoCommand.Execute(null);
            // 実行
            _vm.CCommand.Execute(null);

            _vm.ThreeCommand.Execute(null);
            _vm.CalculateCommand.Execute(null);

            // 最初の1が保存されている
            Assert.AreEqual("4", _vm.Result);
        }

        [TestMethod]
        public void ACCommand()
        {
            _vm.OneCommand.Execute(null);
            _vm.PlusCommand.Execute(null);
            _vm.TwoCommand.Execute(null);
            // 実行
            _vm.ACCommand.Execute(null);

            _vm.ThreeCommand.Execute(null);
            _vm.CalculateCommand.Execute(null);

            // 最初の1が保存されていない
            Assert.AreEqual("3", _vm.Result);
        }
    }
}