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
    
    public partial class MucTieuMonHoc
    {
        public int Id { get; set; }
        public Nullable<int> DeCuongChiTiet_Id { get; set; }
        public string Loai { get; set; }
        public string NoiDung { get; set; }
        public Nullable<double> STT { get; set; }
    
        public virtual DeCuongChiTiet DeCuongChiTiet { get; set; }
    }
}
