using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellStylesSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFundsPage : ContentPage
    {
        public MyFundsPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }

        private void Button_Clicked2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }
    }
}