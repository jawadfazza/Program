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
    
    public partial class materialMaker_credit
    {
        public materialMaker_credit()
        {
            this.materialMaker_credit_list = new HashSet<materialMaker_credit_list>();
        }
    
        public System.Guid الرقم { get; set; }
        public Nullable<System.Guid> رقم_المصنع { get; set; }
        public System.DateTime تاريخ_بداية_التصنيع { get; set; }
        public System.DateTime تاريخ_نهاية_التصنيع { get; set; }
        public double الكلفة { get; set; }
        public string الرصيد_كتابة { get; set; }
        public string الى { get; set; }
        public Nullable<System.Guid> المستودع { get; set; }
        public Nullable<double> هدر { get; set; }
        public Nullable<double> مصاريف_مضافة { get; set; }
        public Nullable<double> كمية_الانتاج { get; set; }
        public string code { get; set; }
        public Nullable<System.Guid> companyID { get; set; }
    
        public virtual material_maker material_maker { get; set; }
        public virtual WareHouse WareHouse { get; set; }
        public virtual ICollection<materialMaker_credit_list> materialMaker_credit_list { get; set; }
    }
}
