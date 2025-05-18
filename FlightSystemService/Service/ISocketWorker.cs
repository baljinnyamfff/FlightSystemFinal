namespace FlightSystemService.Service
{
    public interface ISocketWorker
    {
        void BroadcastToAgents(string message);
    }
}