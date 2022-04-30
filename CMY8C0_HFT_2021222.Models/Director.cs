using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMY8C0_HFT_2021222.Models
{
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DirectorId { get; set; }

        [Required]
        [StringLength(150)]
        public string DirectorName { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public Director()
        {
            this.Movies = new HashSet<Movie>();
        }
    }
}
