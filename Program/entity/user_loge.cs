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
    
    public partial class user_loge
    {
        public user_loge()
        {
            this.user_loge_date = new HashSet<user_loge_date>();
            this.user_task = new HashSet<user_task>();
        }
    
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string user_type { get; set; }
        public string enable_delete { get; set; }
        public string remamber { get; set; }
    
        public virtual ICollection<user_loge_date> user_loge_date { get; set; }
        public virtual ICollection<user_task> user_task { get; set; }
    }
}
