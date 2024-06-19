using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Radios;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
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
    public sealed partial class Page01 : Page
    {
        public Page01()
        {
            this.InitializeComponent();
        }

        private async void BluetoothOn_Click(object sender, RoutedEventArgs e)
        {
            var result = await Radio.RequestAccessAsync();
            if (result == RadioAccessStatus.Allowed)
            {
                var bluetooth = (await Radio.GetRadiosAsync()).FirstOrDefault(radio => radio.Kind == RadioKind.Bluetooth);
                if (bluetooth != null && bluetooth.State != RadioState.On)
                    await bluetooth.SetStateAsync(RadioState.On);
            }
        }

        private async void BluetoothOff_Click(object sender, RoutedEventArgs e)
        {
            var result = await Radio.RequestAccessAsync();
            if (result == RadioAccessStatus.Allowed)
            {
                var bluetooth = (await Radio.GetRadiosAsync()).FirstOrDefault(radio => radio.Kind == RadioKind.Bluetooth);
                if (bluetooth != null && bluetooth.State != RadioState.Off)
                    await bluetooth.SetStateAsync(RadioState.Off);
            }
        }

        /// <summary>
        /// Test download program. Ref: https://stackoverflow.com/questions/45484802/download-pdf-and-word-file-in-uwp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DownloadFile_Click(object sender, RoutedEventArgs e)
        {
            Uri source = new Uri(@"http://192.168.0.12:8080/share.cgi?ssid=2bd05be97b6a4e87ab2f7b7bf6b55574");
            StorageFile destinationFile = await KnownFolders.PicturesLibrary.CreateFileAsync("version.txt", CreationCollisionOption.GenerateUniqueName);
            BackgroundDownloader downloader = new BackgroundDownloader();
            DownloadOperation download = downloader.CreateDownload(source, destinationFile);
            await download.StartAsync();
            Debug.WriteLine("Download success" + ApplicationData.Current.LocalFolder.Path);
            //存到系統的Pictures目錄裡
            //結果失敗,有存下來,但變成圖片型式

        }
    }
}
