using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Entities.Models
{
    [Table("quiz_settings")]
    public class QuizSettings
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("quiz_name")]
        public string QuizName { get; set; }

        [Column("open")]
        public Nullable<DateTime> Open { get; set; }

        [Column("close")]
        public Nullable<DateTime> Close { get; set; }

        [Column("feedback")]
        public string Feedback { get; set; }

        [Column("quiz_order")]
        public Nullable<int> QuizOrder { get; set; }

        [Column("administrator")]
        public int Administrator { get; set; }

        [Column("attempts")]
        public Nullable<int> Attempts { get; set; }

        public int QuizId { get; set; }

        public int SettingsId { get; set; }

        public int UserId { get; set; }


    }
}
