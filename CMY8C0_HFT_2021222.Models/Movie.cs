using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMY8C0_HFT_2021222.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        [StringLength(80)]
        public string Title { get; set; }
        public double Income { get; set; }
        [Range(0,10)]
        public double Rating { get; set; }
        public DateTime Release { get; set; }
        [ForeignKey(nameof(Director))]
        public int DirectorId { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public Movie()
        {
            Actors = new HashSet<Actor>();
        }
    }
}
