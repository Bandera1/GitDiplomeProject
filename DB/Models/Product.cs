using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DiplomeProject.DB.Models
{
    public class Product
    {
        public Product()
        {
            this.PhotoBase64 = "";
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string Article { get; set; }
        public string StatusId { get; set; }
        public float Price { get; set; }
        public string ProducerId { get; set; }
        public float DiscountPercent { get; set; }
        public float WeightInKilogram { get; set; }
        public string PhotoPath { get; set; }
        public string Description { get; set; }
        public string PhotoBase64 { get; set; }

        public virtual Category Category { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual ProductStatus Status { get; set; }
    }
}
