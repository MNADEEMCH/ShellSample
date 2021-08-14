using ShellStylesSample.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellStylesSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void AppShell_Navigating(object sender, ShellNavigatingEventArgs e)
        {
            if (e.Target.Location.OriginalString.Contains("addnew"))
            {
                e.Cancel();

                if (!Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Any())
                {
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new NewPopupPage(), true);
                }
            }
            else
            {
                if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Any())
                {
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
                }
            }
        }
    }
}