using QMAC.Models;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using QMAC.ViewModel;

namespace QMAC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IPassword
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public SecureString Password
        {
            get
            {
                return passwordTextbox.SecurePassword;
            }
        }

        // Since ListBox does not support databinding for multiple items, we must manually 
        // update the property with the selected items
        private void schoolListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)DataContext;

            foreach (string item in e.AddedItems)
            {
                vm.selectedItems.Add(item);
            }

            foreach (string item in e.RemovedItems)
            {
                vm.selectedItems.Remove(item);
            }
        }

        private void passwordTextbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Cast the sender to a PasswordBox
            PasswordBox box = sender as PasswordBox;

            // Set this "EncryptedPassword" dependency property to the "SecurePassword" of the PasswordBox
            PasswordBoxAttachedProperty.SetEncryptedPassword(box, box.SecurePassword);
        }
    }
}
