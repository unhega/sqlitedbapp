using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace sqlitedbapp.Models
{
    // [JsonObject]
    public class Price
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SessionId { get; set; }
        [ForeignKey("SessionId")]
        public Session Session { get; set; }
        public long TimeStamp { get; set; }
        public string Currency { get; set; }
        public float Value { get; set; }

        public override string ToString()
        {
            return $"ID:\t{Id}|Time:\t{TimeStamp}|Currency:\t{Currency}|Value:\t{Value}";
        }

        [OnDeserializing]
        void OnDeserializing(StreamingContext c)
        {
            TimeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}