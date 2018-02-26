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
using CCCore;

namespace CardCreater
{
    /// <summary>
    /// ElementControl.xaml 的互動邏輯
    /// </summary>
    public partial class ElementControl : UserControl
    {
        private int _type = 0;
        private int _layer = 0;
        string[] typeName = new string[5];
        

        public ElementControl()
        {
            InitializeComponent();
            typeName[0] = "背景";
            typeName[1] = "邊框";
            typeName[2] = "圖片";
            typeName[3] = "數字";
            typeName[4] = "文字";
        }

        public int Type
        {
            get { return _type; }
            set
            {
                _type = value;
                title.Content = _layer.ToString() + ": " + typeName[_type];
                int h = 231;
                switch (_type)
                {                    
                    case 0: //背景
                        textProperty.Visibility = Visibility.Collapsed;
                        numProperty.Visibility = Visibility.Collapsed;
                        h -= 99;
                        break;
                    case 1: //邊框
                        textProperty.Visibility = Visibility.Collapsed;
                        numProperty.Visibility = Visibility.Collapsed;
                        h -= 99;
                        break;
                    case 2: //圖片
                        textProperty.Visibility = Visibility.Collapsed;
                        numProperty.Visibility = Visibility.Collapsed;
                        h -= 99;
                        break;          
                    case 3: //數字
                        textProperty.Visibility = Visibility.Collapsed;
                        h -= 33;
                        break;
                    case 4: //文字
                        numProperty.Visibility = Visibility.Collapsed;
                        picturePath.Visibility = Visibility.Collapsed;
                        pictureSize.Visibility = Visibility.Collapsed;
                        h -= 99;
                        break;
                }
                this.Height = h;

            }
        }
        public int Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
            }
        }
    }
}
