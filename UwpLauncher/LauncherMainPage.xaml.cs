using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace UwpLauncher
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for (uint i = 3; i > 0; --i)
            {
                LblCountdown.Text = String.Format("In {0} seconds...", i);
                await Task.Delay(1000);
            }

            LblCountdown.Text = "Now!";
            await Task.Delay(1000);

            try
            {
                if (Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
                {
                    await Windows.ApplicationModel.FullTrustProcessLauncher.LaunchFullTrustProcessForAppAsync("Game", "Background");
                    LblCountdown.Text = "Launch Success!";
                    await Task.Delay(2000);
                    //Application.Current.Exit();
                }
                else
                {
                    LblCountdown.Text = "Launch Failed! FullTrustAppContract";
                }
            }
            catch (Exception ex)
            {
                LblCountdown.Text = String.Format("Launch Failed! Exception: {0}", ex);
            }            
        }        
    }
}
