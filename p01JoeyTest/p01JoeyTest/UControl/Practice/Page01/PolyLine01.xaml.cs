using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// Polyline的使用方式
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace p01JoeyTest.UControl.Practice.Page01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PolyLine01 : Page
    {
        private Point _mousePosition;
        private int _selectedPointIndex = -1;

        public PolyLine01()
        {
            this.InitializeComponent();
            // 為 Polyline 的每個頂點添加一個小的可拖曳圓圈
            for (int i = 0; i < draggablePolyline.Points.Count; i++)    //Joey: draggablePolyline是XAML裡 Polyline 的 Name
            {
                Ellipse point = CreateDraggablePoint(draggablePolyline.Points[i]);  //Joey: 建立要存放的 point
                point.Tag = i; // 儲存頂點的索引
                drawingCanvas.Children.Add(point);  //Joey: drawingCanvas是 XAML裡 Canvas 的名稱

                // 註冊滑鼠事件
                point.PointerPressed += DraggablePoint_PointerPressed;
                point.PointerMoved += DraggablePoint_PointerMoved;
                point.PointerReleased += DraggablePoint_PointerReleased;
            }
        }

        private Ellipse CreateDraggablePoint(Point position)
        {
            Ellipse point = new Ellipse();
            point.Width = 50;
            point.Height = 50;
            point.Fill = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);
            point.Stroke = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Black);
            point.StrokeThickness = 1;
            Canvas.SetLeft(point, position.X - point.Width / 2);
            Canvas.SetTop(point, position.Y - point.Height / 2);
            return point;
        }

        private void DraggablePoint_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Ellipse selectedPoint = (Ellipse)sender;    //Joey: 注意,因是Ellipse的 event ,所以 sender 就是Ellipse (注意轉換型態的方法)
            _selectedPointIndex = (int)selectedPoint.Tag;
            PointerPoint currentPoint = e.GetCurrentPoint(drawingCanvas);
            _mousePosition = currentPoint.Position;
            selectedPoint.CapturePointer(e.Pointer); // 捕獲滑鼠，以便在滑鼠移出元素時也能接收事件
        }

        private void DraggablePoint_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (_selectedPointIndex != -1)
            {
                Ellipse currentPointEllipse = (Ellipse)sender;
                PointerPoint currentPoint = e.GetCurrentPoint(drawingCanvas);   // GetCurrentPoint取得現在點的Point
                Point newMousePosition = currentPoint.Position;

                double deltaX = newMousePosition.X - _mousePosition.X;
                double deltaY = newMousePosition.Y - _mousePosition.Y;

                // 更新 Polyline 的頂點位置
                Point oldPoint = draggablePolyline.Points[_selectedPointIndex];
                draggablePolyline.Points[_selectedPointIndex] = new Point(oldPoint.X + deltaX, oldPoint.Y + deltaY);

                // 更新圓圈的位置
                Canvas.SetLeft(currentPointEllipse, Canvas.GetLeft(currentPointEllipse) + deltaX);
                Canvas.SetTop(currentPointEllipse, Canvas.GetTop(currentPointEllipse) + deltaY);

                _mousePosition = newMousePosition;
            }
        }

        private void DraggablePoint_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (_selectedPointIndex != -1)
            {
                ((Ellipse)sender).ReleasePointerCapture(e.Pointer); // 釋放滑鼠捕獲
                _selectedPointIndex = -1;
            }
        }
    }
}
