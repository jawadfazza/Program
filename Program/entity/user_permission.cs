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
    
    public partial class user_permission
    {
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> action_id { get; set; }
        public Nullable<bool> action_active { get; set; }
        public Nullable<System.Guid> user_id { get; set; }
        public Nullable<System.DateTime> assigned_at { get; set; }
    
        public virtual action action { get; set; }
        public virtual action action1 { get; set; }
        public virtual user_profile user_profile { get; set; }
    }
}