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

        public int Value
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNum.Text = _numValue.ToString();
                RaiseValueChangeEvent();
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

        public static readonly RoutedEvent ValueChangeEvent = EventManager.RegisterRoutedEvent(
            "ValueChange", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UpDownControl));
        // Provide CLR accessors for the event
        public event RoutedEventHandler ValueChange
        {
            add { AddHandler(ValueChangeEvent, value); }
            remove { RemoveHandler(ValueChangeEvent, value); }
        }

        // This method raises the Tap event
        void RaiseValueChangeEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(UpDownControl.ValueChangeEvent);
            RaiseEvent(newEventArgs);
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            Value++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            Value--;
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (txtNum == null)
            {
                return;
            }
            
            if (!int.TryParse(txtNum.Text, out _numValue))
            {
                MessageBox.Show("aa");
                txtNum.Text = Value.ToString();
                Value = _numValue;
                
                RaiseValueChangeEvent();
            }
        }

        private void txtNum_KeyDown(object sender, KeyEventArgs e)
        {
            RaiseValueChangeEvent();
        }
    }
}
