using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
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
        //enum p32, 重要,enum須要放在最前面
        enum enumSeason
        {   //Sample 1
            Spring,
            Summer,
            Autumn,
            Winter
        }

        enum enumErrorCode : ushort
        {
            None = 0,
            Unknown = 1,
            ConnectionLost = 100,
            OutlierReading = 200
        }

        public enum enumDays
        {
            None = 0b_0000_0000,    // 0
            Monday = 0b_0000_0001,  // 1
            Tuesday = 0b_0000_0010, // 2
            Wednesday = 0b_0000_0100,    // 4
            Thursday = 0b_0000_1000,  // 8
            Friday = 0b_0001_0000, // 16
            Saturday = 0b_0010_0000,    // 32
            Sunday = 0b_0100_0000,  // 64
            Weekend = Saturday | Sunday
        }

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

            //浮點數
            Debug.WriteLine("Float point area");
            double doubleA = 12.3;
            System.Double doubleB = 12.3;

            //數值尾數(suffix)為d,D是 double 型態
            //數值尾數(suffix)為f,F是 float 型態
            //數值尾數(suffix)為m,M是 decimal 型態
            double doubleC = 1.0;
            decimal doubleD = 2.1m;
            Debug.WriteLine("Float Test 1:" + (doubleC + (double)doubleD)); //結果是3.3
            Debug.WriteLine("Float Test 2:" + (decimal)(doubleC + (double)doubleD));    //結果是3.3

            double doubleE = 3D;
            doubleE = 4d;
            doubleE = 3.934_001;
            doubleE = 0.43e2;   //output 42

            float doubleF = 3_000.5F;
            doubleF = 5.4f;
            doubleF = 134.45E-2f;   //output 1.3445

            decimal myMoney = 3_000.5m;
            myMoney = 400.75M;
            myMoney = 1.5E6m;   //output 1500000

            //bool
            bool check = true;
            Debug.WriteLine(check ? "Checked" : "Not checked"); //重要

            //char p29
            var chars = new[] { 'j', '\u006A', '\x006A', (char)106, };
            Debug.WriteLine(string.Join(" ", chars));   //重要


        }

        private void P0003_Enum_Click(object sender, RoutedEventArgs e) //P33
        {
            enumDays meetingDays = enumDays.Monday | enumDays.Wednesday | enumDays.Friday;
            Debug.WriteLine($"meeting is: {meetingDays}");   //重要,官網文件寫會出現 Monday, Wednesday, Friday, 但實測只有出現數字值21

            enumDays workingFromHomeDays = enumDays.Thursday | enumDays.Friday;
            Debug.WriteLine($"Join a meeting by phone on {meetingDays & workingFromHomeDays}");

            bool isMeetingOnTuesday = (meetingDays & enumDays.Tuesday) == enumDays.Tuesday;
            Debug.WriteLine($"Is there a meeting on Tuesday: {isMeetingOnTuesday}");

            var a = (enumDays)37;
            Debug.WriteLine($"37 is: {a}");

            Debug.WriteLine("= = = Separator = = =");

            enumSeason season1 = enumSeason.Autumn;
            Debug.WriteLine($"Integral value of {a} is {(int)season1}");

            var season2 = (enumSeason)1;
            Debug.WriteLine($"Season2 is: {season2}");

            season2 = (enumSeason)4;
            Debug.WriteLine($"Season2-2 is: {season2}");

            season2 = (enumSeason)2;
            Debug.WriteLine($"Season2 is: {season2}");
        }

        private void P1001_Nullable_Click(object sender, RoutedEventArgs e)
        {
                //p105 重要,裡面的說明要找時間看
                string notNull = "Hello";
                string? nullable = default;
                notNull = nullable!;

                //p106
                //var nullEmpty = System.String?.Empty; //Not allowed
                //var maybeObject = new Object?();  //Not allowed, Object是不能被指為 null 的            
                //try   //Not allowed,但不知為什麼
                //{
                //    if (notNull is string ? nullableString)
                //        Debug.WriteLine(nullableString);
                //} catch (Exception? ex) {
                //    Debug.WriteLine(ex.ToString());
                //}
        }
    }
}
