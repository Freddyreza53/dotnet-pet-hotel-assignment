using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType {

        Poodle,

        Shepherd,

        Terrier
    }
    public enum PetColorType {

        Black,

        Tricolor,

        Spotted
    }
    public class Pet {
        public int id {get; set;}

        public string name {get; set;}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType breed {get; set;}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColorType color {get; set;}

        [Timestamp]
        // [Default(null)]
        public byte[] CheckedIn {get; set;}

        [ForeignKey("ownedBy")]
        public int PetOwnerId {get; set;}
        public PetOwner ownedBy {get; set;}
        
    }
}
