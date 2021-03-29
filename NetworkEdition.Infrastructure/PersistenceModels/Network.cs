using System;

namespace NetworkEdition.Infrastructure.PersistenceModels
{
    public record Network(Guid Id, string Name, Relay[] Relays);
}