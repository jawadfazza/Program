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
    
    public partial class materialMaker_credit_list
    {
        public int رقم_المادة { get; set; }
        public int رقم_التقرير { get; set; }
        public string اسم_المادة { get; set; }
        public string الوحدة { get; set; }
        public int الكمية { get; set; }
        public double السعر { get; set; }
        public double السعر_الجمالي { get; set; }
        public string ملاحظات { get; set; }
        public Nullable<int> المستودع { get; set; }
        public Nullable<double> الهدر { get; set; }
        public int الرقم { get; set; }
        public int كمية { get; set; }
        public double سعر { get; set; }
        public double سعر_اجمالي { get; set; }
        public Nullable<double> هدر { get; set; }
    
        public virtual material material { get; set; }
        public virtual materialMaker_credit materialMaker_credit { get; set; }
    }
}
