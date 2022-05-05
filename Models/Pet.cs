using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType {

        Poodle,

        Shepherd,

        Terrier,

        Beagle,

        Bulldog,

        Boxer,

        Labrador,

        Retriever
    }
    public enum PetColorType {

        Black,

        Tricolor,

        Spotted,

        White,

        Golden
    }
    public class Pet {
        public int id {get; set;}

        public string name {get; set;}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType breed {get; set;}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColorType color {get; set;}


        public DateTime? checkedInAt {get; set;}

        [ForeignKey("ownedBy")]
        public int PetOwnerId {get; set;}
        public PetOwner ownedBy {get; set;}
        
    }
}
