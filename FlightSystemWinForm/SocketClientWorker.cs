using System.Net.Sockets;
using System.Text;

namespace FlightSystemWinForm
{
    public class SocketClientWorker : IDisposable
    {
        private TcpClient? _socketClient;
        private NetworkStream? _socketStream;
        private CancellationTokenSource _cts;
        public event Action<string, string>? OnFlightReceived;
        public event Action<int> OnSeatReceived;

        public SocketClientWorker()
        {
            _cts = new CancellationTokenSource();
        }

        public async Task ConnectAsync(string host, int port)
        {
            if (_socketClient?.Connected == true) return;

            _socketClient?.Dispose();
            _socketClient = new TcpClient();
            await _socketClient.ConnectAsync(host, port);
            _socketStream = _socketClient.GetStream();
            _ = ListenForMessagesAsync(_cts.Token);
        }

        private async Task ListenForMessagesAsync(CancellationToken token)
        {
            var buffer = new byte[1024];
            var messageBuilder = new StringBuilder();

            try
            {
                while (!token.IsCancellationRequested && _socketStream != null)
                {
                    var bytesRead = await _socketStream.ReadAsync(buffer, 0, buffer.Length, token);
                    if (bytesRead == 0) break;

                    messageBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                    string fullBuffer = messageBuilder.ToString();

                    string[] messages = fullBuffer.Split('\n');
                    for (int i = 0; i < messages.Length - 1; i++)
                    {
                        HandleMessage(messages[i].Trim());
                    }
                    messageBuilder.Clear();
                    messageBuilder.Append(messages.Last());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Socket error: {ex.Message}");
                await Task.Delay(5000, token);
                await ConnectAsync("localhost", 6001);
            }
        }


        private void HandleMessage(string message)
        {
            var parts = message.Split('|');
            switch (parts[0])
            {
                case "FLIGHT_STATUS":
                    if (parts.Length == 3)
                    {
                        OnFlightReceived?.Invoke(parts[1], parts[2]);
                    }
                    break;

                case "SEAT_ASSIGNED":
                    if (parts.Length == 2 && int.TryParse(parts[1], out int seatId))
                    {
                        OnSeatReceived?.Invoke(seatId);
                    }
                    break;

                default:
                    MessageBox.Show("Unknown message type: " + parts[0]);
                    break;
            }
        }

        public TcpClient? GetClient() => _socketClient;

        public void Dispose()
        {
            _cts.Cancel();
            _socketStream?.Dispose();
            _socketClient?.Dispose();
            _cts.Dispose();
        }
    }
}
