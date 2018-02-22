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
using System.Globalization;

namespace CardCreater
{
    
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
                          
            // Create a new DrawingGroup of the control.
            DrawingGroup drawingGroup = new DrawingGroup();

            // Open the DrawingGroup in order to access the DrawingContext.
            using (DrawingContext drawingContext = drawingGroup.Open())
            {
                // Create the formatted text based on the properties set.
                FormattedText formattedText = new FormattedText(
                    "AAAAAAA",
                    CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    new Typeface("Comic Sans MS Bold"),
                    48,
                    System.Windows.Media.Brushes.Black // This brush does not matter since we use the geometry of the text. 
                    );

                // Build the geometry object that represents the text.
                Geometry textGeometry = formattedText.BuildGeometry(new System.Windows.Point(20, 0));

                // Draw a rounded rectangle under the text that is slightly larger than the text.
                drawingContext.DrawRoundedRectangle(System.Windows.Media.Brushes.PapayaWhip, null, new Rect(new System.Windows.Size(formattedText.Width + 50, formattedText.Height + 5)), 5.0, 5.0);

                // Draw the outline based on the properties that are set.
                drawingContext.DrawGeometry(System.Windows.Media.Brushes.Gold, new System.Windows.Media.Pen(System.Windows.Media.Brushes.Maroon, 1.5), textGeometry);                
            }

            DrawingImage drawingImageSource = new DrawingImage(drawingGroup);

            // Freeze the DrawingImage for performance benefits.
            drawingImageSource.Freeze();
            image.Source = drawingImageSource;
        }



    }
}
