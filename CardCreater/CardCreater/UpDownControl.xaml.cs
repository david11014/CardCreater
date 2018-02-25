using System;
using System.Collections.Generic;
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

namespace CardCreater
{
    /// <summary>
    /// UpDownControl.xaml 的互動邏輯
    /// </summary>
    public partial class UpDownControl : UserControl
    {
        private int _numValue = 0;

        public UpDownControl()
        {
            InitializeComponent();
            txtNum.Text = _numValue.ToString();
        }

        public UpDownControl(UpDownControl c)
        {            
            InitializeComponent();
            _numValue = c._numValue;
            txtNum.Text = _numValue.ToString();
        }

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNum.Text = value.ToString();
            }
        }
        public string Text
        {
            get { return textLable.Content.ToString(); }
            set
            {
                textLable.Content = value;
            }
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum == null)
            {
                return;
            }

            if (!int.TryParse(txtNum.Text, out _numValue))
                txtNum.Text = _numValue.ToString();
        }
    }
}
