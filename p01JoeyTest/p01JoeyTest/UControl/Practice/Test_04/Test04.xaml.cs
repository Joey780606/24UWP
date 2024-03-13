using p01JoeyTest.UControl.Practice.Test_04;
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
 *  Author: Joey
 *  Reference: https://www.youtube.com/watch?v=Sk6oz0yxO94&list=PLz5rnvLVJX5U3zCsm9qFVXW5JRGuwALhr
 *  Subject: Data binding
 */
namespace p01JoeyTest.UControl.Practice
{
    public sealed partial class Test04 : UserControl
    {
        Student student = new Student();
        public Test04()
        {
            this.InitializeComponent();
            createStudent();
            this.DataContext = student; //影片21:22,實驗過,不加不行,好像是設定資料的變動來源
        }

        public void createStudent()
        {
            student.Name = "Umair";
            student.Rollno = "1234";
            student.Phone = "35234";
        }
    }
}
