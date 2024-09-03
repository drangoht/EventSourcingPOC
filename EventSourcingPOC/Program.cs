

using EventSourcingPOC;

var pokemonDatabase = new PokemonDatabase();
var pokemonId = Guid.NewGuid();
var pokemonCreatedEvent = new PokemonCreatedEvent()
{
    PokemonId = pokemonId,
    PokemonName = "Pikachu",
    PokemonDescription = "Yellow and electrifying",
    PokemonHealth = 100,
    PokemonStrength = 20
};
pokemonDatabase.Append(pokemonCreatedEvent);

var pokemonUpdatedEvent = new PokemonUpdatedEvent()
{
    PokemonId = pokemonId,
    PokemonName = "Pikachu",
    PokemonDescription = "Yellow and electrifying everyone",
    PokemonHealth = 100,
    PokemonStrength = 20
};

pokemonDatabase.Append(pokemonUpdatedEvent);

var pokemonHurtedEvent = new PokemonHurtedEvent()
{
    PokemonId = pokemonId,
    PokemonName = "Pikachu",
    PokemonDescription = "Yellow and electrifying everyone",
    PokemonHealth = 80,
    PokemonStrength = 20
};

pokemonDatabase.Append(pokemonHurtedEvent);

Pokemon pokemon = pokemonDatabase.GetPokemon(pokemonId)!;
Console.WriteLine();