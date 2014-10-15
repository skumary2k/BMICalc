using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace FitnessMineApp
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbWeight.Text))
                return;
            if (string.IsNullOrEmpty(tbHeightFeet.Text) && string.IsNullOrEmpty(tbHeightInch.Text))
                return;

            int ft = Convert.ToInt32(tbHeightFeet.Text);
            int inc = Convert.ToInt32(tbHeightInch.Text);
            int we = Convert.ToInt32(tbWeight.Text);
            WeightType wt = cbWeightType.SelectedIndex == 0 ? WeightType.Pounds : WeightType.Kilograms;

            var result = Helper.CalculateBMI(ft, inc, we, wt);

            greetingOutput.Text = "You have a BMI of " +  result;
        }

        private void TextBox_KeyDown_Number(object sender, KeyRoutedEventArgs e)
        {
            if ((uint)e.Key >= (uint)Windows.System.VirtualKey.Number0
                && (uint)e.Key <= (uint)Windows.System.VirtualKey.Number9)
            {
                e.Handled = false;
            }
            else e.Handled = true;
        }
    }
}
