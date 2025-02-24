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

        private void P0002_Lambda_Click(object sender, RoutedEventArgs e) //p10
        {
            var n1 = new P0002_TaggedInteger(0);
            n1.AddTag("A");
            Debug.WriteLine(n1);

            var n2 = n1;
            n2.Number = 7;
            n2.AddTag("B");  //重要,List 是 reference

            Debug.WriteLine(n1);
            Debug.WriteLine(n2);
        }

        private struct P0001_MutablePoint
        {
            public int X;
            public int Y;

            public P0001_MutablePoint(int x, int y) => (X, Y) = (x, y);
            public override string ToString() => $"({X}, {Y})";
        }

        public struct P0002_TaggedInteger
        {
            public int Number;
            private List<string> tags;

            public P0002_TaggedInteger(int n)
            {
                Number = n;
                tags = new List<string>();
            }

            public void AddTag(string tag) => tags.Add(tag);
            public override string ToString() => $"{Number} [{string.Join(", ", tags)}]";
        }

        private void P0003_Variable_Click(object sender, RoutedEventArgs e) //p14
        {
            //下面二個相同
            int a = 123;
            System.Int32 b = 123;
            var decimalLiteral = 42;    //不用前綴 prefix
            var hexLiteral = 0x2A;  //16進位
            var binaryLiteral = 0b_0010_1010; //1.2進制

            int testValue = unchecked((int)0xFF_FF_FF_FF);

            byte byteA = 17;
            //byte byteB = 300;  //重要,會有錯,因為只有到0~255

            //型態強制轉換
            var signedByte = (sbyte)42;
            var longVariable = (long)42;

            //以下似乎要 C# 9.0才能使用
            //unsafe
            //{
            //    Debug.WriteLine($"size of nint = {sizeof(nint)}");
            //}

            //Debug.WriteLine($"size of nint = {sizeof(nuint)}");

            //Debug.WriteLine($"nint.MinValue = {nint.MinValue}");
            //Debug.WriteLine($"nint.MinValue = {nint.MaxValue}");
            //Debug.WriteLine($"nint.MinValue = {nuint.MinValue}");
            //Debug.WriteLine($"nint.MinValue = {nuint.MaxValue}");
        }
    }
}
