using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RBAProject.Models
{
    public partial class CarImage
    {
        public CarImage()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
        public string CarId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
