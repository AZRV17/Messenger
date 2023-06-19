using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Message
{
    public partial class Chat : Window
    {
        private Socket _server;
        private string _userName;
        
        public Chat(string name, IPAddress ipAddress)
        {
            InitializeComponent();

            _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _server.ConnectAsync(ipAddress, 8080);
            _userName = name;
            byte[] usernameBytes = Encoding.UTF8.GetBytes("##&^! " + _userName);
            _server.SendAsync(new ArraySegment<byte>(usernameBytes), SocketFlags.None);
            ReceiveMessage();
        }
        
        private async Task ReceiveMessage()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await _server.ReceiveAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                
                if (message.StartsWith("##&^! "))
                {
                    string name = message.Substring(5);
                    
                    if (UsersListBox.Items.Count != 0)
                    {
                        foreach (var item in UsersListBox.Items)
                        {
                            if (name != item.ToString())
                            {
                                UsersListBox.Items.Add(name);
                                UsersListBox.Items.Refresh();
                            }
                        }
                    }
                    else
                    {
                        UsersListBox.Items.Add(name);
                        UsersListBox.Items.Refresh();
                    }
                }
                else
                {
                    MessagesListBox.Items.Add($"{DateTime.Now} | {message}");
                }
            }
        }

        void Chat_Closing(object sender, CancelEventArgs e)
        {
            DisconnectAsync().Wait();
        }
        
        private async Task SendMessage(string message)
        {
            if (message == $"{_userName}: /disconnect")
            {
                DisconnectAsync().Wait();
                this.Close();
            }
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await _server.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
            ReceiveMessage();
        }

        public async Task DisconnectAsync()
        {
            SendMessage($"/disconnect {_userName}");
            _server.Shutdown(SocketShutdown.Both);
            _server.Disconnect(false);
        }
        
        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            SendMessage($"{_userName}: {MessageTextBox.Text}");
            MessageTextBox.Clear();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            DisconnectAsync().Wait();
            this.Close();
        }
    }
}