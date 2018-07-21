﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LogicUniversityEntities : DbContext
    {
        public LogicUniversityEntities()
            : base("name=LogicUniversityEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<adjustment> adjustments { get; set; }
        public virtual DbSet<budget> budgets { get; set; }
        public virtual DbSet<collection> collections { get; set; }
        public virtual DbSet<collection_detail> collection_detail { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<department_rep> department_rep { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<inventory> inventories { get; set; }
        public virtual DbSet<purchase_order> purchase_order { get; set; }
        public virtual DbSet<purchase_order_detail> purchase_order_detail { get; set; }
        public virtual DbSet<requisition_order> requisition_order { get; set; }
        public virtual DbSet<requisition_order_detail> requisition_order_detail { get; set; }
        public virtual DbSet<supplier> suppliers { get; set; }
        public virtual DbSet<supplier_itemdetail> supplier_itemdetail { get; set; }
    
        public virtual ObjectResult<getAllViewPOHistorypendingcount_Result> getAllViewPOHistorypendingcount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAllViewPOHistorypendingcount_Result>("getAllViewPOHistorypendingcount");
        }
    
        public virtual ObjectResult<getAllViewPOHistorypendingcountbyPO_Result> getAllViewPOHistorypendingcountbyPO(Nullable<int> varpo)
        {
            var varpoParameter = varpo.HasValue ?
                new ObjectParameter("varpo", varpo) :
                new ObjectParameter("varpo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAllViewPOHistorypendingcountbyPO_Result>("getAllViewPOHistorypendingcountbyPO", varpoParameter);
        }
    
        public virtual ObjectResult<getAllViewPOHistorypendingcountbyPOandStatus_Result> getAllViewPOHistorypendingcountbyPOandStatus(Nullable<int> varpo, string varstat)
        {
            var varpoParameter = varpo.HasValue ?
                new ObjectParameter("varpo", varpo) :
                new ObjectParameter("varpo", typeof(int));
    
            var varstatParameter = varstat != null ?
                new ObjectParameter("varstat", varstat) :
                new ObjectParameter("varstat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAllViewPOHistorypendingcountbyPOandStatus_Result>("getAllViewPOHistorypendingcountbyPOandStatus", varpoParameter, varstatParameter);
        }
    
        public virtual ObjectResult<getAllViewPOHistorypendingcountbyStatus_Result> getAllViewPOHistorypendingcountbyStatus(string varstat)
        {
            var varstatParameter = varstat != null ?
                new ObjectParameter("varstat", varstat) :
                new ObjectParameter("varstat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAllViewPOHistorypendingcountbyStatus_Result>("getAllViewPOHistorypendingcountbyStatus", varstatParameter);
        }
    
        public virtual ObjectResult<getAllViewPOHistorypendingcountbySupandPo_Result> getAllViewPOHistorypendingcountbySupandPo(Nullable<int> varpo, string varsup)
        {
            var varpoParameter = varpo.HasValue ?
                new ObjectParameter("varpo", varpo) :
                new ObjectParameter("varpo", typeof(int));
    
            var varsupParameter = varsup != null ?
                new ObjectParameter("varsup", varsup) :
                new ObjectParameter("varsup", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAllViewPOHistorypendingcountbySupandPo_Result>("getAllViewPOHistorypendingcountbySupandPo", varpoParameter, varsupParameter);
        }
    
        public virtual ObjectResult<getAllViewPOHistorypendingcountbySupandPoandStatus_Result> getAllViewPOHistorypendingcountbySupandPoandStatus(Nullable<int> varpo, string varsup, string varstat)
        {
            var varpoParameter = varpo.HasValue ?
                new ObjectParameter("varpo", varpo) :
                new ObjectParameter("varpo", typeof(int));
    
            var varsupParameter = varsup != null ?
                new ObjectParameter("varsup", varsup) :
                new ObjectParameter("varsup", typeof(string));
    
            var varstatParameter = varstat != null ?
                new ObjectParameter("varstat", varstat) :
                new ObjectParameter("varstat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAllViewPOHistorypendingcountbySupandPoandStatus_Result>("getAllViewPOHistorypendingcountbySupandPoandStatus", varpoParameter, varsupParameter, varstatParameter);
        }
    
        public virtual ObjectResult<getAllViewPOHistorypendingcountbySupandStatus_Result> getAllViewPOHistorypendingcountbySupandStatus(string varsup, string varstat)
        {
            var varsupParameter = varsup != null ?
                new ObjectParameter("varsup", varsup) :
                new ObjectParameter("varsup", typeof(string));
    
            var varstatParameter = varstat != null ?
                new ObjectParameter("varstat", varstat) :
                new ObjectParameter("varstat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAllViewPOHistorypendingcountbySupandStatus_Result>("getAllViewPOHistorypendingcountbySupandStatus", varsupParameter, varstatParameter);
        }
    
        public virtual ObjectResult<getAllViewPOHistorypendingcountbySupplier_Result> getAllViewPOHistorypendingcountbySupplier(string varsup)
        {
            var varsupParameter = varsup != null ?
                new ObjectParameter("varsup", varsup) :
                new ObjectParameter("varsup", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAllViewPOHistorypendingcountbySupplier_Result>("getAllViewPOHistorypendingcountbySupplier", varsupParameter);
        }
    
        public virtual ObjectResult<getAllViewPOHistorytotalcount_Result> getAllViewPOHistorytotalcount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAllViewPOHistorytotalcount_Result>("getAllViewPOHistorytotalcount");
        }
    
        public virtual ObjectResult<getApprovedRequisitionsWithNoDisbursementIdByDepartment_Result> getApprovedRequisitionsWithNoDisbursementIdByDepartment()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getApprovedRequisitionsWithNoDisbursementIdByDepartment_Result>("getApprovedRequisitionsWithNoDisbursementIdByDepartment");
        }
    
        public virtual ObjectResult<getitemdetails_Result> getitemdetails(string requisitionnumber)
        {
            var requisitionnumberParameter = requisitionnumber != null ?
                new ObjectParameter("requisitionnumber", requisitionnumber) :
                new ObjectParameter("requisitionnumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getitemdetails_Result>("getitemdetails", requisitionnumberParameter);
        }
    
        public virtual ObjectResult<getLowStockItemsByCategory_Result> getLowStockItemsByCategory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getLowStockItemsByCategory_Result>("getLowStockItemsByCategory");
        }
    
        public virtual ObjectResult<getPendingPurchaseOrderCountBySupplier_Result> getPendingPurchaseOrderCountBySupplier()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPendingPurchaseOrderCountBySupplier_Result>("getPendingPurchaseOrderCountBySupplier");
        }
    
        public virtual ObjectResult<getpendingrequestdetails_Result> getpendingrequestdetails(string requisitionnumber)
        {
            var requisitionnumberParameter = requisitionnumber != null ?
                new ObjectParameter("requisitionnumber", requisitionnumber) :
                new ObjectParameter("requisitionnumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getpendingrequestdetails_Result>("getpendingrequestdetails", requisitionnumberParameter);
        }
    
        public virtual ObjectResult<getpendingrequestsbydepartment_Result> getpendingrequestsbydepartment(string departmentname)
        {
            var departmentnameParameter = departmentname != null ?
                new ObjectParameter("departmentname", departmentname) :
                new ObjectParameter("departmentname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getpendingrequestsbydepartment_Result>("getpendingrequestsbydepartment", departmentnameParameter);
        }
    
        public virtual ObjectResult<getPurchaseQuantityByItemCategory_Result> getPurchaseQuantityByItemCategory(Nullable<int> monthsBack)
        {
            var monthsBackParameter = monthsBack.HasValue ?
                new ObjectParameter("MonthsBack", monthsBack) :
                new ObjectParameter("MonthsBack", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPurchaseQuantityByItemCategory_Result>("getPurchaseQuantityByItemCategory", monthsBackParameter);
        }
    
        public virtual ObjectResult<getRecentRequisitionOrders_Result> getRecentRequisitionOrders()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRecentRequisitionOrders_Result>("getRecentRequisitionOrders");
        }
    
        public virtual ObjectResult<getrepdetails_Result> getrepdetails(string depid)
        {
            var depidParameter = depid != null ?
                new ObjectParameter("depid", depid) :
                new ObjectParameter("depid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getrepdetails_Result>("getrepdetails", depidParameter);
        }
    
        public virtual ObjectResult<getRequestedItemQuantityLastYear_Result> getRequestedItemQuantityLastYear(string itemCode)
        {
            var itemCodeParameter = itemCode != null ?
                new ObjectParameter("ItemCode", itemCode) :
                new ObjectParameter("ItemCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRequestedItemQuantityLastYear_Result>("getRequestedItemQuantityLastYear", itemCodeParameter);
        }
    
        public virtual ObjectResult<getrequesthistory_Result> getrequesthistory(string departmentid)
        {
            var departmentidParameter = departmentid != null ?
                new ObjectParameter("departmentid", departmentid) :
                new ObjectParameter("departmentid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getrequesthistory_Result>("getrequesthistory", departmentidParameter);
        }
    
        public virtual ObjectResult<getRequisitionOrderDetails_Result> getRequisitionOrderDetails(string var)
        {
            var varParameter = var != null ?
                new ObjectParameter("var", var) :
                new ObjectParameter("var", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRequisitionOrderDetails_Result>("getRequisitionOrderDetails", varParameter);
        }
    
        public virtual ObjectResult<getRequisitionOrderDetailsforEdit_Result> getRequisitionOrderDetailsforEdit(string var)
        {
            var varParameter = var != null ?
                new ObjectParameter("var", var) :
                new ObjectParameter("var", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRequisitionOrderDetailsforEdit_Result>("getRequisitionOrderDetailsforEdit", varParameter);
        }
    
        public virtual ObjectResult<getRequisitionQuantityByDepartment_Result> getRequisitionQuantityByDepartment()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRequisitionQuantityByDepartment_Result>("getRequisitionQuantityByDepartment");
        }
    
        public virtual ObjectResult<GetRequisitionStatus_Result> GetRequisitionStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetRequisitionStatus_Result>("GetRequisitionStatus");
        }
    
        public virtual ObjectResult<getStationariesOrderedLastMonthByCategory_Result> getStationariesOrderedLastMonthByCategory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getStationariesOrderedLastMonthByCategory_Result>("getStationariesOrderedLastMonthByCategory");
        }
    
        public virtual ObjectResult<getViewPOHistorytotalcountbyPO_Result> getViewPOHistorytotalcountbyPO(Nullable<int> varpo)
        {
            var varpoParameter = varpo.HasValue ?
                new ObjectParameter("varpo", varpo) :
                new ObjectParameter("varpo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getViewPOHistorytotalcountbyPO_Result>("getViewPOHistorytotalcountbyPO", varpoParameter);
        }
    
        public virtual ObjectResult<getViewPOHistorytotalcountbyPOandstatus_Result> getViewPOHistorytotalcountbyPOandstatus(Nullable<int> varpo, string varstat)
        {
            var varpoParameter = varpo.HasValue ?
                new ObjectParameter("varpo", varpo) :
                new ObjectParameter("varpo", typeof(int));
    
            var varstatParameter = varstat != null ?
                new ObjectParameter("varstat", varstat) :
                new ObjectParameter("varstat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getViewPOHistorytotalcountbyPOandstatus_Result>("getViewPOHistorytotalcountbyPOandstatus", varpoParameter, varstatParameter);
        }
    
        public virtual ObjectResult<getViewPOHistorytotalcountbyPOandstatusandSupplier_Result> getViewPOHistorytotalcountbyPOandstatusandSupplier(string varsup, Nullable<int> varpo, string varstat)
        {
            var varsupParameter = varsup != null ?
                new ObjectParameter("varsup", varsup) :
                new ObjectParameter("varsup", typeof(string));
    
            var varpoParameter = varpo.HasValue ?
                new ObjectParameter("varpo", varpo) :
                new ObjectParameter("varpo", typeof(int));
    
            var varstatParameter = varstat != null ?
                new ObjectParameter("varstat", varstat) :
                new ObjectParameter("varstat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getViewPOHistorytotalcountbyPOandstatusandSupplier_Result>("getViewPOHistorytotalcountbyPOandstatusandSupplier", varsupParameter, varpoParameter, varstatParameter);
        }
    
        public virtual ObjectResult<getViewPOHistorytotalcountbyPOandSupplier_Result> getViewPOHistorytotalcountbyPOandSupplier(Nullable<int> varpo, string varsup)
        {
            var varpoParameter = varpo.HasValue ?
                new ObjectParameter("varpo", varpo) :
                new ObjectParameter("varpo", typeof(int));
    
            var varsupParameter = varsup != null ?
                new ObjectParameter("varsup", varsup) :
                new ObjectParameter("varsup", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getViewPOHistorytotalcountbyPOandSupplier_Result>("getViewPOHistorytotalcountbyPOandSupplier", varpoParameter, varsupParameter);
        }
    
        public virtual ObjectResult<getViewPOHistorytotalcountByStatus_Result> getViewPOHistorytotalcountByStatus(string varstat)
        {
            var varstatParameter = varstat != null ?
                new ObjectParameter("varstat", varstat) :
                new ObjectParameter("varstat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getViewPOHistorytotalcountByStatus_Result>("getViewPOHistorytotalcountByStatus", varstatParameter);
        }
    
        public virtual ObjectResult<getViewPOHistorytotalcountbysupandstatus_Result> getViewPOHistorytotalcountbysupandstatus(string varsup, string varstat)
        {
            var varsupParameter = varsup != null ?
                new ObjectParameter("varsup", varsup) :
                new ObjectParameter("varsup", typeof(string));
    
            var varstatParameter = varstat != null ?
                new ObjectParameter("varstat", varstat) :
                new ObjectParameter("varstat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getViewPOHistorytotalcountbysupandstatus_Result>("getViewPOHistorytotalcountbysupandstatus", varsupParameter, varstatParameter);
        }
    
        public virtual ObjectResult<getViewPOHistorytotalcountbySupplier_Result> getViewPOHistorytotalcountbySupplier(string varsup)
        {
            var varsupParameter = varsup != null ?
                new ObjectParameter("varsup", varsup) :
                new ObjectParameter("varsup", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getViewPOHistorytotalcountbySupplier_Result>("getViewPOHistorytotalcountbySupplier", varsupParameter);
        }
    
        public virtual ObjectResult<sp_geteachPendingPOList_Result> sp_geteachPendingPOList(Nullable<int> var4)
        {
            var var4Parameter = var4.HasValue ?
                new ObjectParameter("var4", var4) :
                new ObjectParameter("var4", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_geteachPendingPOList_Result>("sp_geteachPendingPOList", var4Parameter);
        }
    
        public virtual ObjectResult<sp_getPendingPODetails_Result> sp_getPendingPODetails(Nullable<int> var5)
        {
            var var5Parameter = var5.HasValue ?
                new ObjectParameter("var5", var5) :
                new ObjectParameter("var5", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getPendingPODetails_Result>("sp_getPendingPODetails", var5Parameter);
        }
    
        public virtual ObjectResult<sp_getPendingPOList_Result> sp_getPendingPOList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getPendingPOList_Result>("sp_getPendingPOList");
        }
    
        public virtual ObjectResult<spGetCollectionList_Result> spGetCollectionList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetCollectionList_Result>("spGetCollectionList");
        }
    
        public virtual ObjectResult<spGetDepartmentList_Result> spGetDepartmentList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetDepartmentList_Result>("spGetDepartmentList");
        }
    
        public virtual ObjectResult<Nullable<int>> spGetDepartmentPin(string departmentname)
        {
            var departmentnameParameter = departmentname != null ?
                new ObjectParameter("departmentname", departmentname) :
                new ObjectParameter("departmentname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spGetDepartmentPin", departmentnameParameter);
        }
    
        public virtual ObjectResult<spGetPlaceIdFromDptId_Result> spGetPlaceIdFromDptId(string dptId)
        {
            var dptIdParameter = dptId != null ?
                new ObjectParameter("dptId", dptId) :
                new ObjectParameter("dptId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetPlaceIdFromDptId_Result>("spGetPlaceIdFromDptId", dptIdParameter);
        }
    
        public virtual ObjectResult<spGetRODetailsByROId_Result> spGetRODetailsByROId(string roId)
        {
            var roIdParameter = roId != null ?
                new ObjectParameter("roId", roId) :
                new ObjectParameter("roId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetRODetailsByROId_Result>("spGetRODetailsByROId", roIdParameter);
        }
    
        public virtual ObjectResult<spGetUndisbursedROList_Result> spGetUndisbursedROList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetUndisbursedROList_Result>("spGetUndisbursedROList");
        }
    
        public virtual int spInsertCollectionDetail(Nullable<int> placeId, Nullable<System.DateTime> collectionDate, string collectionStatus)
        {
            var placeIdParameter = placeId.HasValue ?
                new ObjectParameter("placeId", placeId) :
                new ObjectParameter("placeId", typeof(int));
    
            var collectionDateParameter = collectionDate.HasValue ?
                new ObjectParameter("collectionDate", collectionDate) :
                new ObjectParameter("collectionDate", typeof(System.DateTime));
    
            var collectionStatusParameter = collectionStatus != null ?
                new ObjectParameter("collectionStatus", collectionStatus) :
                new ObjectParameter("collectionStatus", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertCollectionDetail", placeIdParameter, collectionDateParameter, collectionStatusParameter);
        }
    
        public virtual int spSpecialRequestReady(Nullable<int> placeId, Nullable<System.DateTime> collectionDate, string collectionStatus, string ro_id)
        {
            var placeIdParameter = placeId.HasValue ?
                new ObjectParameter("placeId", placeId) :
                new ObjectParameter("placeId", typeof(int));
    
            var collectionDateParameter = collectionDate.HasValue ?
                new ObjectParameter("collectionDate", collectionDate) :
                new ObjectParameter("collectionDate", typeof(System.DateTime));
    
            var collectionStatusParameter = collectionStatus != null ?
                new ObjectParameter("collectionStatus", collectionStatus) :
                new ObjectParameter("collectionStatus", typeof(string));
    
            var ro_idParameter = ro_id != null ?
                new ObjectParameter("ro_id", ro_id) :
                new ObjectParameter("ro_id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spSpecialRequestReady", placeIdParameter, collectionDateParameter, collectionStatusParameter, ro_idParameter);
        }
    
        public virtual ObjectResult<spViewCollectionList_Result> spViewCollectionList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spViewCollectionList_Result>("spViewCollectionList");
        }
    
        public virtual ObjectResult<getUserTokenByUsername_Result> getUserTokenByUsername(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getUserTokenByUsername_Result>("getUserTokenByUsername", usernameParameter);
        }
    
        public virtual ObjectResult<getUserByToken_Result> getUserByToken(string token)
        {
            var tokenParameter = token != null ?
                new ObjectParameter("token", token) :
                new ObjectParameter("token", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getUserByToken_Result>("getUserByToken", tokenParameter);
        }
    
        public virtual ObjectResult<spAcknowledgeDistributionList_Result> spAcknowledgeDistributionList(Nullable<int> collection_id)
        {
            var collection_idParameter = collection_id.HasValue ?
                new ObjectParameter("collection_id", collection_id) :
                new ObjectParameter("collection_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spAcknowledgeDistributionList_Result>("spAcknowledgeDistributionList", collection_idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spCheckSupplyQuantity(string itemNumber, Nullable<int> collectionID)
        {
            var itemNumberParameter = itemNumber != null ?
                new ObjectParameter("itemNumber", itemNumber) :
                new ObjectParameter("itemNumber", typeof(string));
    
            var collectionIDParameter = collectionID.HasValue ?
                new ObjectParameter("collectionID", collectionID) :
                new ObjectParameter("collectionID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spCheckSupplyQuantity", itemNumberParameter, collectionIDParameter);
        }
    
        public virtual ObjectResult<spGetRequisitionIDAndItemQuantity_Result> spGetRequisitionIDAndItemQuantity(Nullable<int> collectionID, string itemNumber)
        {
            var collectionIDParameter = collectionID.HasValue ?
                new ObjectParameter("collectionID", collectionID) :
                new ObjectParameter("collectionID", typeof(int));
    
            var itemNumberParameter = itemNumber != null ?
                new ObjectParameter("ItemNumber", itemNumber) :
                new ObjectParameter("ItemNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetRequisitionIDAndItemQuantity_Result>("spGetRequisitionIDAndItemQuantity", collectionIDParameter, itemNumberParameter);
        }
    
        public virtual int spUpdateItemDistributedQuantity(string itemNumber, string requisitionID, Nullable<int> itemDistributedQuantity)
        {
            var itemNumberParameter = itemNumber != null ?
                new ObjectParameter("ItemNumber", itemNumber) :
                new ObjectParameter("ItemNumber", typeof(string));
    
            var requisitionIDParameter = requisitionID != null ?
                new ObjectParameter("RequisitionID", requisitionID) :
                new ObjectParameter("RequisitionID", typeof(string));
    
            var itemDistributedQuantityParameter = itemDistributedQuantity.HasValue ?
                new ObjectParameter("ItemDistributedQuantity", itemDistributedQuantity) :
                new ObjectParameter("ItemDistributedQuantity", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUpdateItemDistributedQuantity", itemNumberParameter, requisitionIDParameter, itemDistributedQuantityParameter);
        }
    
        public virtual int spUpdateCollectionStatusCollected(Nullable<int> collection_id)
        {
            var collection_idParameter = collection_id.HasValue ?
                new ObjectParameter("collection_id", collection_id) :
                new ObjectParameter("collection_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUpdateCollectionStatusCollected", collection_idParameter);
        }
    
        public virtual int spUpdateInventory(string itemNumber, Nullable<int> difference)
        {
            var itemNumberParameter = itemNumber != null ?
                new ObjectParameter("ItemNumber", itemNumber) :
                new ObjectParameter("ItemNumber", typeof(string));
    
            var differenceParameter = difference.HasValue ?
                new ObjectParameter("difference", difference) :
                new ObjectParameter("difference", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUpdateInventory", itemNumberParameter, differenceParameter);
        }
    }
}
