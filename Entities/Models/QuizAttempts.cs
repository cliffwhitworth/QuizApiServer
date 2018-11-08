using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Entities.Models
{
    [Table("quiz_attempts")]
    public class QuizAttempts
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_quiz_id")]
        public int UserQuizId { get; set; }

        [Column("quiz_score")]
        public Nullable<int> QuizScore { get; set; }

        [Column("quiz_items")]
        public Nullable<int> QuizItems { get; set; }

        [Column("score_date")]
        public Nullable<DateTime> ScoreDate { get; set; }

        [Column("comments")]
        public string Comments { get; set; }
    }
}
