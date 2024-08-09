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
    
    public partial class material_debit
    {
        public material_debit()
        {
            this.material_debit_list = new HashSet<material_debit_list>();
            this.material_debit_penfit_payment = new HashSet<material_debit_penfit_payment>();
        }
    
        public int الرقم { get; set; }
        public System.DateTime تاريخ { get; set; }
        public double الرصيد { get; set; }
        public string من { get; set; }
        public string الرصيد_كتابة { get; set; }
        public Nullable<int> رقم_فاتورة_المصدر { get; set; }
        public Nullable<System.DateTime> تاريخ_فاتورة_المصدر { get; set; }
        public string المصدر { get; set; }
        public string المستودع { get; set; }
        public int المورد { get; set; }
        public string حذفة { get; set; }
        public string نوع_العملية { get; set; }
        public Nullable<double> حسم_مكتسب { get; set; }
        public Nullable<double> مصاريف_مضافة { get; set; }
        public string مصاريف_على_حساب { get; set; }
        public string مرحل { get; set; }
        public string طريقة_الدفع { get; set; }
        public string اسم_الحساب { get; set; }
        public Nullable<int> سند_الدفع { get; set; }
        public string اسم_مكتب { get; set; }
    
        public virtual supplier supplier { get; set; }
        public virtual ICollection<material_debit_list> material_debit_list { get; set; }
        public virtual ICollection<material_debit_penfit_payment> material_debit_penfit_payment { get; set; }
    }
}