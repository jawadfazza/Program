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
    
    public partial class audit
    {
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> user_id { get; set; }
        public string action_type { get; set; }
        public string table_name { get; set; }
        public Nullable<System.Guid> record_id { get; set; }
        public Nullable<System.DateTime> timestamp { get; set; }
        public string ip_address { get; set; }
        public string device_info { get; set; }
        public string details { get; set; }
    
        public virtual user_profile user_profile { get; set; }
    }
}
