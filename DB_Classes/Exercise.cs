namespace SchoolTableCursed.DB_Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exercise")]
    public partial class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExID { get; set; }

        [Required]
        [StringLength(10)]
        public string AWeek { get; set; }

        [Required]
        [StringLength(50)]
        public string SubjNameFK { get; set; }

        [Required]
        [StringLength(50)]
        public string TeacherFK { get; set; }

        public int Class { get; set; }

        [Required]
        [StringLength(50)]
        public string ExKind { get; set; }

        [Required]
        [StringLength(10)]
        public string GroupFK { get; set; }

        public int ExNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string DayOfWeek { get; set; }

        public virtual Groups Groups { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Week Week { get; set; }
    }
}
