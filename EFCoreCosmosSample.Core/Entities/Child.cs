
using System;
using System.Collections.Generic;

namespace EFCoreCosmosSample.Core.Entities
{
    public record Child
    {
        public Guid FamilyId { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
    }
}
