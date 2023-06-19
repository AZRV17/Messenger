using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Message
{
    public partial class AdminChat : Window
    {
        private List<Socket> _clients = new List<Socket>();
        private int _port;
        private Socket _socket;
        private Socket _server;
        private List<string> _users = new List<string>();
        private List<string> _users2 = new List<string>();
        private TcpClient tcpClient = new TcpClient();
        private string _userName;

        public AdminChat(int port, string adminName)
        {
            InitializeComponent();

            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            _userName = adminName;

            _port = port;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(ipEndPoint);
            _socket.Listen(1000);

            _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _server.ConnectAsync("127.0.0.1", 8888);

            UsersListBox.Items.Add(adminName);
            UsersListBox.Items.Refresh();
            _users.Add(adminName);

            Title = $"Chat Port: {_port}";

            ListenToClients();
        }

        private async Task ListenToClients()
        {
            while (true)
            {
                var client = await _socket.AcceptAsync();
                _clients.Add(client);
                ReceiveMessage(client);
            }
        }

        private async Task ReceiveMessage(Socket client)
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);

                if (message.StartsWith("##&^! "))
                {
                    string name = message.Substring(6);
                    UsersListBox.Items.Add(name);
                    UsersListBox.Items.Refresh();
                    _users.Add(name);
                    LogListBox.Items.Add($"{DateTime.Now}: {name} has been connected to chat.");

                    foreach (var item in _clients)
                    {
                        foreach (var user in _users)
                        {
                            string nameToSend = "##&^! " + user;
                            SendUser(item, nameToSend);
                        }
                    }
                }
                else if (message.StartsWith("/disconnect"))
                {
                    string name = message.Substring(12).Trim();

                    message = $"{name} disconnetcted!";
                    MessagesListBox.Items.Add($"{message}");

                    name = name.Replace("\0", "");

                    foreach (var user in _users)
                    {
                        user.Replace("\0", "");
                        if (user.Replace("\0", "") == name)
                        {
                            _users.Remove(user);

                            LogListBox.Items.Add($"{DateTime.Now}: {name} has been disconnected");

                            UsersListBox.Items.Remove(user);
                            UsersListBox.Items.Refresh();
                        }
                    }

                    

                    if (_clients.Contains(client))
                    {
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                        _clients.Remove(client);
                    }

                    foreach (var item in _clients)
                    {
                        foreach (var user in _users)
                        {
                            string nameToSend = "##&^! " + user;
                            SendUser(item, nameToSend);
                        }
                    }



                    foreach (var item in _clients)
                    {
                        SendMessage(item, message);
                    }
                }
                else
                {
                    MessagesListBox.Items.Add($"{DateTime.Now} | {message}");

                    foreach (var item in _clients)
                    {
                        SendMessage(item, message);
                    }
                }
            }
        }

        private async Task SendMessage(Socket client, string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
        }

        private async Task SendUser(Socket client, string userName)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(userName);
            await client.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
        }

        private async void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessagesListBox.Items.Add($"{DateTime.Now} | {_userName}: {MessageTextBox.Text}");
            foreach (var item in _clients)
            {
                SendMessage(item, $"{_userName}: {MessageTextBox.Text}");
            }
            MessageTextBox.Clear();
        }
    }
}