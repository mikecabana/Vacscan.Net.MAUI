using System;
using Microsoft.Maui.Controls;
using ZXing.Net.Maui;

namespace Vacscan.Net.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            barcodeView.Options = new BarcodeReaderOptions
            {
                Formats = BarcodeFormats.OneDimensional,
                AutoRotate = true,
                Multiple = true,
                TryHarder = true,
            };
        }

        protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
        {
            foreach (var barcode in e.Results)
            {
                string message = $"Barcodes: {barcode.Format} -> {barcode.Value}";
                Message.Text = message;
                Console.WriteLine(message);
            }
        }

        void SwitchCameraButton_Clicked(object sender, EventArgs e)
        {
            barcodeView.CameraLocation = barcodeView.CameraLocation == CameraLocation.Rear ? CameraLocation.Front : CameraLocation.Rear;
        }

        void TorchButton_Clicked(object sender, EventArgs e)
        {
            barcodeView.IsTorchOn = !barcodeView.IsTorchOn;
        }
    }
}
