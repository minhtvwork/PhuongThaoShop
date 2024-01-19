﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Domain.Entities
{
    [Table("Manufacturer")]
    public class ManufacturerEntity : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string? Name { get; set; }
        public virtual ICollection<ProductEntity>? ProductEntities { get; set; }
    }
}
