//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RPAftercare.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblParentChild
    {
        public int ParentChildID { get; set; }
        public int ParentID { get; set; }
        public int ChildID { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual tblChild tblChild { get; set; }
        public virtual tblParent tblParent { get; set; }
        public virtual tblParentChild tblParentChild1 { get; set; }
        public virtual tblParentChild tblParentChild2 { get; set; }
    }
}
