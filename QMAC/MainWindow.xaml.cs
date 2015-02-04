using QMAC.Models;
using System;
using System.Reflection;
using System.Security;
using System.Windows;

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
    }
}
