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
    
    public partial class material_credit_penfit_payment
    {
        public int رقم_التقرير { get; set; }
        public int الفائدة { get; set; }
        public int نسبة_الفائدة { get; set; }
        public int الدفع_كل { get; set; }
        public int عدد_الاقساط { get; set; }
        public Nullable<int> العرابون { get; set; }
    
        public virtual material_credit material_credit { get; set; }
    }
}
