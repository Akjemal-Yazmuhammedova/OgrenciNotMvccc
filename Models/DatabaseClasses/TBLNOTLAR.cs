//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciNotMvccc.Models.DatabaseClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLNOTLAR
    {
        public int NOTID { get; set; }
        public Nullable<int> DERSID { get; set; }
        public Nullable<int> OGRID { get; set; }
        public Nullable<int> SINAV1 { get; set; }
        public Nullable<int> SINAV2 { get; set; }
        public Nullable<int> SINAV3 { get; set; }
        public Nullable<int> PROJE { get; set; }
        public Nullable<decimal> ORTALAMA { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        public virtual TBLDERSLER TBLDERSLER { get; set; }
        public virtual TBLOGRENCILER TBLOGRENCILER { get; set; }
    }
}