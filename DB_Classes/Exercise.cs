namespace SchoolTableCursed
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

        public int SubjNameFK { get; set; }

        public int TeacherFK { get; set; }

        public int Class { get; set; }

        public int ExNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string ExKind { get; set; }

        public int GroupFK { get; set; }

        public virtual Groups Groups { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
