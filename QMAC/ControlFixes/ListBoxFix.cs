using System.Windows;
using System.Windows.Controls;

namespace QMAC.ControlFixes
{
    public static class ListBoxFix
    {
        public static bool GetSelectedItemsBinding(ListBox element)
        {
            return (bool)element.GetValue(SelectedItemsBindingProperty);
        }

        public static void SetSelectedItemsBinding(ListBox element, bool value)
        {
            element.SetValue(SelectedItemsBindingProperty, value);
            if (value)
            {
                element.SelectionChanged += (sender, args) =>
                {
                    var x = element.SelectedItems;
                };
            }
        }

        public static readonly DependencyProperty SelectedItemsBindingProperty =
            DependencyProperty.RegisterAttached("SelectedItemsBinding",
            typeof(bool), typeof(ListBoxFix), new PropertyMetadata(false));
    }
}
