using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CMY8C0_HFT_2021222.Models
{
    public class Engine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cylinders { get; set; }
        public int Hp { get; set; }
        public int Torqe { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }
        public Engine()
        {
            Cars = new HashSet<Car>();
        }
    }
}
