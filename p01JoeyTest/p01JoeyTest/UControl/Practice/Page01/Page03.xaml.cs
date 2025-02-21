using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace p01JoeyTest.UControl.Practice.Page01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page03 : Page
    {
        public Page03()
        {
            this.InitializeComponent();
        }

        private void P0001_Lambda_Click(object sender, RoutedEventArgs e)
        {
            var p1 = new P0001_MutablePoint(1, 2);
            var p2 = p1;
            p2.Y = 200;
            Debug.WriteLine($"{nameof(p1)} after {nameof(p2)} is modified:{p1}");
            Debug.WriteLine($"{nameof(p2)}: {p2}");

            P0001_MutateAndDisplay(p2);
            Debug.WriteLine($"{nameof(p2)} after passing to a method: {p2}");
        }

        private void P0001_MutateAndDisplay(P0001_MutablePoint p)
        {
            p.X = 100;
            Debug.WriteLine($"Point mutated in a method: {p}");
        }

        private struct P0001_MutablePoint
        {
            public int X;
            public int Y;

            public P0001_MutablePoint(int x, int y) => (X, Y) = (x, y);
            public override string ToString() => $"({X}, {Y})";
        }
    }
}
