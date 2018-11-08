using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("quiz_mc_item")]
    public class Stem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("quizid")]
        public int QuizId { get; set; }

        [Column("itemtext")]
        public string ItemText { get; set; }

        [Column("explanation")]
        public string Explanation { get; set; }

        [Column("order")]
        public int Order { get; set; }

    }
}
