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
    
    public partial class liability
    {
        public liability()
        {
            this.liability_credit = new HashSet<liability_credit>();
            this.liability_debit = new HashSet<liability_debit>();
        }
    
        public int الرقم { get; set; }
        public string الإلتزام { get; set; }
        public double الرصيد { get; set; }
        public string الرصيد_كتابة { get; set; }
        public System.DateTime تاريخ { get; set; }
        public string نوع_الإلتزام { get; set; }
        public Nullable<int> نسبة_الفائدة { get; set; }
    
        public virtual ICollection<liability_credit> liability_credit { get; set; }
        public virtual ICollection<liability_debit> liability_debit { get; set; }
    }
}
