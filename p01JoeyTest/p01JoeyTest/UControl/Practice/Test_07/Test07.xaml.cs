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
 * Reference: https://www.youtube.com/watch?v=K1jSZZM75aQ&list=PLaoF-xhnnrRUNVx-JAfEy_kUrGGaKS7HL&index=24
 * Subject: Slider
 * 還要做的: 起終點圖可否自訂?
 */
namespace p01JoeyTest.UControl.Practice.Test_07
{
    public sealed partial class Test07 : UserControl
    {
        public Test07()
        {
            this.InitializeComponent();
        }

        private void slider2_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            string msg = String.Format("Current value: {0}", e.NewValue);
            this.txtResult.Text = msg;
        }
    }
}
