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
    
    public partial class sp_getPendingPOList_Result
    {
        public int purchase_order_number { get; set; }
        public string supplier_name { get; set; }
        public System.DateTime purchase_order_date { get; set; }
        public string employee_name { get; set; }
        public Nullable<double> total_price { get; set; }
    }
}
