using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.BaseEntity
{
    public abstract class BaseEntityDto
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }

    }
}
