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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
/*
 * Fun 1: Gamepad
 *  Ref: https://learn.microsoft.com/en-us/windows/uwp/gaming/gamepad-and-vibration
 *  a. Loose:0, Tighten:1
 *  b. Thumbstick: Middle:0 or 1.5, Top:1, Bottom:-1
 *  
 * Fun 2: 
 */

namespace p01JoeyTest.UControl.Practice.Page01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page02 : Page
    {
        Gamepad f1Gamepad;
        DispatcherTimer f1DispatcherTimer;

        public Page02()
        {
            this.InitializeComponent();


        }

        void f1Initial()
        {   
            f1DispatcherTimer = new DispatcherTimer();
            f1DispatcherTimer.Interval = TimeSpan.FromMilliseconds(250);
            f1DispatcherTimer.Tick += f1dispatcherTimer_Tick;
            f1DispatcherTimer.Start();

            //public static event EventHandler<Gamepad> GamepadAdded
            Gamepad.GamepadAdded += f1Gamepad_GamepadAdded;
            //public static event EventHandler<Gamepad> GamepadRemoved
            Gamepad.GamepadRemoved += f1Gamepad_GamepadRemoved;
        }

        void f1Finish()
        {
            f1DispatcherTimer.Stop();
            Gamepad.GamepadAdded -= f1Gamepad_GamepadAdded;
            Gamepad.GamepadRemoved -= f1Gamepad_GamepadRemoved;
        }


        #region EventHandlers

        private async void f1Gamepad_GamepadAdded(object sender, Gamepad e)
        {
            //e.HeadsetConnected += f1E_HeadsetConnected;
            //e.HeadsetDisconnected += f1E_HeadsetDisconnected;
            //e.UserChanged += f1E_UserChanged;
            await f1Log("Gamepad Added");
        }

        private async void f1Gamepad_GamepadRemoved(object sender, Gamepad e)
        {
            await f1Log("Gamepad Removed");
        }
        private async void f1E_UserChanged(IGameController sender, Windows.System.UserChangedEventArgs args)
        {
            await f1Log("User changed");
        }

        private async void f1E_HeadsetDisconnected(IGameController sender, Headset args)
        {
            await f1Log("HeadsetDisconnected");
        }

        private async void f1E_HeadsetConnected(IGameController sender, Headset args)
        {
            await f1Log("HeadsetConnected");
        }

        #endregion

        private void f1dispatcherTimer_Tick(object sender, object e)
        {
            if (Gamepad.Gamepads.Count > 0)
            {
                f1Gamepad = Gamepad.Gamepads.First();
                var reading = f1Gamepad.GetCurrentReading();

                pbLeftThumbstickX.Value = reading.LeftThumbstickX;
                pbLeftThumbstickY.Value = reading.LeftThumbstickY;

                pbRightThumbstickX.Value = reading.RightThumbstickX;
                pbRightThumbstickY.Value = reading.RightThumbstickY;

                pbRightThumbstickY.Value = reading.RightThumbstickY;

                pbLeftTrigger.Value = reading.LeftTrigger;
                pbRightTrigger.Value = reading.RightTrigger;

                //https://msdn.microsoft.com/en-us/library/windows/apps/windows.gaming.input.gamepadbuttons.aspx
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.A), lblA);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.B), lblB);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.X), lblX);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.Y), lblY);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.Menu), lblMenu);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.DPadLeft), lblDPadLeft);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.DPadRight), lblDPadRight);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.DPadUp), lblDPadUp);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.DPadDown), lblDPadDown);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.View), lblView);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.RightThumbstick), ellRightThumbstick);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.LeftThumbstick), ellLeftThumbstick);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.LeftShoulder), rectLeftShoulder);
                f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.RightShoulder), recRightShoulder);

                Debug.WriteLine("L thumbstickX, Y:" + pbLeftThumbstickX.Value + " , " + pbLeftThumbstickY.Value);
                Debug.WriteLine("R thumbstickX, Y:" + pbRightThumbstickX.Value + " , " + pbRightThumbstickY.Value);
                Debug.WriteLine("L,R trigger:" + pbLeftTrigger.Value + " , " + pbRightTrigger.Value);
            }

        }

        #region Helper methods
        private void f1ChangeVisibility(bool flag, UIElement elem)
        {
            //elem.Visibility = Visibility.Visible;
            if (flag)
            { elem.Visibility = Visibility.Visible; }
            else
            { elem.Visibility = Visibility.Collapsed; }
        }

        private async Task f1Log(String txt)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                txtEvents.Text = DateTime.Now.ToString("hh:mm:ss.fff ") + txt + "\n" + txtEvents.Text;
            }
            );

        }
        #endregion

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            f1Initial();
            Debug.WriteLine("Joey page loaded");
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            f1Finish();
            Debug.WriteLine("Joey page unloaded");
        }
    }

}
