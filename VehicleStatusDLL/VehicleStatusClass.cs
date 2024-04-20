/* Title:           Vehicle Status Class
 * Date:            7-21-17
 * Author:          Terry Holmes */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace VehicleStatusDLL
{
    public class VehicleStatusClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        VehicleStatusDataSet aVehicleStatusDataSet;
        VehicleStatusDataSetTableAdapters.vehiclestatusTableAdapter aVehicleStatusTableAdapter;

        InsertVehicleStatusEntryTableAdapters.QueriesTableAdapter aInsertVehicleStatusTableAdapter;

        UpdateVehicleStatusEntryTableAdapters.QueriesTableAdapter aUpdateVehicleStatusTableAdapter;

        FindFleetVehicleStatusDataSet aFindFleetVehicleStatusDataSet;
        FindFleetVehicleStatusDataSetTableAdapters.FindFleetVehicleStatusTableAdapter aFindFleetVehicleStatusTableAdapter;

        FindVehicleStatusByVehicleIDDataSet aFindVehicleStatusByVehicleIDDataSet;
        FindVehicleStatusByVehicleIDDataSetTableAdapters.FindVehicleStatusByVehicleIDTableAdapter aFindVehicleStatusByVehicleIDTableAdapter;

        FindVehiclesByVehicleStatusDataSet aFindVehiclesByVehicleStatusDataSet;
        FindVehiclesByVehicleStatusDataSetTableAdapters.FindVehiclesByVehicleStatusTableAdapter aFindVehiclesByVehicleStatusTableAdpater;

        RemoveVehicleFromStatusEntryTableAdapters.QueriesTableAdapter aRemoveVehicleFromStatusEntryTableAdapter;

        public FindVehiclesByVehicleStatusDataSet FindVehiclesByVehicleStatus(string strVehicleStatus)
        {
            try
            {
                aFindVehiclesByVehicleStatusDataSet = new FindVehiclesByVehicleStatusDataSet();
                aFindVehiclesByVehicleStatusTableAdpater = new FindVehiclesByVehicleStatusDataSetTableAdapters.FindVehiclesByVehicleStatusTableAdapter();
                aFindVehiclesByVehicleStatusTableAdpater.Fill(aFindVehiclesByVehicleStatusDataSet.FindVehiclesByVehicleStatus, strVehicleStatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Status Class // Find Vehicles by Vehicle Status " + Ex.Message);
            }

            return aFindVehiclesByVehicleStatusDataSet;

        }
        public bool RemoveVehicleFromStatus(int intVehicleID)
        {
            bool blnFatalError = false;

            try
            {
                aRemoveVehicleFromStatusEntryTableAdapter = new RemoveVehicleFromStatusEntryTableAdapters.QueriesTableAdapter();
                aRemoveVehicleFromStatusEntryTableAdapter.RemoveVehicleFromStatus(intVehicleID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Status Class // Remove Vehicle From Status " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public FindVehicleStatusByVehicleIDDataSet FindVehicleStatusByVehicleID(int intVehicleID)
        {
            try
            {
                aFindVehicleStatusByVehicleIDDataSet = new FindVehicleStatusByVehicleIDDataSet();
                aFindVehicleStatusByVehicleIDTableAdapter = new FindVehicleStatusByVehicleIDDataSetTableAdapters.FindVehicleStatusByVehicleIDTableAdapter();
                aFindVehicleStatusByVehicleIDTableAdapter.Fill(aFindVehicleStatusByVehicleIDDataSet.FindVehicleStatusByVehicleID, intVehicleID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Status Class // Find Vehicle Status By Vehicle ID " + Ex.Message);
            }

            return aFindVehicleStatusByVehicleIDDataSet;
        }
        public FindFleetVehicleStatusDataSet FindFleetVehicleStatus()
        {
            try
            {
                aFindFleetVehicleStatusDataSet = new FindFleetVehicleStatusDataSet();
                aFindFleetVehicleStatusTableAdapter = new FindFleetVehicleStatusDataSetTableAdapters.FindFleetVehicleStatusTableAdapter();
                aFindFleetVehicleStatusTableAdapter.Fill(aFindFleetVehicleStatusDataSet.FindFleetVehicleStatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Status Class // Find Fleet Vehicle Status " + Ex.Message);
            }

            return aFindFleetVehicleStatusDataSet;
        }
        public bool UpdateVehicleStatus(int intVehicleID, string strVehicleStatus, DateTime datTransactionDate)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateVehicleStatusTableAdapter = new UpdateVehicleStatusEntryTableAdapters.QueriesTableAdapter();
                aUpdateVehicleStatusTableAdapter.UpdateVehicleStatus(intVehicleID, strVehicleStatus, datTransactionDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Status Class // Update Vehicle Status " + Ex.Message);
            }

            return blnFatalError;
        }
        public bool InsertVehicleStatus(int intVehicleID, string strVehicleStatus, DateTime datTransactionDate)
        {
            bool blnFatalError = false;

            try
            {
                aInsertVehicleStatusTableAdapter = new InsertVehicleStatusEntryTableAdapters.QueriesTableAdapter();
                aInsertVehicleStatusTableAdapter.InsertVehicleStatus(intVehicleID, strVehicleStatus, datTransactionDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Status Class // Insert Vehicle Status " + Ex.Message);
            }

            return blnFatalError;
        }
        public VehicleStatusDataSet GetVehicleStatusInfo()
        {
            try
            {
                aVehicleStatusDataSet = new VehicleStatusDataSet();
                aVehicleStatusTableAdapter = new VehicleStatusDataSetTableAdapters.vehiclestatusTableAdapter();
                aVehicleStatusTableAdapter.Fill(aVehicleStatusDataSet.vehiclestatus);
            }
            catch(Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Status Class // Get Vehicle Status Info " + Ex.Message);
            }

            return aVehicleStatusDataSet;
        }
        public void UpdateVehicleStatusDB(VehicleStatusDataSet aVehicleStatusDataSet)
        {
            try
            {
                aVehicleStatusTableAdapter = new VehicleStatusDataSetTableAdapters.vehiclestatusTableAdapter();
                aVehicleStatusTableAdapter.Update(aVehicleStatusDataSet.vehiclestatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Status Class // Update Vehicle Status DB " + Ex.Message);
            }
        }
    }
}
