using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingPOC
{
    public class Pokemon
    {
        public Guid PokemonId { get; set; }
        public string PokemonName { get; set; }
        public string PokemonDescription { get; set; }
        public int PokemonStrength { get; set; }
        public int PokemonHealth { get; set; }
        
        private void Apply(PokemonCreatedEvent createdEvent)
        {
            PokemonId = createdEvent.PokemonId;
            PokemonName = createdEvent.PokemonName;
            PokemonDescription = createdEvent.PokemonDescription;
            PokemonStrength = createdEvent.PokemonStrength;
            PokemonHealth = createdEvent.PokemonHealth;
        }

        private void Apply(PokemonUpdatedEvent updatedEvent)
        {
            PokemonName = updatedEvent.PokemonName;
            PokemonDescription = updatedEvent.PokemonDescription;
            PokemonStrength = updatedEvent.PokemonStrength;
            PokemonHealth = updatedEvent.PokemonHealth;
        }
        private void Apply(PokemonHurtedEvent hurtedEvent)
        {
            PokemonHealth = hurtedEvent.PokemonHealth;
        }
        public void Apply(Event @event) 
        {
            switch (@event)
            {
                case PokemonCreatedEvent pokemonCreatedEvent:
                    Apply(pokemonCreatedEvent);
                    break;
                case PokemonUpdatedEvent pokemonUpdatedEvent:
                    Apply(pokemonUpdatedEvent);
                    break;

                case PokemonHurtedEvent pokemonHurtedEvent:
                    Apply(pokemonHurtedEvent);
                    break;

            }
        }


    }
}
