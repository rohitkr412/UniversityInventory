//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Team3ADProject.Model
{
    using System;
    
    public partial class spReallocateQty_Result
    {
        public string department_id { get; set; }
        public string item_number { get; set; }
        public string description { get; set; }
        public Nullable<int> item_requisition_quantity { get; set; }
        public Nullable<int> item_distributed_quantity { get; set; }
        public string requisition_status { get; set; }
        public Nullable<int> collection_id { get; set; }
    }
}