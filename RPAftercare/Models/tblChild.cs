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
    
    public partial class tblChild
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblChild()
        {
            this.tblParentChilds = new HashSet<tblParentChild>();
        }
    
        public int ChildID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Grade { get; set; }
        public string Age { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblParentChild> tblParentChilds { get; set; }
    }
}
