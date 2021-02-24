using System;

namespace NetworkEdition.ViewModels
{
    public record Network(Guid Identity, string Name, Relay[] Relays);
}