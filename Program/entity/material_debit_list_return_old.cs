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
    
    public partial class material_debit_list_return_old
    {
        public int رقم_المادة { get; set; }
        public string رقم_التقرير { get; set; }
        public string اسم_المادة { get; set; }
        public string الوحدة { get; set; }
        public int الكمية { get; set; }
        public double السعر { get; set; }
        public double السعر_الجمالي { get; set; }
        public string ملاحظات { get; set; }
        public Nullable<int> المستودع { get; set; }
        public string الكمية_كتابة { get; set; }
        public string حذفة { get; set; }
        public Nullable<double> حسم_مكتسب { get; set; }
    
        public virtual material material { get; set; }
        public virtual material_debit_return_old material_debit_return_old { get; set; }
    }
}
