using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.ApiModels.CategoryModels
{
    public class CategoryDetails
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? LastModifiedAtUtc { get; set; }
    }
}
