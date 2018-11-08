using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("quiz_taker_info")]
    public class Users
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("email")]
        public string Name { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("salt")]
        public string Salt { get; set; }

        [Column("first_name")]
        public string Firstname { get; set; }

        [Column("middle_name")]
        public string Middlename { get; set; }

        [Column("last_name")]
        public string Lastname { get; set; }

        [Column("group_id")]
        public int GroupId { get; set; }
    }
}