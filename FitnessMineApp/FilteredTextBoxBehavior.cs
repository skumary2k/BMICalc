//This code can be found here:http://marcominerva.wordpress.com/2014/01/24/filteredtextboxbehavior-for-windows-8-1-store-apps/

using Microsoft.Xaml.Interactivity;
using System;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FitnessMineApp
{
    public class FilteredTextBoxBehavior : DependencyObject, IBehavior
    {
        private string lastValidText;

        public DependencyObject AssociatedObject { get; private set; }

        public static readonly DependencyProperty ExpressionProperty =
            DependencyProperty.Register("Expression",
            typeof(string),
            typeof(FilteredTextBoxBehavior),
            new PropertyMetadata(null));

        public string Expression
        {
            get
            {
                return (string)base.GetValue(ExpressionProperty);
            }
            set
            {
                base.SetValue(ExpressionProperty, value);
            }
        }

        public void Attach(DependencyObject associatedObject)
        {
            var txt = associatedObject as TextBox;
            if (txt == null)
                throw new ArgumentException(
                    "FilteredTextBoxBehavior can be attached only to TextBox");

            AssociatedObject = associatedObject;

            lastValidText = txt.Text;
            txt.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var txt = AssociatedObject as TextBox;
            if (txt != null && !string.IsNullOrWhiteSpace(Expression))
            {
                if (Regex.IsMatch(txt.Text, Expression))
                {
                    // The text matches the regular expression.
                    lastValidText = txt.Text;
                }
                else
                {
                    // The text doesn't match the regular expression.
                    // Restore the last valid value.
                    var caretPosition = txt.SelectionStart;
                    txt.Text = lastValidText;
                    if (caretPosition > 0)
                        txt.SelectionStart = caretPosition - 1;
                }
            }
        }

        public void Detach()
        {
            var txt = AssociatedObject as TextBox;
            if (txt != null)
                txt.TextChanged -= this.OnTextChanged;
        }
    }
}
