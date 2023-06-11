using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DiplomeProject.DB.Models
{
    public class ProductStatus
    {
        // Code 0 - avaliable
        // Code 1 - run out
        // Code 2 - not avaliable


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string StatusName { get; set; }
        public int StatusCode { get; set; }
    }
}
