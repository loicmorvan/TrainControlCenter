using System;

namespace NetworkEdition.Infrastructure.PersistenceModels
{
    public record Relay(Guid Id, string Name, bool IsClosed, double X, double Y);
}