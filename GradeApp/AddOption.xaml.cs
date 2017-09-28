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
using System.Windows.Shapes;

namespace GradeApp
{
    /// <summary>
    /// AddOption.xaml 的交互逻辑
    /// </summary>
    public partial class AddOption : Window
    {
        private int stage = 1;
        public AddOption()
        {
            
            InitializeComponent();
        }

        private Subject subject = new Subject();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (stage)
            {
                case 1:
                    if (this.Content.Text != "")
                    {
                        this.subject.ClassName = this.Content.Text;
                        Step("请输入您的成绩");
                    }
                    else
                    {
                        this.Warning.Content = "别闹，朋友";
                    }
                    break;
                case 2:
                    if (this.Content.Text != "")
                    {
                        this.subject.Grade = int.Parse(this.Content.Text);
                        Step("这么课的学分是多少？");
                    }
                    else
                    {
                        this.Warning.Content = "别闹，朋友";
                    }
                    break;
                case 3: 
                    if (this.Content.Text != "")
                    {
                        this.subject.Credit = int.Parse(this.Content.Text);
                        Step("请问您对这门课有什么评价吗");
                    }
                    else
                    {
                        this.Warning.Content = "别闹，朋友";
                    }
                    break;
                case 4:

                    this.subject.Description = this.Content.Text;

                    Step("这门课是必修课吗？");
                    this.Content.Visibility = Visibility.Collapsed;
                    this.RadioButton1.Visibility = Visibility.Visible;
                    this.RadioButton2.Visibility = Visibility.Visible;
           
                    break;
                case 5:
                    this.subject.IsCompulsory = (bool) this.RadioButton1.IsChecked;
                    this.RadioButton1.Visibility = Visibility.Collapsed;
                    this.RadioButton2.Visibility = Visibility.Collapsed;
                    this.NextBtn.Content = "Finished";
                    this.Label.Content = "Finish";
                    this.stage++;
                    break;
                default:
                    this._fin = true;
                    this.Close();
                    break;
            }
        }

      
        private bool _fin = false;
        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        public Subject ShowDia()
        {
            this.ShowDialog();
            if (_fin)
            {
                return this.subject;
            }
            else
            {
                return null;
            }
        }

        public Subject GetSubject()
        {
            return this.subject;
        }
        
        public void Step(string labelContent)
        {
            this.NextBtn.Content = "Next";
            this.stage++;
            this.Content.Text = "";
            this.Label.Content = labelContent;
            this.Warning.Content = "";
        }
    }
}
