
using System;

namespace Web.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime FechaCreacion { get; set; }
    }
}
