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
 * Reference: https://www.youtube.com/watch?v=cGfNMDWYlUs&list=PLaoF-xhnnrRUNVx-JAfEy_kUrGGaKS7HL&index=1
 * Important:
 *   1.Controls/FlipViewIndicator.cs 是 ListBox的 control 程式,重要.
 */
namespace p01JoeyTest.UControl.Practice
{
    public class MyItem
    {
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
    }

    public sealed partial class Test02 : UserControl
    {
        List<MyItem> listImages = new List<MyItem>();

        public Test02()
        {
            this.InitializeComponent();
            InitImage();
            flipView.ItemsSource = listImages;
        }

        /*
        public override void OnNavigatedTo(NavigationEventArgs e)   //好像只有 Page有
        {
            base.OnNavigatedTo(e);
            InitImage();
            flipView.ItemsSource = listImages;
        }
        */
        private void InitImage()
        {
            listImages.Add(new MyItem() { ImageName = "Epic", ImagePath = "ms-appx:///Assets/ic_game_epic.png" });
            listImages.Add(new MyItem() { ImageName = "Gog", ImagePath = "ms-appx:///Assets/ic_game_gog.png" });
            listImages.Add(new MyItem() { ImageName = "MS", ImagePath = "ms-appx:///Assets/ic_game_ms_store.png" });
            listImages.Add(new MyItem() { ImageName = "Ubisoft", ImagePath = "ms-appx:///Assets/ic_game_ubisoft.png" });
            listImages.Add(new MyItem() { ImageName = "xBox", ImagePath = "ms-appx:///Assets/ic_game_xbox.png" });
        }
    }
}
