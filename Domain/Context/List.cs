//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class List
    {
        public int idnum { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string createdBy { get; set; }
        public string assignee { get; set; }
        public Nullable<System.DateTime> deadline { get; set; }
        public string priority { get; set; }
    }
}
