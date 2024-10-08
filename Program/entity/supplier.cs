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
    
    public partial class supplier
    {
        public supplier()
        {
            this.material_credit_return = new HashSet<material_credit_return>();
            this.material_debit = new HashSet<material_debit>();
            this.supplier_debit = new HashSet<supplier_debit>();
            this.supplier_credit = new HashSet<supplier_credit>();
            this.supplier_PayTime = new HashSet<supplier_PayTime>();
        }
    
        public System.Guid الرقم { get; set; }
        public string اسم_المورد { get; set; }
        public double الرصيد { get; set; }
        public string الرصيد_كتابة { get; set; }
        public string عنوان_المورد { get; set; }
        public string هاتف { get; set; }
        public string الموبايل { get; set; }
        public string البريد_الالكتروني { get; set; }
        public string الموقع_الالكتروني { get; set; }
        public Nullable<System.DateTime> تاريخ { get; set; }
        public string وصف_المورد { get; set; }
        public byte[] صورة { get; set; }
        public string code { get; set; }
        public Nullable<System.Guid> companyID { get; set; }
    
        public virtual ICollection<material_credit_return> material_credit_return { get; set; }
        public virtual ICollection<material_debit> material_debit { get; set; }
        public virtual ICollection<supplier_debit> supplier_debit { get; set; }
        public virtual ICollection<supplier_credit> supplier_credit { get; set; }
        public virtual ICollection<supplier_PayTime> supplier_PayTime { get; set; }
    }
}
