using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Essentials;

namespace mobile_App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class MainPage : ContentPage
    {
        string translatedNumber;
        public MainPage()
        {
            InitializeComponent();

            void OnTranslate(object sender, EventArgs e)
            {
                string enteredNumber = phoneNumberText.Text;
                translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);

                if (!string.IsNullOrEmpty(translatedNumber))
                {
                    callButton.IsEnabled = true;
                    callButton.Text = "Call " + translatedNumber;
                }
                else
                {
                    callButton.IsEnabled = false;
                    callButton.Text = "Call";
                }
            }
            async void OnCall(object sender, System.EventArgs e)
            {
                if (await this.DisplayAlert(
                        "Dial a Number",
                        "Would you like to call " + translatedNumber + "?",
                        "Yes",
                        "No"))
                {
                    // TODO: dial the phone
                }
            }
        }
    }
}