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
    
    public partial class spGetFullCollectionROIDList_Result
    {
        public string requisition_id { get; set; }
        public string item_number { get; set; }
        public int item_requisition_quantity { get; set; }
        public int item_distributed_quantity { get; set; }
        public int item_pending_quantity { get; set; }
        public Nullable<int> employee_id { get; set; }
        public string requisition_status { get; set; }
        public Nullable<System.DateTime> requisition_date { get; set; }
        public Nullable<int> collection_id { get; set; }
        public string description { get; set; }
        public string unit_of_measurement { get; set; }
        public Nullable<int> current_quantity { get; set; }
        public string department_name { get; set; }
    }
}
