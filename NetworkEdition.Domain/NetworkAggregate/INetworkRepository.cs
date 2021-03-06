namespace NetworkEdition.Domain.NetworkAggregate
{
    public interface INetworkRepository
    {
        NetworkIdentifier Create();

        Network Read(NetworkIdentifier id);

        void Update(Network network);

        void Delete(NetworkIdentifier id);
    }
}