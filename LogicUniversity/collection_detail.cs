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
    
    public partial class collection_detail
    {
        public int collection_id { get; set; }
        public int disbursement_list_id { get; set; }
        public int place_id { get; set; }
        public System.DateTime collection_date { get; set; }
        public string collection_status { get; set; }
    
        public virtual collection collection { get; set; }
        public virtual requisition_disbursement_detail requisition_disbursement_detail { get; set; }
    }
}
