using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingPOC
{
    public interface IPokemonDatabase
    {
        public void Append(Event @event);
        public Pokemon? GetPokemon(Guid pokemonI);
    }
}
