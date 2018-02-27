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
using System.Drawing;
using Media = System.Windows.Media;
using System.Globalization;
using CCCore;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Collections.Generic;


namespace CardCreater
{
    
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        DrawingGroup drawG = new DrawingGroup();
        Card card = new Card();

        public MainWindow()
        {
            InitializeComponent();         
        }

        Geometry CardText2Geometry(CCCore.CardText T)
        {
            Font f = T.font;
            Media.FontFamily fontFamily = new Media.FontFamily(f.Name);
            Typeface typeface = new Typeface(fontFamily, (f.Style == System.Drawing.FontStyle.Italic ? FontStyles.Italic : FontStyles.Normal),
                         (f.Style == System.Drawing.FontStyle.Bold ? FontWeights.Bold : FontWeights.Normal),
                                    FontStretches.Normal);


            FormattedText formattedText = new FormattedText(
                   T.Text,
                   CultureInfo.GetCultureInfo("en-us"),
                   FlowDirection.LeftToRight,
                   typeface,
                   48,
                   System.Windows.Media.Brushes.Black // This brush does not matter since we use the geometry of the text. 
                   );
            
            Geometry textGeometry = formattedText.BuildGeometry(new System.Windows.Point(0, 0));
            
            return textGeometry;
        }

        void Render()
        {
            DrawingImage drawingImageSource = new DrawingImage(drawG);            
            drawingImageSource.Freeze();     

            image.BeginInit();                
            image.Source = drawingImageSource;
            image.EndInit();
            //ImageDrawing a = new ImageDrawing(drawingImageSource, new Rect(new System.Windows.Size(image.Width, image.Height)));
            //SaveDrawingToFile(a, "aa.bmp", 1);
        }

        void DrawText(CardText T, ref DrawingGroup drawingGroup)
        {
            
           using (DrawingContext drawingContext = drawingGroup.Append())
           {
                // Build the geometry object that represents the text.
                Geometry textGeometry = CardText2Geometry(T);
               
                var converter = new System.Windows.Media.BrushConverter();
                var inBrush = (Media.Brush)converter.ConvertFromString(T.GetColorHex());
                Media.Pen p = new Media.Pen(System.Windows.Media.Brushes.Maroon, 1.0);

                // Draw the outline based on the properties that are set.
                drawingContext.DrawGeometry(inBrush, p, textGeometry);
            }
                       
        }

        void DrawImage(CardElement ce, ref DrawingGroup drawingGroup)
        {
            using (DrawingContext drawingContext = drawingGroup.Append())
            {
                string path = ce.GetBackGroundPath();
                BitmapImage source = new BitmapImage(new Uri(path));
                //drawingContext.DrawImage(source, new Rect(new System.Windows.Size(image.Width, image.Height)));
                drawingContext.DrawImage(source, new Rect(new System.Windows.Size(30,30)));
            }
               
        }

        public void SaveDrawingToFile(Drawing drawing, string fileName, double scale)
        {
            var drawingImage = new System.Windows.Controls.Image { Source = new DrawingImage(drawing) };
            var width = drawing.Bounds.Width * scale;
            var height = drawing.Bounds.Height * scale;
            drawingImage.Arrange(new Rect(0, 0, width, height));

            var bitmap = new RenderTargetBitmap((int)width, (int)height, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(drawingImage);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                encoder.Save(stream);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                card.Get(0).SetBackGroundPath(openFileDialog.FileName);
                DrawImage(card.Get(0),ref drawG);

                CardText TT = new CardText();
                TT.Text = "AAAA";
                card.Set(TT);
                DrawText((CardText)card.Get(1), ref drawG);
                Render();
            }
        }

        private void ElementControl_OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Element1.pathTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}
