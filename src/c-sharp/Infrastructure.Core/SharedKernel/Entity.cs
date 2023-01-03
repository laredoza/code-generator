using System;
using Newtonsoft.Json;

namespace Infrastructure.Core.SharedKernel
{
    public class Entity
    {
        public Guid Id { get; set; }

        public bool Deleted { get; set; } = false;

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
        
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}