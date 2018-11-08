using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("user_quiz")]
    public class UserQuiz
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("quiz_taker_id")]
        public int UserId { get; set; }

        [Column("quiz_settings_id")]
        public int SettingsId { get; set; }

        [Column("quiz_id")]
        public int QuizId { get; set; }

    }
}