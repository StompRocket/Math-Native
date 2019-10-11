using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Eto.Forms;
using org.mariuszgromada.math.mxparser;

namespace StompRocket.Math
{
    public class CalcModel : INotifyPropertyChanged
    {
        private string calculation = "";
        public string Calculation
        {
            get
            {
                return calculation;
            }
            set
            {
                if (calculation != value)
                {
                    calculation = value;
                    Result++;

                    var e = new Expression(calculation);
                    Result = e.calculate();

                    OutField.Text = Result.ToString();

                    OnPropertyChanged();
                }
            }
        }
        private Label OutField;
        public double Result = 0;
        public bool Success = true;

        public CalcModel(Label o)
        {
            OutField = o;
        }

        private void OnPropertyChanged([CallerMemberName] string access = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(access));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
