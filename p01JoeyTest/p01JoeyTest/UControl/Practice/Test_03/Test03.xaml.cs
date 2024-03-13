using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
 * Reference: Office WPF sample (https://github.com/microsoft/WPF-Samples/tree/main)
 *   WPF-Samples/Styles & Templates/IntroToStylingAndTemplating
 * Subject: ListBox
 */
namespace p01JoeyTest.UControl.Practice.Test_03
{

    public sealed partial class Test03 : UserControl
    {
        ObservableCollection<Chapters> NewsList = new ObservableCollection<Chapters>(); //這個不懂
        Random random = new Random();
        static long totalBytes;
        static long currentBytes;
        static long peakBytes;

        public Test03()
        {
            this.InitializeComponent();

            LoadNews(250);
            this.DataContext = NewsList;    //寫這樣的原因不知是否是畫面的變化,是由 NewsList 來決定的???
            //CheckMemory();
        }

        static DispatcherTimer dispatcherTimer;
        private void CheckMemory()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += Dispatcher_Tick;
        }

        private void Dispatcher_Tick(object sender, object e)
        {
            //totalBytes =
        }

        void LoadNews(int Length)
        {
            for(int i = 0; i < Length; i++)
            {
                //NewsList.Add(new Chapters { Name = "eddon 71 win 10 universal apps" + random.Next(1, 22), Photo = "Assets/" + random.Next(0, 2) };
                NewsList.Add(new Chapters { Name = "eddon 71 win 10 universal apps" + random.Next(1, 22), Photo = "../../../Assets/ic_game_epic.png" });
            }
        }
    }
}
