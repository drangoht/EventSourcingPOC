using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingPOC
{
    public class PokemonCreatedEvent : Event
    {
        public required Guid PokemonId { get; init; }
        public required string PokemonName { get; init; }
        public required string PokemonDescription { get; init; }
        public required int PokemonStrength { get; init; }
        public required int PokemonHealth { get; init; }
        public override Guid StreamId => PokemonId;
    }
}
