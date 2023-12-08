using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;

namespace SumaAppMvvm
{
   
    public class MainViewModel : ObservableObject
    {
        private double _value1;
        private double _value2;
        private double _result;

        public double Value1
        {
            get => _value1;
            set
            {
                if (SetProperty(ref _value1, value))
                {
                    ValidateInputs();
                }
            }
        }

        public double Value2
        {
            get => _value2;
            set
            {
                if (SetProperty(ref _value2, value))
                {
                    ValidateInputs();
                }
            }
        }

        public double Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public Command SumCommand => new Command(ExecuteSum, CanExecuteSum);
        public Command ClearCommand => new Command(ExecuteClear);

        private void ValidateInputs()
        {
            // Validar que los campos no estén vacíos y que sean números
            bool isValue1Valid = !string.IsNullOrWhiteSpace(Value1.ToString()) && double.TryParse(Value1.ToString(), out _);
            bool isValue2Valid = !string.IsNullOrWhiteSpace(Value2.ToString()) && double.TryParse(Value2.ToString(), out _);

            ((Command)SumCommand).ChangeCanExecute();
        }

        private void ExecuteSum()
        {
            // Validar antes de realizar la suma
            if (CanExecuteSum())
            {
                Result = Value1 + Value2;
            }
        }

        private bool CanExecuteSum()
        {
            // Validar que los campos sean números
            return !string.IsNullOrWhiteSpace(Value1.ToString()) && !string.IsNullOrWhiteSpace(Value2.ToString()) &&
                   double.TryParse(Value1.ToString(), out _) && double.TryParse(Value2.ToString(), out _);
        }

        private void ExecuteClear()
        {
            // Limpiar los campos
            Value1 = 0;
            Value2 = 0;
            Result = 0;
        }
    }
}
