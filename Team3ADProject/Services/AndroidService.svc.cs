﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Security;
using Team3ADProject.Model;
using Team3ADProject.Code;

namespace Team3ADProject.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AndroidService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AndroidService.svc or AndroidService.svc.cs at the Solution Explorer and start debugging.
    public class AndroidService : IAndroidService
    {
        // CHUA KHIONG YANG START

        // Template for working with Android services and tokens.
        public string Hello(string token)
        {
            // If token is valid, do stuff
            if (AuthenticateToken(token))
            {
                return "hello!";
            }

            // If token is invalid, return null
            else
            {
                return null;
            }
        }

        /* Token methods ===========================*/

        // Authenticates a token
        // Returns true if token exists in employee table
        // Returns false if token doesn't exist in employee table
        protected bool AuthenticateToken(String token)
        {
            var context = new LogicUniversityEntities();
            var query = from x in context.employees where x.token == token select x;

            if (query.Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Generates a token.
        // This token is unique, and contains the time created in the token itself.
        protected string GenerateToken()
        {
            string key = Guid.NewGuid().ToString();
            string token = key;

            return token;
        }


        /* Service methods =========================================*/

        // Fetches an employee by using a token.
        public WCF_Employee GetEmployeeByToken(String token)
        {
            if (AuthenticateToken(token))
            {
                var context = new LogicUniversityEntities();
                var query = from x in context.employees where x.token == token select x;

                // If there exists the token for a user, create a wcf employee and return it
                if (query.Count() != 0)
                {
                    var first = query.First();
                    String role = null;

                    role = Roles.GetRolesForUser(first.user_id).FirstOrDefault();

                    return new WCF_Employee(first.employee_id, first.employee_name, first.email_id, first.user_id, first.department_id, first.supervisor_id, first.token, role);
                }

                else
                {
                    return null;
                }
            }
            return null;
        }


        /*
         * Logs the user into the system.
         * 
         * Takes username and password in
         * If the username and password is valid, this generates a token for the employee
         * This token is stored into the database for validation when using in other methods.
        */

        public WCF_Employee Login(string username, string password)
        {
            WCF_Employee wcfEmployee = null;

            // If login succeeds, fetch the token, otherwise, return null
            // Validate username and password
            if (Membership.ValidateUser(username, password))
            {
                // Fetch or generate token
                var context = new LogicUniversityEntities();
                var query = from x in context.employees where x.user_id == username select x;
                var result = query.ToList();

                if (query.Any())
                {
                    // Generate a token for the resulting employee.
                    String token = GenerateToken();

                    // Store token in database
                    var first = result.First();
                    first.token = token;
                    System.Diagnostics.Debug.WriteLine(context.SaveChanges());

                    // Pass the token to the service consumer
                    wcfEmployee = new WCF_Employee(first.employee_id, first.employee_name, first.email_id, username, first.department_id, first.supervisor_id, token, Roles.GetRolesForUser(username).FirstOrDefault());
                }
            }

            // Return the token to user
            return wcfEmployee;
        }

        // Logs the user out
        /*
         * Doing this will clear the token in the database for the employee, if it exists.
         */
        public string Logout(string token)
        {
            var context = new LogicUniversityEntities();
            var query = from x in context.employees where x.token == token select x;

            var result = query.First();
            result.token = null;

            context.SaveChanges();

            return "done";
        }

        // CHUA KHIONG YANG END


        //JOEL START

        //CollectionList - Outputs weekly collection list - Web Clerk
        public List<WCF_CollectionItem> getCollectionList(string token)
        {
            if (AuthenticateToken(token))
            {
                List<WCF_CollectionItem> wcfList = new List<WCF_CollectionItem>();

                var result = BusinessLogic.GetCollectionList();

                foreach (var i in result)
                {
                    wcfList.Add(new WCF_CollectionItem(i.item_number.Trim(), i.description.Trim(), (int)i.quantity_ordered, i.current_quantity, i.unit_of_measurement.Trim()));
                }

                return wcfList;
            }
            else return null;

        }

        //CollectionList - Takes collectionItem obj to sort & update ROD table - Web Clerk
        public void SortCollectedGoods(WCF_CollectionItem ci)
        {
            string token = ci.Token.Trim();
            if (AuthenticateToken(token))
            {
                List<CollectionListItem> allDptCollectionList = new List<CollectionListItem>();
                allDptCollectionList.Add(new CollectionListItem(ci.ItemNumber.Trim(), ci.Description.Trim(), ci.UnitOfMeasurement.Trim(), ci.QuantityOrdered, ci.CurrentInventoryQty, ci.CollectedQty));

                BusinessLogic.SortCollectedGoods(allDptCollectionList);
            }

        }

        //CollectionList - Takes collectionItem obj with qty to reduce from inventory - Web Clerk
        public void DeductFromInventory(WCF_CollectionItem ci)
        {
            string token = ci.Token.Trim();
            if (AuthenticateToken(token))
            {
                List<CollectionListItem> allDptCollectionList = new List<CollectionListItem>();
                allDptCollectionList.Add(new CollectionListItem(ci.ItemNumber.Trim(), ci.Description.Trim(), ci.UnitOfMeasurement.Trim(), ci.QuantityOrdered, ci.CurrentInventoryQty, ci.CollectedQty));

                BusinessLogic.DeductFromInventory(allDptCollectionList);
            }
        }



        //Disbursement Sorting - displays list of departments that need collection - Web Clerk
        public List<WCF_DepartmentList> DisplayListofDepartmentsForCollection(string token)
        {
            if (AuthenticateToken(token))
            {
                List<WCF_DepartmentList> wcfList = new List<WCF_DepartmentList>();
                var result = BusinessLogic.DisplayListofDepartmentsForCollection();

                foreach (var i in result)
                {
                    wcfList.Add(new WCF_DepartmentList(i.ToString().Trim()));
                }
                return wcfList;
            }
            return null;
        }

        //Disbursement Sorting - input DptName, get DptId, to be used with GetSortingListByDepartment(dpt_Id);  - Web Clerk
        public string GetDptIdFromDptName(string dptName, string token)
        {
            if (AuthenticateToken(token))
            {
                string dptID;
                return dptID = BusinessLogic.GetDptIdFromDptName(dptName.Trim()).Trim();
            }
            return null;

        }

        //Disbursement Sorting - input DptId, get disbursement list; - Web Clerk 
        public List<WCF_SortingItem> GetSortingListByDepartment(string dptName, string token)
        {
            if (AuthenticateToken(token))
            {
                List<WCF_SortingItem> wcfList = new List<WCF_SortingItem>();
                var result = BusinessLogic.GetSortingListByDepartment(dptName);

                foreach (var i in result)
                {
                    wcfList.Add(new WCF_SortingItem(i.item_number.Trim(), i.description.Trim(), (int)i.required_qty, (int)i.supply_qty, (int)i.item_pending_quantity));
                }

                return wcfList;
            }
            return null;


        }

        //Disbursement Sorting - input DptId, get place id, to use in updating collection_detail table - Web Clerk
        public int GetPlaceIdFromDptId(string dptId, string token)
        {
            if (AuthenticateToken(token))
            {
                int placeId;
                return placeId = BusinessLogic.GetPlaceIdFromDptId(dptId);
            }
            return 0;

        }

        //Disbursement Sorting - after ready for collection, input place id + collectionDate + dptID, insert row to collection_detail table - Web Clerk
        public void InsertCollectionDetailsRow(WCF_CollectionDetail cd)
        {
            string token = cd.Token.Trim();
            if (AuthenticateToken(token))
            {
                BusinessLogic.InsertCollectionDetailsRow(cd.PlaceId, DateTime.Parse(cd.CollectionDate), cd.DepartmentId);
            }
        }

        //Disbursement Sorting - after ready for collection, input dptId insert to disbursementlist table  - Web Clerk
        public void InsertDisbursementListROId(string dptId, string token)
        {
            if (AuthenticateToken(token))
            {
                BusinessLogic.InsertDisbursementListROId(dptId);
            }
        }

        //Disbursement Sorting - after ready for collection, system need to send email. Method gets dpt rep email - Web Clerk
        public String GetDptRepEmailAddFromDptID(string dptId, string token)
        {
            if (AuthenticateToken(token))
            {
                return BusinessLogic.GetDptRepEmailAddFromDptID(dptId);
            }
            return null;
        }


        //ViewRO - input ROID, Get RO Details - Web Clerk
        public List<WCF_CollectionItem> GetRODetailsByROId(string roId)
        {
            List<WCF_CollectionItem> wcfList = new List<WCF_CollectionItem>();

            var result = BusinessLogic.GetRODetailsByROId(roId);
            foreach (var i in result)
            {
                wcfList.Add(new WCF_CollectionItem(i.requisition_id.Trim(), i.item_number.Trim(), i.description.Trim(), i.unit_of_measurement.Trim(), (int)i.item_requisition_quantity, (int)i.current_quantity, (int)i.item_pending_quantity));
            }
            return wcfList;
        }


        //ViewRO - after ready for collection, input placeId + collectionDate + dptID + ROID, insert row to collection_detail table - Web Clerk
        public void SpecialRequestReadyUpdatesCDRDD(WCF_CollectionDetail cd)
        {
            BusinessLogic.SpecialRequestReadyUpdatesCDRDD(cd.PlaceId, DateTime.Parse(cd.CollectionDate), cd.RoId.Trim(), cd.DepartmentId.Trim());
        }

        //ViewRO - input dptID, get place id - Web Clerk - USE ABOVE METHOD.
        public void ViewROSpecialRequestUpdateRODTable(WCF_CollectionItem ci)
        {
            List<CollectionListItem> clList = new List<CollectionListItem>();
            clList.Add(new CollectionListItem(ci.ItemNumber.Trim(), ci.Description.Trim(), ci.UnitOfMeasurement.Trim(), ci.QuantityOrdered, ci.CurrentInventoryQty, ci.CollectedQty));
            string roid = ci.RequisitionId.Trim();

            BusinessLogic.ViewROSpecialRequestUpdateRODTable(clList, roid);

        }

        // Reallocate - get list of dpts tt ordered the item, for reallocation - Web Clerk
        public List<WCF_SortingItem> GetReallocateList(string itemNum, string token)
        {
            if (AuthenticateToken(token))
            {
                List<WCF_SortingItem> wcfList = new List<WCF_SortingItem>();
                var result = BusinessLogic.GetReallocateList(itemNum);

                foreach (var i in result)
                {
                    wcfList.Add(new WCF_SortingItem(i.item_number.Trim(), i.description.Trim(), (int)i.item_requisition_quantity, (int)i.item_distributed_quantity, 0, i.department_id.Trim()));
                }
                return wcfList;
            }
            return null;
        }

        //Reallocate - upon reallocate, reset ROD table - Web Clerk
        public void ResetRODTable(WCF_SortingItem ci)
        {
            string token = ci.Token.Trim();
            if (AuthenticateToken(token))
            {
                BusinessLogic.ResetRODTable(ci.DepartmentID, ci.ItemNumber);
            }
        }


        //Reallocate - upon reallocate, update ROD table w/ new figures - Web Clerk
        public void UpdateRODTable(WCF_SortingItem ci)
        {
            string token = ci.Token.Trim();
            if (AuthenticateToken(token))
            {
                BusinessLogic.UpdateRODTableOnReallocate(ci.DepartmentID, ci.ItemNumber, ci.CollectedQty);
            }
        }

        //Reallocate - if excess, return to inventory - Web Clerk
        public void ReturnToInventory(string balance, string itemNum, string token)
        {
            if (AuthenticateToken(token))
            {
                BusinessLogic.ReturnToInventory(Convert.ToInt32(balance), itemNum);
            }
        }


        //JOEL END




        //Tharrani - start
        //return active inventory list
        public List<WCF_Inventory> GetActiveInventory(string token)
        {
            if (AuthenticateToken(token))
            {
                List<inventory> i = BusinessLogic.GetActiveInventory();
                List<WCF_Inventory> list = new List<WCF_Inventory>();
                foreach (inventory x in i)
                {
                    list.Add(new WCF_Inventory(x.item_number.Trim(), x.description.Trim(), x.category.Trim(), x.unit_of_measurement.Trim(), x.current_quantity.ToString(), x.reorder_level.ToString(), x.reorder_quantity.ToString(), x.item_bin.Trim(), x.item_status.Trim()));
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        //return inventory matching search criteria
        public List<WCF_Inventory> SearchInventory(string token, string search)
        {
            if (AuthenticateToken(token))
            {
                List<WCF_Inventory> list = new List<WCF_Inventory>();
                List<inventory> i = BusinessLogic.SearchActiveInventory(search);
                foreach (inventory x in i)
                {
                    list.Add(new WCF_Inventory(x.item_number.Trim(), x.description.Trim(), x.category.Trim(), x.unit_of_measurement.Trim(), x.current_quantity.ToString(), x.reorder_level.ToString(), x.reorder_quantity.ToString(), x.item_bin.Trim(), x.item_status.Trim()));
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        //return selected inventory
        public WCF_Inventory GetSelectedInventory(string token, string id)
        {
            if (AuthenticateToken(token))
            {
                inventory x = BusinessLogic.GetInventoryById(id);
                return new WCF_Inventory(x.item_number.Trim(), x.description.Trim(), x.category.Trim(), x.unit_of_measurement.Trim(), x.current_quantity.ToString(), x.reorder_level.ToString(), x.reorder_quantity.ToString(), x.item_bin.Trim(), x.item_status.Trim());
            }
            else
            {
                return null;
            }
        }

        //Add new requisition order
        public string AddNewRequest(WCF_Token token)
        {
            string x = token.gettoken.Replace(@"\", "").Trim();
            if (AuthenticateToken(x))
            {
                WCF_Employee emp = GetEmployeeByToken(x);
                int emp_id = Convert.ToInt32(emp.EmployeeId); //16;
                string Depid = emp.DepartmentId.Trim(); //ENGL;
                DateTime d = DateTime.Now.Date;
                unique_id u = BusinessLogic.getlastrequestid(Depid);
                int i = (int)u.req_id + 1;
                string id = Depid + "/" + DateTime.Now.Year.ToString() + "/" + i;
                BusinessLogic.AddNewRequisitionOrder(id, emp_id, d);
                BusinessLogic.updatelastrequestid(Depid, i);
                int head_id = Convert.ToInt32(BusinessLogic.GetDepartmenthead(Depid).head_id);
                string to = BusinessLogic.GetEmployee(head_id).email_id;
                //string to = "tharrani2192@gmail.com";
                string ename = BusinessLogic.GetEmployee(emp_id).employee_name;
                string sub = "Stationery System: New request raised for your approval";
                string body = "New Request ID" + id + "has been placed by" + ename + "for your approval";
                BusinessLogic.sendMail(to, sub, body);
                return id;
            }
            else
                return null;
        }

        //Add new requisition order detail
        public void AddNewRequestDetail(WCF_ReqCart r)
        {
            string token = r.gettoken.Replace(@"\", "").Trim();
            if (AuthenticateToken(token))
            {
                int q = r.q;
                string id = r.Id.Replace(@"\", "");
                inventory inv = BusinessLogic.GetInventoryById(r.getI.Trim()); ;
                cart c = new cart(inv, q);
                BusinessLogic.AddRequisitionOrderDetail(c, id.Trim());
            }
        }

        //return request order detail based on request id
        public WCF_Requisition_Order GetRequestOrder(string token, string id)
        {
            if (AuthenticateToken(token))
            {
                //string request = id.Substring(0, 5) + "/" + id.Substring(6, 10) + "/" + id.Substring(11);
                string requestid = id.Replace(@"\", "");
                requisition_order r = BusinessLogic.GetRequisitionOrderById(requestid.Trim());
                WCF_Requisition_Order ro = new WCF_Requisition_Order(r.requisition_id, r.employee_id, r.requisition_status, r.requisition_date, r.head_comment);
                return ro;
            }

            else
                return null;
        }

        //return request order item detail based on request id
        public List<Employee_Request_order_Detail> GetRequestDetail(string token, string id)
        {
            if (AuthenticateToken(token))
            {
                string requestid = id.Replace(@"\", "");
                List<getRequisitionOrderDetails_Result> rd = BusinessLogic.GetRequisitionorderDetail(requestid);
                List<Employee_Request_order_Detail> rod = new List<Employee_Request_order_Detail>();
                for (int i = 0; i < rd.Count; i++)
                {
                    rod.Add(new Employee_Request_order_Detail(rd[i].category.Trim(), rd[i].description.Trim(), rd[i].unit_of_measurement.Trim(), Convert.ToString(rd[i].item_requisition_quantity).Trim()));
                }
                return rod;
            }
            else
            { return null; }
        }

        //return list of collection points pending
        public List<WCF_Disbursement_List> GetDisbursement_Lists(string token)
        {
            if (AuthenticateToken(token))
            {
                List<spViewCollectionList_Result> l = BusinessLogic.ViewCollectionListNew();
                List<WCF_Disbursement_List> m = new List<WCF_Disbursement_List>();
                string pin;
                for (int i = 0; i < l.Count; i++)
                {
                    pin = Convert.ToString(BusinessLogic.GetDepartmentPin(l[i].department_name.Trim()));
                    m.Add(new WCF_Disbursement_List(l[i].collection_date.ToString("dd-MM-yyyy").Trim(), l[i].collection_place.Trim(), l[i].collection_time.ToString().Trim(), l[i].department_name.Trim(), l[i].employee_name.Trim(), Convert.ToString(l[i].collection_id).Trim(), pin.Trim()));
                }
                return m;
            }
            else { return null; }
        }

        //return item detail for selected collection point
        public List<WCF_Disbursement_Detail> GetDisbursement_Detail(string id, string token)
        {
            if (AuthenticateToken(token))
            {
                int collection_id = Convert.ToInt32(id.Trim());

                List<spAcknowledgeDistributionList_Result> list = BusinessLogic.ViewAcknowledgementList(collection_id);
                List<WCF_Disbursement_Detail> m = new List<WCF_Disbursement_Detail>();
                for (int i = 0; i < list.Count; i++)
                {
                    m.Add(new WCF_Disbursement_Detail(id.Trim(), list[i].item_number.Trim(), list[i].description.Trim(), Convert.ToString(list[i].ordered_quantity), Convert.ToString(list[i].supply_quantity), Convert.ToString(list[i].supply_quantity)));
                }
                return m;
            }
            else
            {
                return null;
            }
        }

        //update item disbursement quantity for all requisition id inside collection id
        public void AcknowledgeDisbursement_Detail(WCF_Disbursement_Detail DL)
        {
            string token = DL.Token;
            if (AuthenticateToken(token))
            {
                int collection_id = Convert.ToInt32(DL.Collection_id);
                int ActualSupplyQuantityValue = Convert.ToInt32(DL.Receive_quantity);
                int UserInput = Convert.ToInt32(DL.Altered_quantity);
                string ItemCode = DL.Item_number;
                BusinessLogic.AcknowledgeDL(collection_id, ItemCode, ActualSupplyQuantityValue, UserInput);
            }
        }

        //update collection status from pending to complete
        public void Changecollectionstatus(WCF_Disbursement_Detail DL)
        {
            string token = DL.Token;
            if (AuthenticateToken(token))
            {
                int collection_id = Convert.ToInt32(DL.Collection_id);
                BusinessLogic.updateCollectionStatus(collection_id);
            }
        }

        //return invenotry details for selected inventory
        public WCF_Inventory GetInventoryByItemNumber(string ItemNumber)
        {
            inventory inv = BusinessLogic.GetInventoryById(ItemNumber);
            return new WCF_Inventory(inv.item_number, inv.description, inv.category, inv.unit_of_measurement, inv.current_quantity.ToString(), inv.reorder_level.ToString(), inv.requisition_order_detail.ToString(), inv.item_bin, inv.item_status);
        }
        //Tharrani – End

        //Esther
        public string CreateAdjustment(String token, WCF_Adjustment adj)
        {
            if (AuthenticateToken(token))
            {

                String now = DateTime.Now.ToString("yyyy-MM-dd");
                WCF_Employee employee = GetEmployeeByToken(token);
                adjustment a = new adjustment()
                {
                    adjustment_date = DateTime.ParseExact(now, "yyyy-MM-dd", null),
                    employee_id = employee.EmployeeId,
                    item_number = adj.ItemNumber.Trim(),
                    adjustment_quantity = Int32.Parse(adj.AdjustmentQty.Trim()),
                    adjustment_price = BusinessLogic.Adjprice(adj.ItemNumber) * Int32.Parse(adj.AdjustmentQty.Trim()),
                    adjustment_status = "Pending",
                    employee_remark = adj.EmployeeRemark,
                    manager_remark = null,
                };
                String result1 = BusinessLogic.CreateAdjustment(a);
                String email = BusinessLogic.SendEmailAdjustmentApproval(a);
                try
                {
                    BusinessLogic.sendMail(email, "New Adjustment Request", employee.EmployeeName + " raised new adjustment request.");
                }
                catch (Exception ex)
                {
                    return "email exception " + ex.Message;
                }
                return result1;
            }
            else
            {
                return "invalid token";
            }
        }

        public List<WCF_Inventory> GetActiveInventories(String token)
        {
            if (AuthenticateToken(token))
            {
                List<inventory> list = BusinessLogic.GetActiveInventories();
                List<WCF_Inventory> returnlist = new List<WCF_Inventory>();
                foreach (inventory a in list)
                {
                    int pqty = BusinessLogic.ReturnPendingMinusAdjustmentQty(a.item_number);
                    returnlist.Add(new WCF_Inventory(a.item_number.Trim(), a.description.Trim(), a.category.Trim(), a.unit_of_measurement.Trim(), a.current_quantity.ToString(), a.reorder_level.ToString(), a.reorder_quantity.ToString(), a.item_bin, a.item_status, pqty.ToString()));
                }
                return returnlist;
            }
            else
            {
                return null;
            }
        }

        public List<WCF_Inventory> GetInventorySearchResult(String search, String token)
        {
            if (AuthenticateToken(token))
            {
                List<inventory> list = BusinessLogic.GetActiveInventories().Where(x => x.description.ToLower().Contains(search.ToLower())).ToList();
                List<WCF_Inventory> returnlist = new List<WCF_Inventory>();
                foreach (inventory a in list)
                {
                    int pqty = BusinessLogic.ReturnPendingMinusAdjustmentQty(a.item_number);
                    returnlist.Add(new WCF_Inventory(a.item_number.Trim(), a.description.Trim(), a.category.Trim(), a.unit_of_measurement.Trim(), a.current_quantity.ToString(), a.reorder_level.ToString(), a.reorder_quantity.ToString(), a.item_bin, a.item_status, pqty.ToString()));
                }
                return returnlist;
            }
            else
            {
                return null;
            }
        }

        public WCF_Inventory GetInventoryByItemCode(String itemcode, String token)
        {
            if (AuthenticateToken(token))
            {
                inventory a = BusinessLogic.GetInventoryByItemCode(itemcode);
                int pqty = BusinessLogic.ReturnPendingMinusAdjustmentQty(itemcode);
                WCF_Inventory wcfinv = new WCF_Inventory(a.item_number.Trim(), a.description.Trim(), a.category.Trim(), a.unit_of_measurement.Trim(), a.current_quantity.ToString(), a.reorder_level.ToString(), a.reorder_quantity.ToString(), a.item_bin, a.item_status, pqty.ToString());
                return wcfinv;
            }
            else
            {
                return null;
            }
        }
        //Esther end

        //Sruthi start

			//to find the pending ros for the android

        public List<WCF_approvero> Findpendingros(string token)
        {
            if (AuthenticateToken(token))
            {
                WCF_Employee emp = GetEmployeeByToken(token);
                string dept = emp.DepartmentId;
                List<getpendingrequestsbydepartment_Result> pendingros = BusinessLogic.ViewPendingRequests(dept);
                List<WCF_approvero> list = new List<WCF_approvero>();
                foreach (getpendingrequestsbydepartment_Result ro in pendingros)
                {
                    double sum = (ro.Sum.HasValue ? ro.Sum.Value : 0);
                    list.Add(new WCF_approvero(ro.id.TrimEnd(), ro.Date.ToString("dd-MM-yyyy"), ro.Name.TrimEnd(), ro.status, sum.ToString()));
                }
                return list;
            }
            else
            {
                return null;
            }
        }

		//to find the ro details based on ro id for the android
        public WCF_rodetails Findro(string token, string id)
        {
            //WCF_Employee emp = GetEmployeeByToken(token);
            //string dept = emp.DepartmentId;
            if (AuthenticateToken(token))
            {
                getpendingrequestdetails_Result result = BusinessLogic.getdetails(id);
                double sum = result.Sum.HasValue ? result.Sum.Value : 0;
                WCF_rodetails wcfrodet = new WCF_rodetails(result.id.TrimEnd(), result.Date.ToString("dd-MM-yyyy"), result.Name.TrimEnd(), result.status, sum.ToString());
                return wcfrodet;
            }
            else
            {
                return null;
            }

        }

		//to approve ro android
        public void Approvero(WCF_approvero ro)
        {
            Double i = Convert.ToDouble(ro.sum);
            int i1 = (int)Math.Round(i);
            BusinessLogic.approvestatus(ro.requisition_id, ro.status, ro.requisition_id.Substring(0, 4), i1);
        }
		//to reject ro android
        public void rejectro(WCF_approvero ro)
        {
            BusinessLogic.rejectstatus(ro.requisition_id, ro.status);
        }
		// to get collection list- android
        public List<WCF_collectionpoint> getcollection(string token)
        {
            if (AuthenticateToken(token))
            {
                List<collection> res = BusinessLogic.GetCollection();
                List<WCF_collectionpoint> list = new List<WCF_collectionpoint>();
                foreach (collection c in res)
                {
                    string id = Convert.ToString(c.place_id);
                    list.Add(new WCF_collectionpoint(id, c.collection_place.TrimEnd()));
                }
                return list;
            }
            else
            {
                return null;
            }
        }
		// to update the collection location - android
        public void updatelocation(string token, WCF_collectionpoint cp)
        {
            if (AuthenticateToken(token))
            {
                WCF_Employee emp = GetEmployeeByToken(token);
                string dept = emp.DepartmentId;
                BusinessLogic.updatecollectionlocation(dept, Convert.ToInt32(cp.id));
            }
            else
            {

            }
        }
		// to get the history of collection of the department -android

        public List<WCF_collectionhistory> gethistory(string token)
        {
            if (AuthenticateToken(token))
            {
                WCF_Employee emp = GetEmployeeByToken(token);
                string dept = emp.DepartmentId;
                List<getcollectiondetailsbydepartment_Result> list = BusinessLogic.getdepartmentcollection(dept);
                List<WCF_collectionhistory> list1 = new List<WCF_collectionhistory>();
                foreach (getcollectiondetailsbydepartment_Result r in list)
                {
                    list1.Add(new WCF_collectionhistory(r.collection_place.TrimEnd(), r.collection_date.ToString("dd-MM-yyyy")));
                }
                return list1;
            }
            else
            {
                return null;
            }

        }

		// to get the item details of the particular ro- android
        public List<WCF_itemdetails> getitemdetails(string token, string id)
        {
            if (AuthenticateToken(token))
            {
                WCF_Employee emp = GetEmployeeByToken(token);
                List<getitemdetails_Result> list = BusinessLogic.pendinggetitemdetails(id);
                List<WCF_itemdetails> list1 = new List<WCF_itemdetails>();
                foreach (getitemdetails_Result r in list)
                {
                    list1.Add(new WCF_itemdetails(r.description.TrimEnd(), r.item_requisition_quantity.ToString()));
                }
                return list1;
            }
            else
            {
                return null;
            }

        }

		// to get the budget of the current month- both allocated and spent for a particular department - Android
        public WCF_Budget getbudget(string token)
        {
            if (AuthenticateToken(token))
            {
                WCF_Employee emp = GetEmployeeByToken(token);
                string dept = emp.DepartmentId;
                int b1 = BusinessLogic.getbudgetbydept(dept);
                int b2 = BusinessLogic.getspentbudgetbydept(dept);
                WCF_Budget x = new WCF_Budget(b1.ToString(), b2.ToString());
                return x;
            }
            else
            {
                return null;
            }

        }

        //Sruthi end
    }
}


