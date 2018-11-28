using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace sqlitedbapp.Models
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset BeginTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public SessionStatus Status { get; set; }
        public List<Price> Prices { get; set; }
        public List<Concurency> Concurencies { get; set; }



    }

    public enum SessionStatus
    {
        Online,
        Offline
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Concurency
    {
        USD,
        RUB
    }
}