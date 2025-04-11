using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Input.Spatial;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using static p01JoeyTest.UControl.Practice.GraphButtonControl1;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace p01JoeyTest.UControl.Practice
{
    public sealed partial class GraphButtonControl1 : UserControl
    {
        int cntHeight = 0;
        int cntWidth = 0;

        int[,] pntPosition = { { 2, 8 }, { 4, 6 }, { 6, 4 }, { 8, 2 } };
        int nowPosition = -1;
        GridInfo gridInfo = new GridInfo(0, 0, 0, 0);

        public GraphButtonControl1()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cntHeight = (int)GraphControl.ActualHeight;
            cntWidth = (int)GraphControl.ActualWidth;
            InfoText.Text = "Height: " + cntHeight + " ,Width: " + cntWidth;

            //Define the border
            gridInfo.h_start = 10;
            gridInfo.w_start = 10;
            gridInfo.h_interval = (cntHeight - 20) / 10;
            gridInfo.w_interval = (cntWidth - 20) / 10;
            GridCanvasProcess2(cntHeight, cntWidth);    //畫邊際線
            GridPointList();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GridPointList()
        {
            Debug.WriteLine("Point info:" + gridInfo.w_start + pntPosition[0, 0] * gridInfo.w_interval + " , " + PointButton1.ActualWidth + " , " + PointButton1.ActualHeight);
            PointButton0.Margin = new Thickness(gridInfo.w_start + pntPosition[0, 0] * gridInfo.w_interval - (PointButton0.ActualWidth / 2), gridInfo.h_start + pntPosition[0, 1] * gridInfo.h_interval - (PointButton0.ActualHeight / 2), 0, 0);
            PointButton1.Margin = new Thickness(gridInfo.w_start + pntPosition[1, 0] * gridInfo.w_interval - (PointButton1.ActualWidth / 2), gridInfo.h_start + pntPosition[1, 1] * gridInfo.h_interval - (PointButton1.ActualHeight / 2), 0, 0);
            PointButton2.Margin = new Thickness(gridInfo.w_start + pntPosition[2, 0] * gridInfo.w_interval - (PointButton2.ActualWidth / 2), gridInfo.h_start + pntPosition[2, 1] * gridInfo.h_interval - (PointButton2.ActualHeight / 2), 0, 0);
            PointButton3.Margin = new Thickness(gridInfo.w_start + pntPosition[3, 0] * gridInfo.w_interval - (PointButton3.ActualWidth / 2), gridInfo.h_start + pntPosition[3, 1] * gridInfo.h_interval - (PointButton3.ActualHeight / 2), 0, 0);

            GrinDrawLine();
        }

        private void GrinDrawLine()
        {
            Line line = new Line
            {
                X1 = 10,
                X2 = 10 + (pntPosition[0, 0] * gridInfo.w_interval),
                Y1 = 10 + (gridInfo.h_interval * 10),
                Y2 = 10 + (pntPosition[0, 1] * gridInfo.h_interval),
                StrokeThickness = 1
            };

            line.Stroke = new SolidColorBrush(Color.FromArgb(160, 255, 255, 255));  // It needs "using Windows.UI;"

            GridCanvas.Children.Add(line);

            for (int i = 0; i < 3; i++)
            {
                Line line2 = new Line
                {
                    X1 = 10 + (pntPosition[i, 0] * gridInfo.w_interval),
                    X2 = 10 + (pntPosition[i + 1, 0] * gridInfo.w_interval),
                    Y1 = 10 + (pntPosition[i, 1] * gridInfo.h_interval),
                    Y2 = 10 + (pntPosition[i + 1, 1] * gridInfo.h_interval),
                    StrokeThickness = 1
                };
                line2.Stroke = new SolidColorBrush(Color.FromArgb(160, 255, 255, 255));  // It needs "using Windows.UI;"

                GridCanvas.Children.Add(line2);

            }

            line = new Line
            {
                X1 = 10 + (pntPosition[3, 0] * gridInfo.w_interval),
                X2 = 10 + (gridInfo.w_interval * 10),
                Y1 = 10 + (pntPosition[3, 1] * gridInfo.h_interval),
                Y2 = 10,
                StrokeThickness = 1
            };
            line.Stroke = new SolidColorBrush(Color.FromArgb(160, 255, 255, 255));  // It needs "using Windows.UI;"

            GridCanvas.Children.Add(line);
            GridCanvas.UpdateLayout();
        }

        /// <summary>
        /// Draw 10 x and y axis line.
        /// </summary>
        /// <param name="h"></param>
        /// <param name="w"></param>
        private void GridCanvasProcess2(int h, int w)    // It work.
        {
            double h_start = 10;
            double w_start = 10;
            double h_interval = (h - 20) / 10;
            double w_interval = (w - 20) / 10;

            GridCanvas.Children.Clear();
            for (double c = w_start; c < w; c += w_interval)
            {

                Line line = new Line
                {
                    X1 = c,
                    X2 = c,
                    Y1 = 10,
                    Y2 = 10 + h_interval *10,
                    StrokeThickness = 1
                };
                line.Stroke = new SolidColorBrush(Color.FromArgb(160, 255, 255, 255));  // It needs "using Windows.UI;"

                GridCanvas.Children.Add(line);
            }

            for (double r = h_start; r < h; r += h_interval)
            {
                Line line = new Line
                {
                    X1 = 10,
                    X2 = 10 + w_interval * 10,
                    Y1 = r,
                    Y2 = r,
                    StrokeThickness = 1
                };
                line.Stroke = new SolidColorBrush(Color.FromArgb(160, 255, 255, 255));

                GridCanvas.Children.Add(line);
            }
            GridCanvas.UpdateLayout();
        }

        private void GraphControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            cntHeight = (int)GraphControl.ActualHeight;
            cntWidth = (int)GraphControl.ActualWidth;
            InfoText.Text = "Height: " + cntHeight + " ,Width: " + cntWidth;
            
            gridInfo.h_start = 10;
            gridInfo.w_start = 10;
            gridInfo.h_interval = (cntHeight - 20) / 10;
            gridInfo.w_interval = (cntWidth - 20) / 10;
            GridCanvasProcess2(cntHeight, cntWidth);
            GridPointList();
        }

        public struct GridInfo
        {
            public int h_start;
            public int w_start;
            public int h_interval;
            public int w_interval;

            public GridInfo(int hStart, int wStart, int hInterval, int wInterval) => (h_start, w_start, h_interval, w_interval) = (hStart, wStart, hInterval, wInterval);

            public override string ToString() => $"({h_start}, {w_start}, {h_interval}, {w_interval})";
        }

        private void PointButton0_Click(object sender, RoutedEventArgs e)
        {
            if (nowPosition != 0)
            {
                PointButton0.Background = new SolidColorBrush(Color.FromArgb((byte)255, (byte)0, (byte)255, (byte)255));
                nowPosition = 0;
            }
            else
            {
                PointButton0.Background = new SolidColorBrush(Color.FromArgb((byte)255, (byte)255, (byte)0, (byte)0));
                nowPosition = -1;
            }
        }

        private void PointButton1_Click(object sender, RoutedEventArgs e)
        {
            if (nowPosition != 1)
            {
                PointButton1.Background = new SolidColorBrush(Color.FromArgb((byte)255, (byte)0, (byte)255, (byte)255));
                nowPosition = 1;
            } else
            {
                PointButton1.Background = new SolidColorBrush(Color.FromArgb((byte)255, (byte)255, (byte)0, (byte)0));
                nowPosition = -1;
            }
        }

        private void PointButton2_Click(object sender, RoutedEventArgs e)
        {
            if (nowPosition != 2)
            {
                PointButton2.Background = new SolidColorBrush(Color.FromArgb((byte)255, (byte)0, (byte)255, (byte)255));
                nowPosition = 2;
            }
            else
            {
                PointButton2.Background = new SolidColorBrush(Color.FromArgb((byte)255, (byte)255, (byte)0, (byte)0));
                nowPosition = -1;
            }
        }

        private void PointButton3_Click(object sender, RoutedEventArgs e)
        {
            if (nowPosition != 3)
            {
                PointButton3.Background = new SolidColorBrush(Color.FromArgb((byte)255, (byte)0, (byte)255, (byte)255));
                nowPosition = 3;
            }
            else
            {
                PointButton3.Background = new SolidColorBrush(Color.FromArgb((byte)255, (byte)255, (byte)0, (byte)0));
                nowPosition = -1;
            }
        }

        private void PointButton1_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            Debug.WriteLine("Key down info button:" + e.Key.ToString());
        }

        private void GraphControl_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            Debug.WriteLine("Key down info grid:" + e.Key.ToString() + ", " + e.Key);
            bool isModify = false;
            if (e.Key == Windows.System.VirtualKey.Up && nowPosition != -1) //Up
            {
                if (pntPosition[nowPosition, 1] != 0)
                {
                    pntPosition[nowPosition, 1]--;
                    isModify = true;
                }

            }
            else if (e.Key == Windows.System.VirtualKey.Down && nowPosition != -1)   //Down
            {
                if (pntPosition[nowPosition, 1] != 10)
                {
                    pntPosition[nowPosition, 1]++;
                    isModify = true;
                }

            }
            else if(e.Key == Windows.System.VirtualKey.Left && nowPosition != -1)   //Left
            {
                if (pntPosition[nowPosition, 0] != 0)
                {
                    pntPosition[nowPosition, 0]--;
                    isModify = true;
                }

            }
            else if (e.Key == Windows.System.VirtualKey.Right && nowPosition != -1)   //Right
            {
                if (pntPosition[nowPosition, 0] != 10)
                {
                    pntPosition[nowPosition, 0]++;
                    isModify = true;
                }
            }
            if(isModify)
            {
                point_4_Adjust(nowPosition, e.Key);
                GridCanvasProcess2(cntHeight, cntWidth);
                GridPointList();
                e.Handled = true;
            }
        }

        private void point_4_Adjust(int nowPos, VirtualKey key)
        {
            if(key == Windows.System.VirtualKey.Up)
            {
                for(int i = 3; i > nowPos; i--)
                {
                    if (pntPosition[i, 1] > pntPosition[nowPos, 1])
                    {
                        Debug.WriteLine("Up:" + i + " , " + nowPos + " : " + pntPosition[i, 1] + " , " + pntPosition[nowPos, 1]);
                        pntPosition[i, 1] = pntPosition[nowPos, 1];
                    }

                }
            }
            else if (key == Windows.System.VirtualKey.Down)
            {
                for (int i = 0; i < nowPos; i++)
                {
                    if (pntPosition[i, 1] < pntPosition[nowPos, 1])
                    {

                        pntPosition[i, 1] = pntPosition[nowPos, 1];
                    }
                }
            }
            else if (key == Windows.System.VirtualKey.Left)
            {
                for (int i = 0; i < nowPos; i++)
                {
                    if (pntPosition[i, 0] > pntPosition[nowPos, 0])
                    {
                        Debug.WriteLine("Left:" + i + " , " + nowPos + " : " + pntPosition[i, 1] + " , " + pntPosition[nowPos, 1]);
                        pntPosition[i, 0] = pntPosition[nowPos, 0];
                    }

                }
            }
            else if (key == Windows.System.VirtualKey.Right)
            {
                for (int i = 3; i > nowPos; i--)
                {
                    if (pntPosition[i, 0] < pntPosition[nowPos, 0])
                    {
                        Debug.WriteLine("Right:" + i + " , " + nowPos + " : " + pntPosition[i, 1] + " , " + pntPosition[nowPos, 1]);
                        pntPosition[i, 0] = pntPosition[nowPos, 0];
                    }
                }
            }
        }
    }
}
