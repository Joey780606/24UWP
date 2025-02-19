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

using Windows.Gaming.Input;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Core;
using p01JoeyTest.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
/*
 * Fun 1: Gamepad
 *  Ref: https://learn.microsoft.com/en-us/windows/uwp/gaming/gamepad-and-vibration
 *  a. Loose:0, Tighten:1
 *  b. Thumbstick: Middle:0 or 1.5, Top:1, Bottom:-1
 *  c. 此例是取 Gamepad的Thumbstick, Trigger按鍵的按壓百分比,是參考上面連結的作法(官方也只支援定時讓開發者取值,大概是250ms可取一次)
 *  
 * Fun 2: 
 *  Ref: https://learn.microsoft.com/en-us/windows/communitytoolkit/controls/radialgauge
 *  a. 此例是欲繪出跟V2版有關的UI
 *  b. CommunityToolkit.Mvvm 的版本為 v8.4.0後, .NET版本要升為 v8.0 <LangVersion>8.0</LangVersion>
 */

namespace p01JoeyTest.UControl.Practice.Page01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page02 : Page
    {
        private Page02ViewModel viewModel;


        public Page02()
        {
            this.InitializeComponent();
            viewModel = new Page02ViewModel();
            Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.Loaded();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            viewModel.Unloaded();

        }

        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            viewModel.testChangeValue();
        }

        private void btnValue_Click(object sender, RoutedEventArgs e)
        {
            RadialGaugeControl.Value = 20.1;
        }

        private void CoreWindow_CharacterReceived(CoreWindow sender, CharacterReceivedEventArgs args)
        {
            uint keyCode = args.KeyCode;
            Debug.WriteLine("Input key:" +  keyCode);
        }
    }

}
