using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Gaming.Input;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace p01JoeyTest.ViewModel
{
    public partial class Page02ViewModel : ObservableObject
    {
        Gamepad f1Gamepad;
        DispatcherTimer f1DispatcherTimer;

        [ObservableProperty]
        //private int leftTriggerValue = 0;
        private double _leftTriggerValue=0;

        [ObservableProperty]
        private double rightTriggerValue;

        //= = =
        [ObservableProperty]
        private double pbLeftThumbstickX;

        [ObservableProperty]
        private double pbLeftThumbstickY;

        [ObservableProperty]
        private double pbRightThumbstickX;

        [ObservableProperty]
        private double pbRightThumbstickY;

        [ObservableProperty]
        private double pbLeftTrigger;

        [ObservableProperty]
        private double pbRightTrigger;

        [ObservableProperty]
        private double _mySelfUpdate;

        [ObservableProperty]
        private string _eventInfo;

        partial void OnMySelfUpdateChanged(double oldValue, double newValue)
        {
            Debug.WriteLine($"MySelfUpdate is about to {newValue}");
            Debug.WriteLine($"MySelfUpdate2 is about to {_mySelfUpdate} {MySelfUpdate}");
            //testChangeValue();
            //tempMySelf = MySelfUpdate;
            //LeftTriggerValue = MySelfUpdate;  //有用
           // LeftTriggerValue = 123;
        }

        //partial void OnLeftTriggerValueChanged(double oldValue, double newValue)
        //{
        //    Debug.WriteLine($"LeftTrigger is about to {newValue}");
        //    //LeftTriggerValue = newValue;
        //    //MySelfUpdate = 22;
        //}

        public Page02ViewModel()
        {
        }

        public void Loaded()
        {
            f1Initial();
            Debug.WriteLine("Joey page loaded");
        }

        public void Unloaded()
        {
            f1Finish();
            Debug.WriteLine("Joey page unloaded");
        }

        public void testChangeValue()
        {
            Debug.WriteLine("Joey testChangeValue1:" + MySelfUpdate + " , " + LeftTriggerValue);
            //LeftTriggerValue = MySelfUpdate;
            //LeftTriggerValue = tempMySelf;
            //LeftTriggerValue = MySelfUpdate;
            //LeftTriggerValue = 30;
            Debug.WriteLine("Joey testChangeValue2:" + MySelfUpdate + " , " + LeftTriggerValue);
        }

        void f1Initial()
        {
            f1DispatcherTimer = new DispatcherTimer();
            f1DispatcherTimer.Interval = TimeSpan.FromMilliseconds(250);
            //f1DispatcherTimer.Interval = TimeSpan.FromMilliseconds(2000);
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

        private async void f1dispatcherTimer_Tick(object sender, object e)
        {
            Debug.WriteLine("timer testing:" + MySelfUpdate + " , " + LeftTriggerValue);
            //MySelfUpdate = 20;
            if (Gamepad.Gamepads.Count > 0)
            {
                f1Gamepad = Gamepad.Gamepads.First();
                var reading = f1Gamepad.GetCurrentReading();

                PbLeftThumbstickX = reading.LeftThumbstickX;
                PbLeftThumbstickY = reading.LeftThumbstickY;

                PbRightThumbstickX = reading.RightThumbstickX;
                PbRightThumbstickY = reading.RightThumbstickY;

                PbLeftTrigger = reading.LeftTrigger;
                PbRightTrigger = reading.RightTrigger;

                //https://msdn.microsoft.com/en-us/library/windows/apps/windows.gaming.input.gamepadbuttons.aspx
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.A), lblA);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.B), lblB);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.X), lblX);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.Y), lblY);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.Menu), lblMenu);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.DPadLeft), lblDPadLeft);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.DPadRight), lblDPadRight);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.DPadUp), lblDPadUp);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.DPadDown), lblDPadDown);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.View), lblView);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.RightThumbstick), ellRightThumbstick);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.LeftThumbstick), ellLeftThumbstick);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.LeftShoulder), rectLeftShoulder);
                //f1ChangeVisibility(reading.Buttons.HasFlag(GamepadButtons.RightShoulder), recRightShoulder);

                //    Debug.WriteLine("L thumbstickX, Y:" + PbLeftThumbstickX + " , " + PbLeftThumbstickY);
                //    Debug.WriteLine("R thumbstickX, Y:" + PbRightThumbstickX + " , " + PbRightThumbstickY);

                await UIChange();

                Debug.WriteLine("L,R trigger:" + PbLeftTrigger + " , " + PbRightTrigger + " , " + LeftTriggerValue);
            }
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
                //txtEvents.Text = DateTime.Now.ToString("hh:mm:ss.fff ") + txt + "\n" + txtEvents.Text;
                EventInfo = DateTime.Now.ToString("hh:mm:ss.fff ") + txt + "\n" + EventInfo;
            }
            );

        }

        private async Task UIChange()
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                LeftTriggerValue = PbLeftTrigger * 100;
                //LeftTriggerValue += 10;
                //MySelfUpdate = 20;
                //LeftTriggerValue = 50;
                Debug.WriteLine("L,R trigger2:" + PbLeftTrigger + " , " + PbRightTrigger + " , " + LeftTriggerValue);
            }
            );

        }
        #endregion
    }
}
