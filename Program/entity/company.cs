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
    
    public partial class company
    {
        public System.Guid id { get; set; }
        public string name { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string web_site { get; set; }
        public byte[] logo { get; set; }
        public Nullable<int> FK_Currency { get; set; }
        public string active { get; set; }
        public Nullable<System.DateTime> block_Date { get; set; }
        public Nullable<bool> MainBranch { get; set; }
        public string code { get; set; }
    
        public virtual Currencies Currencies { get; set; }
    }
}
