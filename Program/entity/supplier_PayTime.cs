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
    
    public partial class supplier_PayTime
    {
        public int الرقم { get; set; }
        public double الرصيد { get; set; }
        public string الرصيد_كتابة { get; set; }
        public string ملاحطات { get; set; }
        public Nullable<System.DateTime> تاريخ { get; set; }
        public Nullable<int> Supplier_id { get; set; }
        public string تم_الدفع { get; set; }
    
        public virtual supplier supplier { get; set; }
    }
}
