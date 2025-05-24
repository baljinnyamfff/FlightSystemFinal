using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using FlightSystemService.Service;

namespace FlightSystemServer
{
    public class SocketWorker : BackgroundService, ISocketWorker
    {
        private readonly List<TcpClient> _agentClients = new();
        private readonly object _lock = new();
        private readonly ILogger<SocketWorker> _logger;

        public SocketWorker(ILogger<SocketWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var listener = new TcpListener(IPAddress.Any, 6001);
            listener.Start();
            _logger.LogInformation("Socket server started on port 6001");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var client = await listener.AcceptTcpClientAsync();
                    _logger.LogInformation("New agent connected");

                    lock (_lock)
                    {
                        _agentClients.Add(client);
                    }

                    _ = HandleClientDisconnectionAsync(client, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error accepting client connection");
                }
            }
        }

        private async Task HandleClientDisconnectionAsync(TcpClient client, CancellationToken stoppingToken)
        {
            try
            {
                var stream = client.GetStream();
                var buffer = new byte[1024];

                while (!stoppingToken.IsCancellationRequested)
                {
                    if (!IsClientConnected(client))
                    {
                        RemoveClient(client);
                        break;
                    }
                    await Task.Delay(1000, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error handling client disconnection");
                RemoveClient(client);
            }
        }

        private bool IsClientConnected(TcpClient client)
        {
            try
            {
                if (client.Client.Poll(0, SelectMode.SelectRead))
                {
                    byte[] buff = new byte[1];
                    if (client.Client.Receive(buff, SocketFlags.Peek) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void RemoveClient(TcpClient client)
        {
            lock (_lock)
            {
                _agentClients.Remove(client);
                client.Close();
                _logger.LogInformation("Agent disconnected");
            }
        }

        public void BroadcastToAgents(string message)
        {
            var data = Encoding.UTF8.GetBytes(message);

            lock (_lock)
            {
                foreach (var client in _agentClients.ToList())
                {
                    try
                    {
                        if (IsClientConnected(client))
                        {
                            var stream = client.GetStream();
                            stream.Write(data, 0, data.Length);
                            _logger.LogInformation($"Broadcasted message to agent: {message}");
                        }
                        else
                        {
                            RemoveClient(client);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error broadcasting to agent");
                        RemoveClient(client);
                    }
                }
            }
        }
    }
}