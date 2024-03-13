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
 * Reference: https://www.youtube.com/watch?v=hkY3ek71Zxk&list=PLaoF-xhnnrRUNVx-JAfEy_kUrGGaKS7HL&index=102
 * Subject: Adaptive GridView
 * Note:
 *   1. Need to get Microsoft.Toolkit.Uwp.UI.Controls from NuGet
 */
namespace p01JoeyTest.UControl.Practice
{
    public sealed partial class Test05 : UserControl
    {
        public Test05()
        {
            this.InitializeComponent();
            List<MyImage> data = new List<MyImage>();
            data.Add(new MyImage()
            {
                ImageUrl = "ms-appx:///Assets/ic_game_epic.png"
            });
            data.Add(new MyImage()
            {
                ImageUrl = "ms-appx:///Assets/ic_game_gog.png"
            });
            data.Add(new MyImage()
            {
                ImageUrl = "ms-appx:///Assets/ic_game_xbox.png"
            });
            data.Add(new MyImage()
            {
                ImageUrl = "ms-appx:///Assets/ic_game_ubisoft.png"
            });

            myAdaptiveGridView.ItemsSource = data;
        }

        class MyImage
        {
            public string ImageUrl { get; set; }
        }
    }
}
