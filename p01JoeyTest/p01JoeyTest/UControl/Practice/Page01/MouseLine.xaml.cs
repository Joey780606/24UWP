using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace p01JoeyTest.UControl.Practice.Page01
{
    /// <summary>
    /// This program's function is draw a line with mouse
    /// </summary>
    public sealed partial class MouseLine : Page
    {
        private Point _startPoint;
        private Line _currentLine;
        private bool _isDrawing = false;

        public MouseLine()
        {
            this.InitializeComponent();
        }

        private void DrawingCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerDeviceType == PointerDeviceType.Mouse && e.GetCurrentPoint(drawingCanvas).Properties.IsLeftButtonPressed ||
                e.Pointer.PointerDeviceType != PointerDeviceType.Mouse) // 支援觸控
            {
                if (!_isDrawing)
                {
                    _isDrawing = true;
                    _startPoint = e.GetCurrentPoint(drawingCanvas).Position;

                    _currentLine = new Line
                    {
                        X1 = _startPoint.X,
                        Y1 = _startPoint.Y,
                        Stroke = new SolidColorBrush(Colors.Black),
                        StrokeThickness = 2
                    };

                    drawingCanvas.Children.Add(_currentLine);
                }
            }
        }

        private void DrawingCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (_isDrawing)
            {
                Point currentPoint = e.GetCurrentPoint(drawingCanvas).Position;
                _currentLine.X2 = currentPoint.X;
                _currentLine.Y2 = currentPoint.Y;
            }
        }

        private void DrawingCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            _isDrawing = false;
            // 線條繪製完成後的處理 (可選)
        }
    }
}
