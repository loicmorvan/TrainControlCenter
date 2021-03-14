using System;
using System.Collections.Generic;

namespace NetworkEdition.Infrastructure.PersistenceModels
{
    public record Network(Guid Identity, string Name, Relay[] Relays);
}