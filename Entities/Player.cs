﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoCrudMvc.Entities
{
    public partial class Player
    {
        [Key]
        public int PlayerID { get; set; }
        [Unicode(false)]
        public string PlayerName { get; set; }
        public int? PlayerAge { get; set; }
        [Unicode(false)]
        public string PlayerAddress { get; set; }
        public DateTime? PlayerJoiningDate { get; set; }
    }
}