using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Radios;

namespace p01JoeyTest.ViewModel
{
    public partial class Page01ViewModel : ObservableObject
    {
        
        [ObservableProperty]
        private string _btTest = "Unknown";

        public Page01ViewModel()
        {
            setBluetooth();
        }

        private async void setBluetooth()
        {
            var radios = await Radio.GetRadiosAsync();
            var bluetoothRadio = radios.FirstOrDefault(radio => radio.Kind == RadioKind.Bluetooth);
            bluetoothRadio.StateChanged += BluetoothRadio_StateChanged;
            //return bluetoothRadio != null && bluetoothRadio.State == RadioState.On;
        }

        private static void BluetoothRadio_StateChanged(Radio sender, object args)
        {
            Debug.WriteLine("Bluetooth status:{0}", sender.State);
        }

    }
}
