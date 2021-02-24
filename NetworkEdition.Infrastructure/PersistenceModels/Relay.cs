using System;

namespace NetworkEdition.Infrastructure.PersistenceModels
{
    public record Relay(Guid Identity, string Name, bool IsClosed, double X, double Y);
}