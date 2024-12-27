using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

/*
 * Author: Joey
 * Function: Just testing
 */
namespace p01JoeyTest.UControl.Practice
{
    public sealed partial class Test01 : UserControl
    {
        public Test01()
        {
            this.InitializeComponent();
            funTest1();
        }

        private void funTest1()
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)   //記得要在這裡才能量測實際尺寸大小1
        {
            int cntHeight = (int)GridContent.ActualHeight;
            int cntWidth = (int)GridContent.ActualWidth;
            InfoText.Text = cntHeight + " , " + cntWidth;
        }
    }
}
