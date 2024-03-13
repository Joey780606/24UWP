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
 * Reference: https://www.youtube.com/watch?v=zuJZrLkKGUw&list=PLi2hbezQRVS0cPMeW3uDlUHnO_rPvJCV9&index=41
 * Subject: GridView
 */
namespace p01JoeyTest.UControl.Practice.Test_06
{
    public sealed partial class Test06 : UserControl
    {
        private List<ModelBooks> Books;
        public Test06()
        {
            this.InitializeComponent();

            Books = BookManager.GetBooks();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var book = (ModelBooks)e.ClickedItem;
            ResultTextBlock.Text = "You selected " + book.Title;
        }
    }
}
