using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace SocketProjectClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    //Connect
                    client.Connect(new IPEndPoint(IPAddress.Parse($"192.168.0.{ipIdentifier.Text}"), 13356));

                    //Write Message
                    byte[] buffer = Encoding.UTF8.GetBytes(textBox.Text);
                    client.GetStream().Write(buffer, 0, buffer.Length);
                }
                catch (Exception a)
                {
                    ipIdentifier.Text = a.ToString();
                }                
            }
        }
    }
}
