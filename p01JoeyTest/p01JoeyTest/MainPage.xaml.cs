using p01JoeyTest.UControl.Practice.Page01;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

/*
 * Author: Joey
 * Reference 1: https://www.youtube.com/playlist?list=PLaoF-xhnnrRUNVx-JAfEy_kUrGGaKS7HL
 *   Study: 23
 *   
 * Reference 2: https://www.youtube.com/playlist?list=PLi2hbezQRVS0cPMeW3uDlUHnO_rPvJCV9
 *   Study: 38
 */
namespace p01JoeyTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string[] _functionInfo = { "Fuction1", "Function2", "Function3", "Page20Task", "MouseLine", "PolyLine01" };
        public MainPage()
        {
            this.InitializeComponent();
            foreach(string info in _functionInfo) 
                functionCbx.Items.Add(info);

            MyFrame.Navigate(typeof(Page01));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //btnSubmit.Content = functionCbx.SelectedItem.ToString();
            Debug.WriteLine("info =" + functionCbx.SelectedItem.ToString());
            if (functionCbx.SelectedItem.ToString() == "Function2")
                MyFrame.Navigate(typeof(Page02));
            else if (functionCbx.SelectedItem.ToString() == "Function3")
                MyFrame.Navigate(typeof(Page03));
            else if (functionCbx.SelectedItem.ToString() == "Page20Task")
                MyFrame.Navigate(typeof(Page20Task));
            else if (functionCbx.SelectedItem.ToString() == "MouseLine")
                MyFrame.Navigate(typeof(MouseLine));
            else if (functionCbx.SelectedItem.ToString() == "PolyLine01")
                MyFrame.Navigate(typeof(PolyLine01));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
            }
        }
    }
}
