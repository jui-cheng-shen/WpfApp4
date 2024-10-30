using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2024_WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 起始點和終點的座標
        Point start = new Point { X = 0, Y = 0 };
        Point dest = new Point { X = 0, Y = 0 };

        // 筆刷顏色和粗細
        Color strokeColor = Colors.Red;
        int strokeThickness = 1;

        // 當前選擇的形狀類型
        string shapeType = "";

        // 當滑鼠進入畫布時，將游標設置為筆刷
        private void myCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            myCanvas.Cursor = Cursors.Pen;
        }

        // 當滑鼠左鍵按下時，記錄起始點座標並更新狀態欄
        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            myCanvas.Cursor = Cursors.Cross;
            start = e.GetPosition(myCanvas);
            DisplayStatus(start, dest);
        }

        // 更新狀態欄顯示的座標信息
        private void DisplayStatus(Point start, Point dest)
        {
            pointLabel.Content = $"({Convert.ToInt32(start.X)}, {Convert.ToInt32(start.Y)}) -  ({Convert.ToInt32(dest.X)}, {Convert.ToInt32(dest.Y)})";
        }

        // 初始化主窗口
        public MainWindow()
        {
            InitializeComponent();
            strokeColorPicker.SelectedColor = strokeColor;
        }

        // 當滑鼠在畫布上移動時，更新終點座標並更新狀態欄
        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            dest = e.GetPosition(myCanvas);
            DisplayStatus(start, dest);
        }

        // 當滑鼠左鍵釋放時，繪製線條
        private void myCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // 創建一個新的 SolidColorBrush，並設置其顏色為當前選擇的筆刷顏色
            Brush brush = new SolidColorBrush(strokeColor);

            // 創建一個新的 Line 對象，並設置其屬性
            Line line = new Line
            {
                Stroke = brush,
                StrokeThickness = strokeThickness,
                // 設置線條的起始點 X 座標
                X1 = start.X,
                // 設置線條的起始點 Y 座標
                Y1 = start.Y,
                // 設置線條的終點 X 座標
                X2 = dest.X,
                // 設置線條的終點 Y 座標
                Y2 = dest.Y
            };
            myCanvas.Children.Add(line);
        }

        // 當筆刷粗細滑桿的值改變時，更新筆刷粗細
        private void strokeThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            strokeThickness = Convert.ToInt32(strokeThicknessSlider.Value);
        }

        // 當形狀選擇按鈕被點擊時，更新當前選擇的形狀類型並更新狀態欄
        private void ShapeButton_Click(object sender, RoutedEventArgs e)
        {
          // 將 sender 轉換為 RadioButton 類型
var targetRadioButton = sender as RadioButton;

// 獲取 RadioButton 的 Tag 屬性並將其設置為當前選擇的形狀類型
shapeType = targetRadioButton.Tag.ToString();

// 更新狀態欄顯示當前選擇的形狀類型
shapeLabel.Content = shapeType;

        }
    }
}
