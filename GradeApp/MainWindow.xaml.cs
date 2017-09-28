using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GradeApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Subject> subjects = new List<Subject>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddOption ad = new AddOption();
            Subject a = ad.ShowDia();
            subjects.Add(a);
            this.List.Items.Add(a.ClassName);
            this.GpaVal.Content = GetGpa();
            this.AvVal.Content = FinalAv().ToString("F3");

        }

        private double GetGpa()
        {
            double value = 0;
            double all = 0;
            foreach (Subject subject in this.subjects)
            {
                double rate;
                if (90 <= subject.Grade && subject.Grade <= 100)
                {
                    rate = 4;
                }
                else if (85 <= subject.Grade && subject.Grade <= 89)
                {
                    rate = 3.7;
                }
                else if (82 <= subject.Grade && subject.Grade <= 84)
                {
                    rate = 3.3;
                }
                else if (78 <= subject.Grade && subject.Grade <= 81)
                {
                    rate = 3.0;
                }
                else if(75 <= subject.Grade && subject.Grade <= 77)
                {
                    rate = 2.7;
                }
                else if (72 <= subject.Grade && subject.Grade <= 74)
                {
                    rate = 2.3;
                }
                else if(68 <= subject.Grade && subject.Grade <= 71)
                {
                    rate = 2.0;
                }
                else if (64 <= subject.Grade && subject.Grade <= 67)
                {
                    rate = 1.5;
                }
                else if (60 <= subject.Grade && subject.Grade <= 63)
                {
                    rate = 1.0;
                }
                else
                {
                    rate = 0;
                }
                value += rate * subject.Credit;
                all += subject.Credit;
            }
            return value / all;
        }

        private double FinalAv()
        {
            double cValue = 0;
            double oValue = 0;
            double all = 0;
            foreach (Subject subject in this.subjects)
            {
                if (subject.IsCompulsory)
                {
                    cValue += subject.GetMultiply();
                    all += subject.Credit;
                }
                else
                {
                    oValue += subject.Grade * 0.002;
                }
            }
            return cValue / all + oValue;
        }
        private void List_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string descri = "";
            int n = this.List.SelectedIndex;
            descri += "Class Name:" + this.subjects[n].ClassName + "\n";
            descri += "Grade: " + this.subjects[n].Grade + "\n";
            descri += "Credit: " + this.subjects[n].Credit + "\n";
            descri += "Is compulsory? " + (this.subjects[n].IsCompulsory ? "Yes" : "No") + "\n";
            descri += "Description: " + this.subjects[n].Description;
            this.TextBox.Text = descri;
        }
    }
}

