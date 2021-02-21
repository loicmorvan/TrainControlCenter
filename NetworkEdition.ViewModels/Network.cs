using System;
using System.Collections.Generic;

namespace NetworkEdition.ViewModels
{
    public record Network(Guid Identity, string Name, IEnumerable<Relay> Relays);
}