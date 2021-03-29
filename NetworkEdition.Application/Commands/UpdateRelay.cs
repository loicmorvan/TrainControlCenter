using System;

namespace NetworkEdition.Application.Commands
{
    public record UpdateRelay(Guid NetworkId, Guid RelayId, double? X, double? Y);
}