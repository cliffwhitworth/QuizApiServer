using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("quiz_mc_item_choice")]
    public class Option
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("itemid")]
        public int ItemId { get; set; }

        [Column("choicetext")]
        public string ChoiceText { get; set; }

        [Column("iscorrect")]
        public int IsCorrect { get; set; }

        [Column("order")]
        public int Order { get; set; }

    }
}

