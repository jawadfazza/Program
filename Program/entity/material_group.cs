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
    
    public partial class material_group
    {
        public material_group()
        {
            this.material = new HashSet<material>();
            this.material_maker = new HashSet<material_maker>();
        }
    
        public int رقم_المجموعة { get; set; }
        public string اسم_المجموعة { get; set; }
    
        public virtual ICollection<material> material { get; set; }
        public virtual ICollection<material_maker> material_maker { get; set; }
    }
}