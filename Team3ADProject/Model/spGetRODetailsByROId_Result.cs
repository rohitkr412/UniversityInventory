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
    
    public partial class spGetRODetailsByROId_Result
    {
        public string requisition_id { get; set; }
        public string item_number { get; set; }
        public string description { get; set; }
        public string unit_of_measurement { get; set; }
        public Nullable<int> item_requisition_quantity { get; set; }
        public int current_quantity { get; set; }
        public Nullable<int> item_pending_quantity { get; set; }
    }
}