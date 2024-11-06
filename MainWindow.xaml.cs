using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2024_WpfApp4
{

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
        //object sender 參數表示觸發事件的物件。這個參數可以用來識別是哪個控制項觸發了事件。
        private void myCanvas_MouseEnter(object sender, MouseEventArgs e) //MouseEventArgs 是一個包含滑鼠事件資訊的類別 ,例如滑鼠的位置、按下的按鈕等
        {
            myCanvas.Cursor = Cursors.Pen; //Cursor屬性用來設置控制項的游標樣式 ; Cursors.Pen 是一個預定義的游標樣式，表示筆刷形狀的游標。
        }

        // 當滑鼠左鍵按下時，記錄起始點座標並更新狀態欄

        private void myCanvas_mouseLeftButtonDown(object sender , MouseButtonEventArgs e) //•	e 參數包含與滑鼠事件相關的數據
        {
            myCanvas.Cursor = Cursors.Cross; //Cursor屬性用來設置控制項的游標樣式 ; Cursors.Cross 是一個預定義的游標樣式，表示十字形的游標。
            start = e.GetPosition(myCanvas); //GetPosition() 方法用來獲取滑鼠相對於指定元素的位置
            DisplayStatus(start, dest); //更新狀態欄顯示的座標信息
            //displayStatus() 方法用來更新狀態欄顯示的座標信息
        }

        // 更新狀態欄顯示的座標信息
        private void DisplayStatus(Point Start, Point Dest) //更新狀態欄顯示的座標信息
        {
            //Convert.ToInt32 方法用來將不同類型的數據轉換為 32 位整數 (int) 類型
            pointLabel.Content = $"({Convert.ToInt32(Start.X)}, {Convert.ToInt32(Start.Y)}) - ({Convert.ToInt32(Dest.X)}, {Convert.ToInt32(Dest.Y)})";
        }

       

        public MainWindow()
        {
            InitializeComponent();//初始化窗口
            strokeColorPicker.SelectedColor = strokeColor; //SelectedColor 屬性用來設置或獲取顏色選擇器的選中顏色
        }
      
        // 當滑鼠在畫布上移動時，更新終點座標並更新狀態欄
        private void myCanvas_MouseMove(object sender, MouseEventArgs e) // mouseMove 事件在滑鼠在控制項上移動時發生
        {
            dest = e.GetPosition(myCanvas); //GetPosition() 方法用來獲取滑鼠相對於指定元素的位置
            DisplayStatus(start, dest); // displayStatus() 方法用來更新狀態欄顯示的座標信息
        }

        // 當滑鼠左鍵釋放時，繪製線條
        private void myCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Brush brush = new SolidColorBrush(strokeColor); //SolidColorBrush 類表示一個固定的顏色筆刷
  
            Line line = new Line //Line 類是 WPF 中的一個圖形元素，用來繪製直線。它繼承自 Shape 類，並提供了多種屬性來設置直線的外觀和位置。
            {
                Stroke = brush,
                StrokeThickness = strokeThickness,
                
                X1 = start.X,
                Y1 = start.Y,
                X2 = dest.X,
                Y2 = dest.Y
            };
            myCanvas.Children.Add(line); //children 屬性用來訪問控制項的子控制項集合 ; Add() 方法用來將指定的子控制項添加到控制項的子控制項集合中
            //myCanvas.Children.Add() 方法用來將指定的子控制項添加到控制項的子控制項集合中
        }
        
    }
}