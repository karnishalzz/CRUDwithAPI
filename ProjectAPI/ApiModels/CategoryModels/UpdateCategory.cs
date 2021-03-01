using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.ApiModels.CategoryModels
{
    public class UpdateCategory
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string CategoryName { get; set; }

        [MaxLength(200)]
        [MinLength(20)]
        public string Description { get; set; }
    }
}
