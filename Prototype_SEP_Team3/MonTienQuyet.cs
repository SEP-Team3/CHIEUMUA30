//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prototype_SEP_Team3
{
    using System;
    using System.Collections.Generic;
    
    public partial class MonTienQuyet
    {
        public int Id { get; set; }
        public int MonHoc_Id { get; set; }
        public int MonTienQuyet_Id { get; set; }
        public bool Status { get; set; }
    
        public virtual MonHoc MonHoc { get; set; }
        public virtual MonHoc MonHoc1 { get; set; }
    }
}
