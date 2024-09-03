namespace EventSourcingPOC
{
    public class PokemonLocalDatabase: IPokemonDatabase
    {
        private readonly Dictionary<Guid, SortedList<DateTime, Event>> _pokemonEvents = new();
        public void Append(Event @event)
        {
            var stream = _pokemonEvents!.GetValueOrDefault(@event.StreamId, null);
            if (stream is null)
            {
                _pokemonEvents[@event.StreamId] = new SortedList<DateTime, Event>();
            }
            @event.CreatedAtUtc = DateTime.UtcNow;
            _pokemonEvents[@event.StreamId].Add(@event.CreatedAtUtc, @event);
        }

        public Pokemon? GetPokemon(Guid pokemonId)
        {
            if (!_pokemonEvents.ContainsKey(pokemonId))
            {
                return null;
            }
            var pokemon = new Pokemon();
            var pokemonEvents = _pokemonEvents[pokemonId];
            foreach (var pokemonEvent in pokemonEvents)
            {
                pokemon.Apply(pokemonEvent.Value);
            }
            return pokemon;
        }
    }
}
