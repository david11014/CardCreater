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
       
        Card card = new Card();
        List<ElementControl> elements = new List<ElementControl>();

        int _currentel = 0;
        public int currentEl
        {
            get { return _currentel; }
            set
            {
                if(_currentel < elements.Count)
                    elements[_currentel].Selted = false;

                _currentel = value;
                elements[_currentel].Selted = true;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
                        
            AddElement(0);
            elements[0].Selted = true;
            scrollViewer.Width = elements[0].Width + 15;
                       
        }
        void AddElement(int type)
        {
            ElementControl E = new ElementControl(type, elements.Count);
            elements.Add(E);
            elements.Last().TopClick += Element_Click;
            elements.Last().DataChanged += Element_DataChanged;
            
            switch(type)
            {
                case 0:                    
                    card.Set(new CardBackground());
                    break;
                case 1:                    
                    card.Set(new CardFram());
                    break;
                case 2:                    
                    card.Set(new CardImage());
                    break;
                case 3:                    
                    card.Set(new CardImgNum());
                    break;
                case 4:                    
                    card.Set(new CardText());
                    break;                        
            }

            ShowElements();
        }
        void RemoveElement(int i)
        {
            
            if (i > 0 && i < elements.Count)
            {
                if (i < elements.Count - 1)
                {
                    for (int j = i + 1; j < elements.Count; j++)
                    {
                        elements[j].Layer = j - 1;                        
                    }
                }

                elements.RemoveAt(i);
                card.RemoveElements(i);                
            }
            ShowElements();
        }
        void ShowElements()
        {
            stack.Children.Clear();
            for (int i = 0; i < elements.Count; i++)
                stack.Children.Add(elements[i]);

            Render();
        }
        void Render()
        {
            DrawingGroup drawG = new DrawingGroup();

            for (int i = 0; i < card.ElementCount(); i++)
            {
                switch (card.Get(i).type)
                {
                    case 0:
                        DrawImage(card.Get(i), ref drawG);
                        break;
                    case 1:
                        DrawImage(card.Get(i), ref drawG);
                        break;
                    case 2:
                        DrawImage(card.Get(i), ref drawG);
                        break;
                    case 3:

                        break;
                    case 4:
                        DrawText((CardText)card.Get(i), ref drawG);
                        break;
                }
            }

            DrawingImage drawingImageSource = new DrawingImage(drawG);
            drawingImageSource.Freeze();

            image.BeginInit();
            image.Source = drawingImageSource;
            image.EndInit();
            //ImageDrawing a = new ImageDrawing(drawingImageSource, new Rect(new System.Windows.Size(image.Width, image.Height)));
            //SaveDrawingToFile(a, "aa.bmp", 1);
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
                if (path == "")
                    return;
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
        private void Element_DataChanged(object sender, ElementControlEventArgs e)
        {
            var el = new CardElement();
            switch (e.Type)
            {                
                case 0:
                    var cb = new CardBackground();
                    cb.layer = e.Layer;
                    cb.x = (int)e.Locate.X;
                    cb.y = (int)e.Locate.Y;
                    cb.bgPath = e.Path;
                    card.Set(e.Layer, cb);                    
                    break;
                case 1:
                    var cf = new CardFram();
                    cf.layer = e.Layer;
                    cf.x = (int)e.Locate.X;
                    cf.y = (int)e.Locate.Y;
                    cf.bgPath = e.Path;
                    card.Set(e.Layer, cf);
                    break;
                case 2:
                    var ci = new CardImage();
                    ci.layer = e.Layer;
                    ci.x = (int)e.Locate.X;
                    ci.y = (int)e.Locate.Y;
                    ci.bgPath = e.Path;
                    card.Set(e.Layer, ci);
                    break;
                case 3:
                    var cn = new CardImgNum();
                    cn.layer = e.Layer;
                    cn.x = (int)e.Locate.X;
                    cn.y = (int)e.Locate.Y;
                    cn.bgPath = e.Path;
                    cn.num = e.Num;
                    card.Set(e.Layer, cn);

                    break;
                case 4:
                    var ct = new CardText();
                    ct.layer = e.Layer;
                    ct.x = (int)e.Locate.X;
                    ct.y = (int)e.Locate.Y;
                    ct.bgPath = e.Path;
                    ct.Text = e.Text;
                    card.Set(e.Layer, ct);
                    break;
            }

            Render();
        }
        private void Element_Click(object sender, ElementControlEventArgs e)
        {
           if (currentEl == e.Layer)
                return;

            //elements[currentEl].Selted = false;
            currentEl = e.Layer;
            //elements[currentEl].Selted = true;

            ShowElements();

        }
        private void addElementButtom_Click(object sender, RoutedEventArgs e)
        {
            AddElement(TypeSel.SelectedIndex + 1);
        }
        private void removeElementButtom_Click(object sender, RoutedEventArgs e)
        {
            RemoveElement(currentEl);

            if (currentEl >= elements.Count)
                currentEl = elements.Count - 1;
            else
                currentEl = currentEl;

        }


    }
}
