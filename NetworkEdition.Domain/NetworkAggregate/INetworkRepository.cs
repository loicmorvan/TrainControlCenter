namespace NetworkEdition.Domain.NetworkAggregate
{
    public interface INetworkRepository
    {
        Network Create();

        Network Read(NetworkIdentifier id);

        void Update(Network network);

        void Delete(NetworkIdentifier id);
    }
}