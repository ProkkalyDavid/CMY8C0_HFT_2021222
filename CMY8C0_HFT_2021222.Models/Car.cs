using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMY8C0_HFT_2021222.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Km { get; set; }
        [NotMapped]
        public virtual Brand brand { get; set; }
        [ForeignKey(nameof(brand))]
        public int BrandId { get; set; }
        [NotMapped]
        public virtual Engine engine { get; set; }
        [ForeignKey(nameof(engine))]
        public int EngineId { get; set; }
        public Car()
        {

        }
    }
}
