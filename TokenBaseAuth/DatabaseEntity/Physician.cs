using System;
using System.Collections.Generic;

namespace TokenBaseAuth.DatabaseEntity
{
    public partial class Physician
    {
        public int PhysicianId { get; set; }
        public string PhysicianName { get; set; } = null!;
        public string PhysicianState { get; set; } = null!;
    }
}
