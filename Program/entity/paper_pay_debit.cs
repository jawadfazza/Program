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
    
    public partial class paper_pay_debit
    {
        public int الرقم { get; set; }
        public double الرصيد { get; set; }
        public string الرصيد_كتابة { get; set; }
        public string من { get; set; }
        public string ملاحظات { get; set; }
        public Nullable<System.DateTime> تاريخ { get; set; }
        public Nullable<int> paper_pay_id { get; set; }
    
        public virtual paper_pay paper_pay { get; set; }
    }
}
