using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _ = LaunchProcess();
        }

        private async Task SetText(string text)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                LblCountdown.Text = text;
            });
        }

        private async Task LaunchProcess()
        {
            const int delay = 500;
            for (uint i = 3; i > 0; --i)
            {
                await SetText(String.Format("In {0} seconds...", i));
                await Task.Delay(delay);
            }

            await SetText("Now!");
            await Task.Delay(delay);

            try
            {
                if (Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
                {

                    Windows.Foundation.IAsyncAction action = Windows.ApplicationModel.FullTrustProcessLauncher.LaunchFullTrustProcessForAppAsync("UwpGame", "UwpGame");
                    while (action.Status == Windows.Foundation.AsyncStatus.Started)
                    {
                        await Task.Delay(delay);
                    }
                    await SetText(string.Format("UWP Game Status: {0}", action.Status));
                    await Task.Delay(2000);

                    action = Windows.ApplicationModel.FullTrustProcessLauncher.LaunchFullTrustProcessForAppAsync("CppGame", "CppGame");
                    while (action.Status == Windows.Foundation.AsyncStatus.Started)
                    {
                        await Task.Delay(delay);
                    }
                    await SetText(string.Format("C++ Game Status: {0}", action.Status));
                    await Task.Delay(2000);

                    await SetText("Launch Complete!");
                    await Task.Delay(2000);
                    Application.Current.Exit();
                }
                else
                {
                    await SetText("Launch Failed! FullTrustAppContract");
                }
            }
            catch (Exception ex)
            {
                await SetText(String.Format("Launch Failed! Exception: {0}", ex));
            }
        }
    }
}
