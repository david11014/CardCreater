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
using WpfColorFontDialog;

namespace CardCreater
{
    
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
       
        Card card = new Card();
        List<ElementControl> elements = new List<ElementControl>();
        List<FontInfo> fonts = new List<FontInfo>();

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
            
            card.width = cardWidth.Value;
            card.height = cardHeight.Value;

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
            elements.Last().LayerUpClick += LayerUp_Click;
            elements.Last().LayerDownClick += LayerDown_Click;
            elements.Last().DeletElementClick += DeletElement_Click;
            elements.Last().FontButtonClick += FontButton_Click;
            elements.Last().TextBorderSatusChange += TextBorderCheck_Change;

            fonts.Add(FontInfo.GetControlFont(cardWidth));

            switch (type)
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
                fonts.RemoveAt(i);
                card.RemoveElements(i);                                
            }
            ShowElements();
        }
        void SwapElement(int a,int b)
        {
            if ((a > b && (a >= elements.Count || b <= 0)) || (a < b && (b >= elements.Count || a <= 0)) || a == b)
                return;


            card.Swap(a, b);

            ElementControl temp;
            temp = elements[a];
            elements[a] = elements[b];
            elements[b] = temp;

            elements[a].Layer = a;
            elements[b].Layer = b;

            FontInfo tempF;
            tempF = fonts[a];

            fonts[a] = fonts[b];
            fonts[b] = tempF;

            ShowElements();
        }
        void ShowElements()
        {
            stack.Children.Clear();
            for (int i = 0; i < elements.Count; i++)
                stack.Children.Add(elements[i]);

            Render();
        }
        DrawingImage Render()
        {
            if (image == null)
                return null;

            DrawingGroup drawG = new DrawingGroup();
            
            for (int i = 0; i < card.ElementCount(); i++)
            {
                switch (card.Get(i).type)
                {
                    case 0:
                        DrawBackGround(card.Get(i), ref drawG);
                        break;
                    case 1:
                        DrawBackGround(card.Get(i), ref drawG);
                        break;
                    case 2:
                        DrawImage((CardImage)card.Get(i), ref drawG);
                        break;
                    case 3:

                        break;
                    case 4:
                        DrawText((CardText)card.Get(i), ref drawG);
                        break;
                }
            }
            DrawingGroup drawGR = drawG.Clone();
            
            DrawingImage returnDrawingImageSource = new DrawingImage(drawGR);
            returnDrawingImageSource.Freeze();

            System.Diagnostics.Debug.Assert(RenderDebug(ref drawG));
            DrawingImage drawingImageSource = new DrawingImage(drawG);
            
            drawingImageSource.Freeze();

            image.BeginInit();
            image.Source = drawingImageSource;
            image.EndInit();

            
            
            return returnDrawingImageSource;

        }
                
        bool RenderDebug(ref DrawingGroup drawG)
        {
            DrawRectangle(ref drawG);
            return true;
        }

        Geometry CardText2Geometry(CCCore.CardText T)
        {            
            FontInfo F = fonts[T.layer];           
            
            Typeface typeface = new Typeface(F.Family, F.Typeface.Style, F.Weight, F.Stretch);

            FormattedText formattedText = new FormattedText(
                   T.Text,
                   CultureInfo.GetCultureInfo("en-us"),
                   FlowDirection.LeftToRight,
                   typeface,
                   F.Size,
                   Media.Brushes.Black
                   );

            Geometry textGeometry = formattedText.BuildGeometry(new System.Windows.Point(T.x, T.y));
            
            
            return textGeometry;
        }

        void DrawRectangle(ref DrawingGroup drawingGroup)
        {
            using (DrawingContext drawingContext = drawingGroup.Append())
            {
                drawingContext.DrawRectangle(null, new Media.Pen(Media.Brushes.Red, 2), new Rect(-1, -1, card.width+2, card.height+2));
            }
        }
        void DrawText(CardText T, ref DrawingGroup drawingGroup)
        {

            if (T.Text == "")
                return;

           using (DrawingContext drawingContext = drawingGroup.Append())
           {
                // Build the geometry object that represents the text.
                Geometry textGeometry = CardText2Geometry(T);
               
                var converter = new System.Windows.Media.BrushConverter();
                var inBrush = fonts[T.layer].BrushColor;

                if((bool)elements[T.layer].textBorderCheckBox.IsChecked)
                {
                    //var st = new ScaleTransform (1.2, 1.2);
                    Geometry textShadowGeometry = textGeometry;
                    var shadowBrush = elements[T.layer].textBorderColor.SelectedColor.Brush.Clone();
                    shadowBrush.Color = Media.Color.FromArgb(200, shadowBrush.Color.R, shadowBrush.Color.G, shadowBrush.Color.B);
                    Media.Pen p = new Media.Pen(shadowBrush, elements[T.layer].textBorderSize.Value * 2);
                    
                    drawingContext.DrawGeometry(null, p, textShadowGeometry);
                    drawingContext.DrawGeometry(inBrush, null, textGeometry);
                    
                }
                else
                {
                    drawingContext.DrawGeometry(inBrush, null, textGeometry);
                }
                
            }
                       
        }
        void DrawImageNum(CardImgNum cn, ref DrawingGroup drawingGroup)
        {
            using (DrawingContext drawingContext = drawingGroup.Append())
            {
                string path = cn.GetBackGroundPath();
                if (path == "")
                    return;

                //BitmapImage source = new BitmapImage(new Uri(path));
                //CroppedBitmap CroppedSource = new CroppedBitmap(source, new Int32Rect(0, 0, halfWidth, height));
                //drawingContext.DrawImage(source, new Rect(cn.x, cn.y, cn.Width, cn.Height));
            }

        }
        void DrawImage(CardImage ci, ref DrawingGroup drawingGroup)
        {
            using (DrawingContext drawingContext = drawingGroup.Append())
            {
                string path = ci.GetBackGroundPath();
                if (path == "")
                    return;

                BitmapImage source = new BitmapImage(new Uri(path));
                    
                drawingContext.DrawImage(source, new Rect(ci.x,ci.y,ci.Width,ci.Height));
            }
               
        }
        void DrawBackGround(CardElement ce, ref DrawingGroup drawingGroup)
        {
            using (DrawingContext drawingContext = drawingGroup.Append())
            {
                string path = ce.GetBackGroundPath();
                if (path == "")
                    return;
                BitmapImage source = new BitmapImage(new Uri(path));
                drawingContext.DrawImage(source, new Rect(0, 0, card.width, card.height));
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

            string Extension = System.IO.Path.GetExtension(fileName).ToLower();


            BitmapEncoder encoder;
            if (Extension == ".gif")
                encoder = new GifBitmapEncoder();
            else if (Extension == ".png")
                encoder = new PngBitmapEncoder();
            else if (Extension == ".jpg")
                encoder = new JpegBitmapEncoder();
            else
                return;

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
                    ci.Width = elements[e.Layer].pictureWidth.Value;
                    ci.Height = elements[e.Layer].pictureHeight.Value;
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

        private void DeletElement_Click(object sender, ElementControlEventArgs e)
        {
            RemoveElement(e.Layer);

            if (currentEl >= elements.Count)
                currentEl = elements.Count - 1;
            else
                currentEl = currentEl;
        }

        private void LayerUp_Click(object sender, ElementControlEventArgs e)
        {
            SwapElement(e.Layer, e.Layer - 1);
        }
        private void LayerDown_Click(object sender, ElementControlEventArgs e)
        {
            SwapElement(e.Layer, e.Layer + 1);
        }

        private void image_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Render();
        }

        private void cardWidth_ValueChange(object sender, RoutedEventArgs e)
        {
            card.width = cardWidth.Value;            
            Render();
        }

        private void cardHeight_ValueChange(object sender, RoutedEventArgs e)
        {            
            card.height = cardHeight.Value;
            Render();
        }
        
        private void FontButton_Click(object sender, ElementControlEventArgs e)
        {
            ColorFontDialog CF = new ColorFontDialog(true, true, true);
            CF.Owner = this;
            CF.Font = fonts[e.Layer];

            CF.FontSizes = new int[] { 20, 30, 40, 50, 60 };
            if (CF.ShowDialog() == true)
            {
                FontInfo font = CF.Font;
                if (font != null)
                {
                    fonts[e.Layer] = CF.Font;
                    Render();
                }
            }
        }

        private void TextBorderCheck_Change(object sender, RoutedEventArgs e)
        {         
            Render();
        }

        private void saveFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DrawingImage drawingImageSource = Render();
            drawingImageSource.Freeze();

            ImageDrawing a = new ImageDrawing(drawingImageSource, new Rect(new System.Windows.Size(drawingImageSource.Width, drawingImageSource.Height)));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|GIF (*.gif)|*.gif";
            if (saveFileDialog.ShowDialog() == true)
            {
                SaveDrawingToFile(a, saveFileDialog.FileName, 1);
            }               
            
        }

        private void exitFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
