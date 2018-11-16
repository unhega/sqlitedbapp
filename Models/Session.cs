using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sqlitedbapp.Models
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset BeginTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public SessionStatus Status { get; set; }
        public List<Price> Prices { get; set; }

    }

    public enum SessionStatus
    {
        Online,
        Offline
    }
}