using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace sqlitedbapp.Models
{
    [JsonObject]
    public class Price
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SessionId { get; set; }
        [ForeignKey("SessionId")]
        public Session Session { get; set; }
        public long TimeStamp { get; set; }
        public float USD { get; set; }
        public float RUB { get; set; }

        public override string ToString()
        {
            return $"ID:\t{Id}|Time:\t{TimeStamp}|USD:\t{USD}|RUB:\t{RUB}";
        }

        [OnDeserializing]
        void OnDeserializing(StreamingContext c)
        {
            TimeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}