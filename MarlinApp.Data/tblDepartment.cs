//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarlinApp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblDepartment
    {
        public int Department_ID { get; set; }
        public Nullable<int> Manufacturer_ID { get; set; }
        public string Department_Name { get; set; }
        public Nullable<int> Department_Phone { get; set; }
        public string Department_Email { get; set; }
    
        public virtual tblManufacturer tblManufacturer { get; set; }
    }
}
