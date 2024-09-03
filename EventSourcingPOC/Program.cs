using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EventSourcingPOC;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddTransient<IPokemonDatabase, PokemonLocalDatabase>();

using IHost host = builder.Build();

PlayWithEventSourcing(host.Services);

await host.RunAsync();

static void PlayWithEventSourcing(IServiceProvider hostProvider)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    IPokemonDatabase db = provider.GetRequiredService<IPokemonDatabase>();

    var pokemonDatabase = db;
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

    Pokemon? pokemon = pokemonDatabase.GetPokemon(pokemonId);
    Console.WriteLine();
}
