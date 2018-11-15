using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace sqlitedbapp.Models
{
    [DataContract]
    public class Price
    {

        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataMember]
        public int SessionId { get; set; }
        [ForeignKey("SessionId")]
        public Session Session { get; set; }
        public long TimeStamp { get; set; }
        [DataMember]
        public float USD { get; set; }
        [DataMember]
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