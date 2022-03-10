using System;
using System.Collections.Generic;

namespace dotnet_test
{
    public partial class A
    {
        public int Id { get; set; }
        public int B1 { get; set; }
        public int B2 { get; set; }

        public virtual B B { get; set; } = null!;
    }
}
