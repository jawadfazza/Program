//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Program.entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class material_cost
    {
        public Nullable<int> المادة { get; set; }
        public int سعر_الشراء { get; set; }
        public int كمية { get; set; }
        public Nullable<System.DateTime> التاريخ { get; set; }
        public Nullable<int> رقم_فاتورة_الشراء { get; set; }
    
        public virtual material material { get; set; }
    }
}
