﻿using System;
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
using WpfColorFontDialog;

namespace CardCreater
{
    /// <summary>
    /// ElementControl.xaml 的互動邏輯
    /// </summary>
    ///

    
    public class ElementControlEventArgs : EventArgs
    {
       
        public ElementControlEventArgs(int type, int layer, int x, int y,int num,string path,string text)
        {
            _type = type;
            _layer = layer;
            _path = path;
            _locate = new Point(x, y);
            _num = num;
            _text = text;
        }
        private int _type;
        private int _layer;
        private string _path;
        private Point _locate;
        private int _num;
        private string _text;

        public int Type
        {
            get { return _type; }
        }
        public string TypeName
        {
            get
            {
                string[] typeName = new string[5];
                typeName[0] = "背景";
                typeName[1] = "邊框";
                typeName[2] = "圖片";
                typeName[3] = "數字";
                typeName[4] = "文字";

                return TypeName[_type].ToString();
            }
        }
        public int Layer
        {
            get { return _layer; }
        }
        public string Path
        {
            get { return _path; }
        }
        public int Num
        {
            get { return _num; }
        }
        public string Text
        {
            get { return _text; }
        }
        public Point Locate
        {
            get { return _locate; }
        }

    }
    public delegate void ElementEventHandler(object sender, ElementControlEventArgs e);
    
    public partial class ElementControl : UserControl
    {
        private int _type = 0;
        private int _layer = 0;
        bool _selted = false;
        bool _downflag = false;
        string[] typeName = new string[5];
              
        public ElementControl()
        {
            InitializeComponent();
            typeName[0] = "背景";
            typeName[1] = "邊框";
            typeName[2] = "圖片";
            typeName[3] = "數字";
            typeName[4] = "文字";
            textBorderColor.SelectedColor = new FontColor("Black", Brushes.Black);
        }
        public ElementControl(int type, int layer )
        {
            InitializeComponent();
            typeName[0] = "背景";
            typeName[1] = "邊框";
            typeName[2] = "圖片";
            typeName[3] = "數字";
            typeName[4] = "文字";
            textBorderColor.SelectedColor = new FontColor("Black", Brushes.Black);
            Type = type;
            Layer = layer;
        }

        public int Type
        {
            get { return _type; }
            set
            {
                _type = value;
                title.Content = _layer.ToString() + ": " + typeName[_type];
                int h = 264;
                switch (_type)
                {                    
                    case 0: //背景
                        elementLocate.Visibility = Visibility.Collapsed;
                        textProperty.Visibility = Visibility.Collapsed;
                        textContent.Visibility = Visibility.Collapsed;
                        numProperty.Visibility = Visibility.Collapsed;
                        pictureSize.Visibility = Visibility.Collapsed;
                        LayerControl.Visibility = Visibility.Collapsed;
                        h  = 66;
                        break;
                    case 1: //邊框
                        elementLocate.Visibility = Visibility.Collapsed;
                        textProperty.Visibility = Visibility.Collapsed;
                        textContent.Visibility = Visibility.Collapsed;
                        numProperty.Visibility = Visibility.Collapsed;
                        pictureSize.Visibility = Visibility.Collapsed;
                        h  = 66;
                        break;
                    case 2: //圖片
                        textProperty.Visibility = Visibility.Collapsed;
                        textContent.Visibility = Visibility.Collapsed;
                        numProperty.Visibility = Visibility.Collapsed;
                        h = 132;
                        break;          
                    case 3: //數字
                        textProperty.Visibility = Visibility.Collapsed;
                        textContent.Visibility = Visibility.Collapsed;
                        h -= 99;
                        break;
                    case 4: //文字
                        numProperty.Visibility = Visibility.Collapsed;
                        picturePath.Visibility = Visibility.Collapsed;
                        pictureSize.Visibility = Visibility.Collapsed;
                        h -= 99;
                        break;
                }
                this.Height = h + 3;

            }
        }
        public int Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
                title.Content = _layer.ToString() + ": " + typeName[_type];
            }
        }
        public bool Selted
        {
            get { return _selted; }
            set
            {
                _selted = value;
                if(!_selted)
                {
                    Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180));
                    BorderThickness = new Thickness(0,0,0,0);
                }
                else
                {
                    Background =  new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    BorderThickness = new Thickness(5,0,0,0);
                }
            }
        }
        public string Text
        {
            get
            {
                TextRange textRange = new TextRange(                    
                    richTextBox.Document.ContentStart,                    
                    richTextBox.Document.ContentEnd
                );
                return textRange.Text;
            }
            
        }

        /**event****************************************************************************************/
        //DataChange
        public event ElementEventHandler DataChanged;
        protected virtual void OnDataChanged(ElementControlEventArgs e)
        {
            DataChanged(this, e);
        }
        void RiseDataChangedEvent()
        {
           try
            {
                OnDataChanged(new ElementControlEventArgs(_type,
                    _layer, xUpDownControl.Value,
                    yUpDownControl.Value,
                    numUpDownControl.Value,
                    pathTextBox.Text, Text));
            }
            catch
            {
                return;
            }            
        }
        //OpenFile
        public static readonly RoutedEvent OpenFileEvent = EventManager.RegisterRoutedEvent(
            "OpenFile", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ElementControl));
        public event RoutedEventHandler OpenFile
        {
            add { AddHandler(OpenFileEvent, value); }
            remove { RemoveHandler(OpenFileEvent, value); }
        }
        void RaiseOpenFileEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ElementControl.OpenFileEvent);
            RaiseEvent(newEventArgs);
        }
        private void pathButton_Click(object sender, RoutedEventArgs e)
        {
            var oldvalue = pathTextBox.Text;
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pathTextBox.Text = openFileDialog.FileName;
            }
            RaiseOpenFileEvent();
            if (oldvalue != pathTextBox.Text)
            {
                RiseDataChangedEvent();
            }
                
        }
        private void element_ValueCahange(object sender, RoutedEventArgs e)
        {
            RiseDataChangedEvent();
        }
        

        //TextChange
        public static readonly RoutedEvent TextChangeEvent = EventManager.RegisterRoutedEvent(
        "TextChange", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ElementControl));
        public event RoutedEventHandler TextChange
        {
            add { AddHandler(TextChangeEvent, value); }
            remove { RemoveHandler(TextChangeEvent, value); }
        }
        void RaiseTextChangeEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ElementControl.TextChangeEvent);
            RaiseEvent(newEventArgs);
        }
        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RaiseTextChangeEvent();
            RiseDataChangedEvent();
        }

        //Font buttom click
        public event ElementEventHandler FontButtonClick;
        protected virtual void OnFontButtonClick(ElementControlEventArgs e)
        {
            FontButtonClick(this, e);
        }
        void RaiseFontButtonClickEvent()
        {
            try
            {
                OnFontButtonClick(new ElementControlEventArgs(_type,
                    _layer, xUpDownControl.Value,
                    yUpDownControl.Value,
                    numUpDownControl.Value,
                    pathTextBox.Text, Text));
            }
            catch
            {
                return;
            }
        }
        private void fontButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseFontButtonClickEvent();
        }

        private void top_MouseEnter(object sender, MouseEventArgs e)
        {
            if(!_selted)
                elementTop.Background = new SolidColorBrush(Color.FromArgb(200, 255, 255, 255));
            else
            {
                elementTop.Background = new SolidColorBrush(Color.FromArgb(100, 0, 0, 0));
            }
                
        }

        private void top_MouseLeave(object sender, MouseEventArgs e)
        {
            elementTop.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            _downflag = false;
        }

        //TopClick
        public event ElementEventHandler TopClick;
        protected virtual void OnTopClick(ElementControlEventArgs e)
        {
            TopClick(this, e);
        }
        void RiseTopClickEvent()
        {
            try
            {
                OnTopClick(new ElementControlEventArgs(_type,
                    _layer, xUpDownControl.Value,
                    yUpDownControl.Value,
                    numUpDownControl.Value,
                    pathTextBox.Text, Text));
            }
            catch
            {
                return;
            }
        }
        private void elementTop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _downflag = true;
            
        }
        private void elementTop_MouseUp(object sender, MouseButtonEventArgs e)
        {            
            if (_downflag)
            {
                _downflag = false;               
                RiseTopClickEvent();
            }
        }

        //layerUp Click
        public event ElementEventHandler LayerUpClick;
        protected virtual void OnLayerUpClick(ElementControlEventArgs e)
        {
            LayerUpClick(this, e);
        }
        void RaiselayerUpClickEvent()
        {
            try
            {
                OnLayerUpClick(new ElementControlEventArgs(_type,
                    _layer, xUpDownControl.Value,
                    yUpDownControl.Value,
                    numUpDownControl.Value,
                    pathTextBox.Text, Text));
            }
            catch
            {
                return;
            }
        }
        private void layerUp_Click(object sender, RoutedEventArgs e)
        {
            RaiselayerUpClickEvent();
        }

        //layerdown Click
        public event ElementEventHandler LayerDownClick;
        protected virtual void OnLayerDownClick(ElementControlEventArgs e)
        {
            LayerDownClick(this, e);
        }
        void RaiselayerDownClickEvent()
        {
            try
            {
                OnLayerDownClick(new ElementControlEventArgs(_type,
                    _layer, xUpDownControl.Value,
                    yUpDownControl.Value,
                    numUpDownControl.Value,
                    pathTextBox.Text, Text));
            }
            catch
            {
                return;
            }
        }
        private void layerDown_Click(object sender, RoutedEventArgs e)
        {
            RaiselayerDownClickEvent();
        }

        //layerdown Click
        public event ElementEventHandler DeletElementClick;
        protected virtual void OnDeletElementClick(ElementControlEventArgs e)
        {
            DeletElementClick(this, e);
        }
        void RaiseDeletElementClickEvent()
        {
            try
            {
                OnDeletElementClick(new ElementControlEventArgs(_type,
                    _layer, xUpDownControl.Value,
                    yUpDownControl.Value,
                    numUpDownControl.Value,
                    pathTextBox.Text, Text));
            }
            catch
            {
                return;
            }
        }
        private void deletElement_Click(object sender, RoutedEventArgs e)
        {
            RaiseDeletElementClickEvent();
        }

        //TextBorderSatusChange
        public static readonly RoutedEvent TextBorderSatusChangeEvent = EventManager.RegisterRoutedEvent(
        "TextBorderSatusChange", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ElementControl));
        public event RoutedEventHandler TextBorderSatusChange
        {
            add { AddHandler(TextBorderSatusChangeEvent, value); }
            remove { RemoveHandler(TextBorderSatusChangeEvent, value); }
        }
        void RaiseTextBorderSatusChangeEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ElementControl.TextBorderSatusChangeEvent);
            RaiseEvent(newEventArgs);
        }
        private void textBorderCheckBox_CheckChange(object sender, RoutedEventArgs e)
        {
            if (textBorderColor == null || textBorderSize == null)
                return;

            textBorderColor.IsEnabled = (bool)textBorderCheckBox.IsChecked;
            textBorderSize.IsEnabled = (bool)textBorderCheckBox.IsChecked;

            RaiseTextBorderSatusChangeEvent();
        }

        private void textBorderColor_ColorChanged(object sender, RoutedEventArgs e)
        {
            RaiseTextBorderSatusChangeEvent();
        }
    }


}
