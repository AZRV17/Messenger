using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;

namespace Message
{
    public partial class MainWindow : Window
    {
        private List<string> _users = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text != "")
            {
                int port = 8080;
                _users.Add(UsernameTextBox.Text);
                AdminChat adminChat = new AdminChat(port, UsernameTextBox.Text);
                adminChat.Show();
            }
            else
            {
                MessageBox.Show("Введите имя пользователя");
            }
        }

        private void ConnectButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text != "")
            {
                _users.Add(UsernameTextBox.Text);
                if (IPTextBox.Text != "")
                {
                    try
                    {
                        IPAddress ip = IPAddress.Parse(IPTextBox.Text);
                        Chat clientChat = new Chat(UsernameTextBox.Text, ip);
                        clientChat.Show();
                    }
                    catch
                    {
                        MessageBox.Show("IP сервера указан неверно");
                    }
                }
                else
                {
                    MessageBox.Show("Введите IP сервера чтобы подключиться");
                }
            }
            else
            {
                MessageBox.Show("Ввелите имя пользователя");
            }
        }
    
    }
}
