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
    
    public partial class customer
    {
        public customer()
        {
            this.customer_credit = new HashSet<customer_credit>();
            this.customer_debit = new HashSet<customer_debit>();
            this.customer_receive_time = new HashSet<customer_receive_time>();
            this.material_credit = new HashSet<material_credit>();
        }
    
        public int الرقم { get; set; }
        public string اسم_الربون { get; set; }
        public double الرصيد { get; set; }
        public string الرصيد_كتابة { get; set; }
        public string عنوان_الربون { get; set; }
        public string هاتف { get; set; }
        public string الموبايل { get; set; }
        public string البريد_الالكتروني { get; set; }
        public string الموقع_الالكتروني { get; set; }
        public Nullable<System.DateTime> تاريخ { get; set; }
        public string وصف_الربون { get; set; }
        public string صورة { get; set; }
    
        public virtual ICollection<customer_credit> customer_credit { get; set; }
        public virtual ICollection<customer_debit> customer_debit { get; set; }
        public virtual ICollection<customer_receive_time> customer_receive_time { get; set; }
        public virtual ICollection<material_credit> material_credit { get; set; }
    }
}
