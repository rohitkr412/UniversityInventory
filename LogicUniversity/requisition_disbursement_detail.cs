//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogicUniversity
{
    using System;
    using System.Collections.Generic;
    
    public partial class requisition_disbursement_detail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public requisition_disbursement_detail()
        {
            this.collection_detail = new HashSet<collection_detail>();
        }
    
        public string requisition_id { get; set; }
        public int disbursement_list_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<collection_detail> collection_detail { get; set; }
        public virtual requisition_order requisition_order { get; set; }
    }
}
