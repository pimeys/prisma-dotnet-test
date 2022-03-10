using System;
using System.Collections.Generic;

namespace dotnet_test
{
    public partial class B
    {
        public int Id1 { get; set; }
        public int Id2 { get; set; }

        public virtual A A { get; set; } = null!;
    }
}
