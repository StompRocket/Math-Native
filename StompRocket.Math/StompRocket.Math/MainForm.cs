using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace StompRocket.Math
{
    public partial class MainForm : Form
    {
        private readonly TextBox MathInput = new TextBox
        {
            PlaceholderText = "Enter an expression",
            Style = "TextConsole",
        };
        private readonly Label MathResult = new Label
        {
            Style = "LargeText"
        };

        private readonly ListBox CalculationBox = new ListBox();
        private readonly LinkedList<Calc> Calculations = new LinkedList<Calc>();

        private CalcModel CalcModel;

        private void AddCalc(double result, string calc)
        {
            Calculations.AddFirst(new Calc(result, calc));
            CalculationBox.Items.Clear();
            foreach (Calc item in Calculations)
            {
                CalculationBox.Items.Add(item.ToString());
            }
        }

        private void Evaluate(object sender, EventArgs e)
        {
            if (CalcModel.Calculation.Trim() != "")
            {
                Console.Out.WriteLine("Evaling");
                Console.Out.WriteLine(CalcModel.Calculation);

                AddCalc(CalcModel.Result, CalcModel.Calculation);

                CalcModel.Calculation = "";
            }
        }

        public MainForm()
        {
            Title = "Stomp Rocket Math";
            ClientSize = new Size(720, 480);

            CalcModel = new CalcModel(MathResult);

            var MathDisplay = new Splitter
            {
                FixedPanel = SplitterFixedPanel.Panel1,
                Orientation = Orientation.Vertical,
                Panel1 = MathInput,
                Panel2 = MathResult,
            };

            Padding = 10;

            Content = new Splitter
            {
                Orientation = Orientation.Vertical,
                FixedPanel = SplitterFixedPanel.Panel1,
                Panel1 = MathDisplay,
                Panel2 = CalculationBox,
            };

            MathInput.TextBinding.Bind(CalcModel, m => m.Calculation);
            //MathResult.TextBinding.Bind(CalcModel, m => m.Calculation, DualBindingMode.OneWay);

            var aboutDialog = new AboutDialog
            {
                ProgramName = "Stomp Rocket Math",
                Developers = new[] { "swissChili" },
                Copyright = "Copyright (c) 2019 Stomp Rocket <stomprocket.io>, All Rights Reserved",
                ProgramDescription = "A Smart Calculator",
                License = License.Text,
            };

            var evalBtn = new Command
            {
                MenuText = "Evaluate",
                Shortcut = Keys.Enter,
            };
            evalBtn.Executed += Evaluate;


            var quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
            quitCommand.Executed += (sender, e) => Application.Instance.Quit();

            var aboutCommand = new Command { MenuText = "About..." };
            aboutCommand.Executed += (sender, e) => aboutDialog.ShowDialog(this);

            // create menu
            Menu = new MenuBar
            {
                Items =
                {
                    // File submenu
                    new ButtonMenuItem { Text = "&File", Items = { evalBtn } },
                    // new ButtonMenuItem { Text = "&Edit", Items = { /* commands/items */ } },
                    // new ButtonMenuItem { Text = "&View", Items = { /* commands/items */ } },
                },
                ApplicationItems =
                {
                    // application (OS X) or file menu (others)
                    new ButtonMenuItem { Text = "&Preferences..." },
                },
                QuitItem = quitCommand,
                AboutItem = aboutCommand
            };

            // create toolbar
            // ToolBar = new ToolBar { Items = { } };
        }
    }
}
