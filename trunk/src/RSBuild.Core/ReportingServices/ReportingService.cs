namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Web.Services;
    using System.Web.Services.Description;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;

    [XmlInclude(typeof(DataSourceDefinitionOrReference)), XmlInclude(typeof(ExpirationDefinition)), DesignerCategory("code"), DebuggerStepThrough, XmlInclude(typeof(ScheduleDefinitionOrReference)), WebServiceBinding(Name="ReportingServiceSoap", Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices"), XmlInclude(typeof(RecurrencePattern))]
    public class ReportingService : SoapHttpClientProtocol
    {
        // Methods
        public ReportingService()
        {
            base.Url = "http://localhost/ReportServer/ReportService.asmx";
        }

        public IAsyncResult BeginCancelBatch(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("CancelBatch", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginCancelJob(string JobID, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { JobID } ;
            return base.BeginInvoke("CancelJob", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginCreateBatch(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("CreateBatch", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginCreateDataDrivenSubscription(string Report, ExtensionSettings ExtensionSettings, DataRetrievalPlan DataRetrievalPlan, string Description, string EventType, string MatchData, ParameterValueOrFieldReference[] Parameters, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[7] { Report, ExtensionSettings, DataRetrievalPlan, Description, EventType, MatchData, Parameters } ;
            return base.BeginInvoke("CreateDataDrivenSubscription", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginCreateDataSource(string DataSource, string Parent, bool Overwrite, DataSourceDefinition Definition, Property[] Properties, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[5] { DataSource, Parent, Overwrite, Definition, Properties } ;
            return base.BeginInvoke("CreateDataSource", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginCreateFolder(string Folder, string Parent, Property[] Properties, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[3] { Folder, Parent, Properties } ;
            return base.BeginInvoke("CreateFolder", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginCreateLinkedReport(string Report, string Parent, string Link, Property[] Properties, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[4] { Report, Parent, Link, Properties } ;
            return base.BeginInvoke("CreateLinkedReport", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginCreateReport(string Report, string Parent, bool Overwrite, byte[] Definition, Property[] Properties, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[5] { Report, Parent, Overwrite, Definition, Properties } ;
            return base.BeginInvoke("CreateReport", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginCreateReportHistorySnapshot(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("CreateReportHistorySnapshot", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginCreateResource(string Resource, string Parent, bool Overwrite, byte[] Contents, string MimeType, Property[] Properties, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[6] { Resource, Parent, Overwrite, Contents, MimeType, Properties } ;
            return base.BeginInvoke("CreateResource", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginCreateRole(string Name, string Description, Task[] Tasks, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[3] { Name, Description, Tasks } ;
            return base.BeginInvoke("CreateRole", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginCreateSchedule(string Name, ScheduleDefinition ScheduleDefinition, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Name, ScheduleDefinition } ;
            return base.BeginInvoke("CreateSchedule", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginCreateSubscription(string Report, ExtensionSettings ExtensionSettings, string Description, string EventType, string MatchData, ParameterValue[] Parameters, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[6] { Report, ExtensionSettings, Description, EventType, MatchData, Parameters } ;
            return base.BeginInvoke("CreateSubscription", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginDeleteItem(string Item, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Item } ;
            return base.BeginInvoke("DeleteItem", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginDeleteReportHistorySnapshot(string Report, string HistoryID, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Report, HistoryID } ;
            return base.BeginInvoke("DeleteReportHistorySnapshot", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginDeleteRole(string Name, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Name } ;
            return base.BeginInvoke("DeleteRole", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginDeleteSchedule(string ScheduleID, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { ScheduleID } ;
            return base.BeginInvoke("DeleteSchedule", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginDeleteSubscription(string SubscriptionID, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { SubscriptionID } ;
            return base.BeginInvoke("DeleteSubscription", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginDisableDataSource(string DataSource, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { DataSource } ;
            return base.BeginInvoke("DisableDataSource", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginEnableDataSource(string DataSource, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { DataSource } ;
            return base.BeginInvoke("EnableDataSource", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginExecuteBatch(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("ExecuteBatch", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginFindItems(string Folder, BooleanOperatorEnum BooleanOperator, SearchCondition[] Conditions, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[3] { Folder, BooleanOperator, Conditions } ;
            return base.BeginInvoke("FindItems", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginFireEvent(string EventType, string EventData, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { EventType, EventData } ;
            return base.BeginInvoke("FireEvent", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginFlushCache(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("FlushCache", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetCacheOptions(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("GetCacheOptions", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetDataDrivenSubscriptionProperties(string DataDrivenSubscriptionID, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { DataDrivenSubscriptionID } ;
            return base.BeginInvoke("GetDataDrivenSubscriptionProperties", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetDataSourceContents(string DataSource, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { DataSource } ;
            return base.BeginInvoke("GetDataSourceContents", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetExecutionOptions(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("GetExecutionOptions", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetExtensionSettings(string Extension, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Extension } ;
            return base.BeginInvoke("GetExtensionSettings", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetItemType(string Item, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Item } ;
            return base.BeginInvoke("GetItemType", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetPermissions(string Item, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Item } ;
            return base.BeginInvoke("GetPermissions", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetPolicies(string Item, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Item } ;
            return base.BeginInvoke("GetPolicies", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetProperties(string Item, Property[] Properties, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Item, Properties } ;
            return base.BeginInvoke("GetProperties", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetRenderResource(string Format, string DeviceInfo, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Format, DeviceInfo } ;
            return base.BeginInvoke("GetRenderResource", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetReportDataSourcePrompts(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("GetReportDataSourcePrompts", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetReportDataSources(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("GetReportDataSources", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetReportDefinition(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("GetReportDefinition", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetReportHistoryLimit(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("GetReportHistoryLimit", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetReportHistoryOptions(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("GetReportHistoryOptions", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetReportLink(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("GetReportLink", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetReportParameters(string Report, string HistoryID, bool ForRendering, ParameterValue[] Values, DataSourceCredentials[] Credentials, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[5] { Report, HistoryID, ForRendering, Values, Credentials } ;
            return base.BeginInvoke("GetReportParameters", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetResourceContents(string Resource, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Resource } ;
            return base.BeginInvoke("GetResourceContents", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetRoleProperties(string Name, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Name } ;
            return base.BeginInvoke("GetRoleProperties", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetScheduleProperties(string ScheduleID, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { ScheduleID } ;
            return base.BeginInvoke("GetScheduleProperties", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetSubscriptionProperties(string SubscriptionID, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { SubscriptionID } ;
            return base.BeginInvoke("GetSubscriptionProperties", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginGetSystemPermissions(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("GetSystemPermissions", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginGetSystemPolicies(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("GetSystemPolicies", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginGetSystemProperties(Property[] Properties, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Properties } ;
            return base.BeginInvoke("GetSystemProperties", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginInheritParentSecurity(string Item, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Item } ;
            return base.BeginInvoke("InheritParentSecurity", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginListChildren(string Item, bool Recursive, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Item, Recursive } ;
            return base.BeginInvoke("ListChildren", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginListEvents(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("ListEvents", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginListExtensions(ExtensionTypeEnum ExtensionType, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { ExtensionType } ;
            return base.BeginInvoke("ListExtensions", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginListJobs(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("ListJobs", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginListLinkedReports(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("ListLinkedReports", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginListReportHistory(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("ListReportHistory", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginListReportsUsingDataSource(string DataSource, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { DataSource } ;
            return base.BeginInvoke("ListReportsUsingDataSource", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginListRoles(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("ListRoles", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginListScheduledReports(string ScheduleID, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { ScheduleID } ;
            return base.BeginInvoke("ListScheduledReports", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginListSchedules(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("ListSchedules", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginListSecureMethods(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("ListSecureMethods", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginListSubscriptions(string Report, string Owner, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Report, Owner } ;
            return base.BeginInvoke("ListSubscriptions", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginListSubscriptionsUsingDataSource(string DataSource, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { DataSource } ;
            return base.BeginInvoke("ListSubscriptionsUsingDataSource", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginListSystemRoles(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("ListSystemRoles", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginListSystemTasks(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("ListSystemTasks", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginListTasks(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("ListTasks", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginLogoff(AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("Logoff", new object[0], callback, asyncState);
        }

        public IAsyncResult BeginLogonUser(string userName, string password, string authority, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[3] { userName, password, authority } ;
            return base.BeginInvoke("LogonUser", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginMoveItem(string Item, string Target, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Item, Target } ;
            return base.BeginInvoke("MoveItem", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginPauseSchedule(string ScheduleID, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { ScheduleID } ;
            return base.BeginInvoke("PauseSchedule", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginPrepareQuery(DataSource DataSource, DataSetDefinition DataSet, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { DataSource, DataSet } ;
            return base.BeginInvoke("PrepareQuery", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginRender(string Report, string Format, string HistoryID, string DeviceInfo, ParameterValue[] Parameters, DataSourceCredentials[] Credentials, string ShowHideToggle, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[7] { Report, Format, HistoryID, DeviceInfo, Parameters, Credentials, ShowHideToggle } ;
            return base.BeginInvoke("Render", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginRenderStream(string Report, string Format, string StreamID, string HistoryID, string DeviceInfo, ParameterValue[] Parameters, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[6] { Report, Format, StreamID, HistoryID, DeviceInfo, Parameters } ;
            return base.BeginInvoke("RenderStream", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginResumeSchedule(string ScheduleID, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { ScheduleID } ;
            return base.BeginInvoke("ResumeSchedule", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetCacheOptions(string Report, bool CacheReport, ExpirationDefinition Item, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[3] { Report, CacheReport, Item } ;
            return base.BeginInvoke("SetCacheOptions", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetDataDrivenSubscriptionProperties(string DataDrivenSubscriptionID, ExtensionSettings ExtensionSettings, DataRetrievalPlan DataRetrievalPlan, string Description, string EventType, string MatchData, ParameterValueOrFieldReference[] Parameters, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[7] { DataDrivenSubscriptionID, ExtensionSettings, DataRetrievalPlan, Description, EventType, MatchData, Parameters } ;
            return base.BeginInvoke("SetDataDrivenSubscriptionProperties", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetDataSourceContents(string DataSource, DataSourceDefinition Definition, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { DataSource, Definition } ;
            return base.BeginInvoke("SetDataSourceContents", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetExecutionOptions(string Report, ExecutionSettingEnum ExecutionSetting, ScheduleDefinitionOrReference Item, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[3] { Report, ExecutionSetting, Item } ;
            return base.BeginInvoke("SetExecutionOptions", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetPolicies(string Item, Policy[] Policies, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Item, Policies } ;
            return base.BeginInvoke("SetPolicies", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetProperties(string Item, Property[] Properties, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Item, Properties } ;
            return base.BeginInvoke("SetProperties", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetReportDataSources(string Report, DataSource[] DataSources, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Report, DataSources } ;
            return base.BeginInvoke("SetReportDataSources", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetReportDefinition(string Report, byte[] Definition, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Report, Definition } ;
            return base.BeginInvoke("SetReportDefinition", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetReportHistoryLimit(string Report, bool UseSystem, int HistoryLimit, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[3] { Report, UseSystem, HistoryLimit } ;
            return base.BeginInvoke("SetReportHistoryLimit", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetReportHistoryOptions(string Report, bool EnableManualSnapshotCreation, bool KeepExecutionSnapshots, ScheduleDefinitionOrReference Item, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[4] { Report, EnableManualSnapshotCreation, KeepExecutionSnapshots, Item } ;
            return base.BeginInvoke("SetReportHistoryOptions", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetReportLink(string Report, string Link, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Report, Link } ;
            return base.BeginInvoke("SetReportLink", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetReportParameters(string Report, ReportParameter[] Parameters, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Report, Parameters } ;
            return base.BeginInvoke("SetReportParameters", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetResourceContents(string Resource, byte[] Contents, string MimeType, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[3] { Resource, Contents, MimeType } ;
            return base.BeginInvoke("SetResourceContents", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetRoleProperties(string Name, string Description, Task[] Tasks, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[3] { Name, Description, Tasks } ;
            return base.BeginInvoke("SetRoleProperties", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetScheduleProperties(string Name, string ScheduleID, ScheduleDefinition ScheduleDefinition, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[3] { Name, ScheduleID, ScheduleDefinition } ;
            return base.BeginInvoke("SetScheduleProperties", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetSubscriptionProperties(string SubscriptionID, ExtensionSettings ExtensionSettings, string Description, string EventType, string MatchData, ParameterValue[] Parameters, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[6] { SubscriptionID, ExtensionSettings, Description, EventType, MatchData, Parameters } ;
            return base.BeginInvoke("SetSubscriptionProperties", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetSystemPolicies(Policy[] Policies, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Policies } ;
            return base.BeginInvoke("SetSystemPolicies", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginSetSystemProperties(Property[] Properties, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Properties } ;
            return base.BeginInvoke("SetSystemProperties", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginUpdateReportExecutionSnapshot(string Report, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[1] { Report } ;
            return base.BeginInvoke("UpdateReportExecutionSnapshot", objArray1, callback, asyncState);
        }

        public IAsyncResult BeginValidateExtensionSettings(string Extension, ParameterValueOrFieldReference[] ParameterValues, AsyncCallback callback, object asyncState)
        {
            object[] objArray1 = new object[2] { Extension, ParameterValues } ;
            return base.BeginInvoke("ValidateExtensionSettings", objArray1, callback, asyncState);
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CancelBatch", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void CancelBatch()
        {
            base.Invoke("CancelBatch", new object[0]);
        }

        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CancelJob", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public bool CancelJob(string JobID)
        {
            object[] objArray2 = new object[1] { JobID } ;
            object[] objArray1 = base.Invoke("CancelJob", objArray2);
            return (bool) objArray1[0];
        }

        [return: XmlElement("BatchID")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CreateBatch", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string CreateBatch()
        {
            object[] objArray1 = base.Invoke("CreateBatch", new object[0]);
            return (string) objArray1[0];
        }

        [return: XmlElement("SubscriptionID")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CreateDataDrivenSubscription", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string CreateDataDrivenSubscription(string Report, ExtensionSettings ExtensionSettings, DataRetrievalPlan DataRetrievalPlan, string Description, string EventType, string MatchData, ParameterValueOrFieldReference[] Parameters)
        {
            object[] objArray2 = new object[7] { Report, ExtensionSettings, DataRetrievalPlan, Description, EventType, MatchData, Parameters } ;
            object[] objArray1 = base.Invoke("CreateDataDrivenSubscription", objArray2);
            return (string) objArray1[0];
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CreateDataSource", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void CreateDataSource(string DataSource, string Parent, bool Overwrite, DataSourceDefinition Definition, Property[] Properties)
        {
            object[] objArray1 = new object[5] { DataSource, Parent, Overwrite, Definition, Properties } ;
            base.Invoke("CreateDataSource", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CreateFolder", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public void CreateFolder(string Folder, string Parent, Property[] Properties)
        {
            object[] objArray1 = new object[3] { Folder, Parent, Properties } ;
            base.Invoke("CreateFolder", objArray1);
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CreateLinkedReport", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void CreateLinkedReport(string Report, string Parent, string Link, Property[] Properties)
        {
            object[] objArray1 = new object[4] { Report, Parent, Link, Properties } ;
            base.Invoke("CreateLinkedReport", objArray1);
        }

        [return: XmlArray("Warnings")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CreateReport", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapHeader("BatchHeaderValue")]
        public Warning[] CreateReport(string Report, string Parent, bool Overwrite, [XmlElement(DataType="base64Binary")] byte[] Definition, Property[] Properties)
        {
            object[] objArray2 = new object[5] { Report, Parent, Overwrite, Definition, Properties } ;
            object[] objArray1 = base.Invoke("CreateReport", objArray2);
            return (Warning[]) objArray1[0];
        }

        [return: XmlElement("HistoryID")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CreateReportHistorySnapshot", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public string CreateReportHistorySnapshot(string Report, out Warning[] Warnings)
        {
            object[] objArray2 = new object[1] { Report } ;
            object[] objArray1 = base.Invoke("CreateReportHistorySnapshot", objArray2);
            Warnings = (Warning[]) objArray1[1];
            return (string) objArray1[0];
        }

        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CreateResource", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue")]
        public void CreateResource(string Resource, string Parent, bool Overwrite, [XmlElement(DataType="base64Binary")] byte[] Contents, string MimeType, Property[] Properties)
        {
            object[] objArray1 = new object[6] { Resource, Parent, Overwrite, Contents, MimeType, Properties } ;
            base.Invoke("CreateResource", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CreateRole", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void CreateRole(string Name, string Description, Task[] Tasks)
        {
            object[] objArray1 = new object[3] { Name, Description, Tasks } ;
            base.Invoke("CreateRole", objArray1);
        }

        [return: XmlElement("ScheduleID")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CreateSchedule", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string CreateSchedule(string Name, ScheduleDefinition ScheduleDefinition)
        {
            object[] objArray2 = new object[2] { Name, ScheduleDefinition } ;
            object[] objArray1 = base.Invoke("CreateSchedule", objArray2);
            return (string) objArray1[0];
        }

        [return: XmlElement("SubscriptionID")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/CreateSubscription", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public string CreateSubscription(string Report, ExtensionSettings ExtensionSettings, string Description, string EventType, string MatchData, ParameterValue[] Parameters)
        {
            object[] objArray2 = new object[6] { Report, ExtensionSettings, Description, EventType, MatchData, Parameters } ;
            object[] objArray1 = base.Invoke("CreateSubscription", objArray2);
            return (string) objArray1[0];
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/DeleteItem", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapHeader("BatchHeaderValue")]
        public void DeleteItem(string Item)
        {
            object[] objArray1 = new object[1] { Item } ;
            base.Invoke("DeleteItem", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/DeleteReportHistorySnapshot", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public void DeleteReportHistorySnapshot(string Report, string HistoryID)
        {
            object[] objArray1 = new object[2] { Report, HistoryID } ;
            base.Invoke("DeleteReportHistorySnapshot", objArray1);
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/DeleteRole", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void DeleteRole(string Name)
        {
            object[] objArray1 = new object[1] { Name } ;
            base.Invoke("DeleteRole", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/DeleteSchedule", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void DeleteSchedule(string ScheduleID)
        {
            object[] objArray1 = new object[1] { ScheduleID } ;
            base.Invoke("DeleteSchedule", objArray1);
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/DeleteSubscription", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapHeader("BatchHeaderValue")]
        public void DeleteSubscription(string SubscriptionID)
        {
            object[] objArray1 = new object[1] { SubscriptionID } ;
            base.Invoke("DeleteSubscription", objArray1);
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/DisableDataSource", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapHeader("BatchHeaderValue")]
        public void DisableDataSource(string DataSource)
        {
            object[] objArray1 = new object[1] { DataSource } ;
            base.Invoke("DisableDataSource", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/EnableDataSource", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void EnableDataSource(string DataSource)
        {
            object[] objArray1 = new object[1] { DataSource } ;
            base.Invoke("EnableDataSource", objArray1);
        }

        public void EndCancelBatch(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public bool EndCancelJob(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (bool) objArray1[0];
        }

        public string EndCreateBatch(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (string) objArray1[0];
        }

        public string EndCreateDataDrivenSubscription(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (string) objArray1[0];
        }

        public void EndCreateDataSource(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndCreateFolder(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndCreateLinkedReport(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public Warning[] EndCreateReport(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Warning[]) objArray1[0];
        }

        public string EndCreateReportHistorySnapshot(IAsyncResult asyncResult, out Warning[] Warnings)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            Warnings = (Warning[]) objArray1[1];
            return (string) objArray1[0];
        }

        public void EndCreateResource(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndCreateRole(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public string EndCreateSchedule(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (string) objArray1[0];
        }

        public string EndCreateSubscription(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (string) objArray1[0];
        }

        public void EndDeleteItem(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndDeleteReportHistorySnapshot(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndDeleteRole(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndDeleteSchedule(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndDeleteSubscription(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndDisableDataSource(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndEnableDataSource(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndExecuteBatch(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public CatalogItem[] EndFindItems(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (CatalogItem[]) objArray1[0];
        }

        public void EndFireEvent(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndFlushCache(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public bool EndGetCacheOptions(IAsyncResult asyncResult, out ExpirationDefinition Item)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            Item = (ExpirationDefinition) objArray1[1];
            return (bool) objArray1[0];
        }

        public string EndGetDataDrivenSubscriptionProperties(IAsyncResult asyncResult, out ExtensionSettings ExtensionSettings, out DataRetrievalPlan DataRetrievalPlan, out string Description, out ActiveState Active, out string Status, out string EventType, out string MatchData, out ParameterValueOrFieldReference[] Parameters)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            ExtensionSettings = (ExtensionSettings) objArray1[1];
            DataRetrievalPlan = (DataRetrievalPlan) objArray1[2];
            Description = (string) objArray1[3];
            Active = (ActiveState) objArray1[4];
            Status = (string) objArray1[5];
            EventType = (string) objArray1[6];
            MatchData = (string) objArray1[7];
            Parameters = (ParameterValueOrFieldReference[]) objArray1[8];
            return (string) objArray1[0];
        }

        public DataSourceDefinition EndGetDataSourceContents(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (DataSourceDefinition) objArray1[0];
        }

        public ExecutionSettingEnum EndGetExecutionOptions(IAsyncResult asyncResult, out ScheduleDefinitionOrReference Item)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            Item = (ScheduleDefinitionOrReference) objArray1[1];
            return (ExecutionSettingEnum) objArray1[0];
        }

        public ExtensionParameter[] EndGetExtensionSettings(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (ExtensionParameter[]) objArray1[0];
        }

        public ItemTypeEnum EndGetItemType(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (ItemTypeEnum) objArray1[0];
        }

        public string[] EndGetPermissions(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (string[]) objArray1[0];
        }

        public Policy[] EndGetPolicies(IAsyncResult asyncResult, out bool InheritParent)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            InheritParent = (bool) objArray1[1];
            return (Policy[]) objArray1[0];
        }

        public Property[] EndGetProperties(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Property[]) objArray1[0];
        }

        public byte[] EndGetRenderResource(IAsyncResult asyncResult, out string MimeType)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            MimeType = (string) objArray1[1];
            return (byte[]) objArray1[0];
        }

        public DataSourcePrompt[] EndGetReportDataSourcePrompts(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (DataSourcePrompt[]) objArray1[0];
        }

        public DataSource[] EndGetReportDataSources(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (DataSource[]) objArray1[0];
        }

        public byte[] EndGetReportDefinition(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (byte[]) objArray1[0];
        }

        public int EndGetReportHistoryLimit(IAsyncResult asyncResult, out bool IsSystem, out int SystemLimit)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            IsSystem = (bool) objArray1[1];
            SystemLimit = (int) objArray1[2];
            return (int) objArray1[0];
        }

        public bool EndGetReportHistoryOptions(IAsyncResult asyncResult, out bool KeepExecutionSnapshots, out ScheduleDefinitionOrReference Item)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            KeepExecutionSnapshots = (bool) objArray1[1];
            Item = (ScheduleDefinitionOrReference) objArray1[2];
            return (bool) objArray1[0];
        }

        public string EndGetReportLink(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (string) objArray1[0];
        }

        public ReportParameter[] EndGetReportParameters(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (ReportParameter[]) objArray1[0];
        }

        public byte[] EndGetResourceContents(IAsyncResult asyncResult, out string MimeType)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            MimeType = (string) objArray1[1];
            return (byte[]) objArray1[0];
        }

        public Task[] EndGetRoleProperties(IAsyncResult asyncResult, out string Description)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            Description = (string) objArray1[1];
            return (Task[]) objArray1[0];
        }

        public Schedule EndGetScheduleProperties(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Schedule) objArray1[0];
        }

        public string EndGetSubscriptionProperties(IAsyncResult asyncResult, out ExtensionSettings ExtensionSettings, out string Description, out ActiveState Active, out string Status, out string EventType, out string MatchData, out ParameterValue[] Parameters)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            ExtensionSettings = (ExtensionSettings) objArray1[1];
            Description = (string) objArray1[2];
            Active = (ActiveState) objArray1[3];
            Status = (string) objArray1[4];
            EventType = (string) objArray1[5];
            MatchData = (string) objArray1[6];
            Parameters = (ParameterValue[]) objArray1[7];
            return (string) objArray1[0];
        }

        public string[] EndGetSystemPermissions(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (string[]) objArray1[0];
        }

        public Policy[] EndGetSystemPolicies(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Policy[]) objArray1[0];
        }

        public Property[] EndGetSystemProperties(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Property[]) objArray1[0];
        }

        public void EndInheritParentSecurity(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public CatalogItem[] EndListChildren(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (CatalogItem[]) objArray1[0];
        }

        public Event[] EndListEvents(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Event[]) objArray1[0];
        }

        public Extension[] EndListExtensions(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Extension[]) objArray1[0];
        }

        public Job[] EndListJobs(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Job[]) objArray1[0];
        }

        public CatalogItem[] EndListLinkedReports(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (CatalogItem[]) objArray1[0];
        }

        public ReportHistorySnapshot[] EndListReportHistory(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (ReportHistorySnapshot[]) objArray1[0];
        }

        public CatalogItem[] EndListReportsUsingDataSource(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (CatalogItem[]) objArray1[0];
        }

        public Role[] EndListRoles(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Role[]) objArray1[0];
        }

        public CatalogItem[] EndListScheduledReports(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (CatalogItem[]) objArray1[0];
        }

        public Schedule[] EndListSchedules(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Schedule[]) objArray1[0];
        }

        public string[] EndListSecureMethods(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (string[]) objArray1[0];
        }

        public Subscription[] EndListSubscriptions(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Subscription[]) objArray1[0];
        }

        public Subscription[] EndListSubscriptionsUsingDataSource(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Subscription[]) objArray1[0];
        }

        public Role[] EndListSystemRoles(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Role[]) objArray1[0];
        }

        public Task[] EndListSystemTasks(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Task[]) objArray1[0];
        }

        public Task[] EndListTasks(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Task[]) objArray1[0];
        }

        public void EndLogoff(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndLogonUser(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndMoveItem(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndPauseSchedule(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public DataSetDefinition EndPrepareQuery(IAsyncResult asyncResult, out bool Changed)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            Changed = (bool) objArray1[1];
            return (DataSetDefinition) objArray1[0];
        }

        public byte[] EndRender(IAsyncResult asyncResult, out string Encoding, out string MimeType, out ParameterValue[] ParametersUsed, out Warning[] Warnings, out string[] StreamIds)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            Encoding = (string) objArray1[1];
            MimeType = (string) objArray1[2];
            ParametersUsed = (ParameterValue[]) objArray1[3];
            Warnings = (Warning[]) objArray1[4];
            StreamIds = (string[]) objArray1[5];
            return (byte[]) objArray1[0];
        }

        public byte[] EndRenderStream(IAsyncResult asyncResult, out string Encoding, out string MimeType)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            Encoding = (string) objArray1[1];
            MimeType = (string) objArray1[2];
            return (byte[]) objArray1[0];
        }

        public void EndResumeSchedule(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetCacheOptions(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetDataDrivenSubscriptionProperties(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetDataSourceContents(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetExecutionOptions(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetPolicies(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetProperties(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetReportDataSources(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public Warning[] EndSetReportDefinition(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (Warning[]) objArray1[0];
        }

        public void EndSetReportHistoryLimit(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetReportHistoryOptions(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetReportLink(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetReportParameters(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetResourceContents(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetRoleProperties(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetScheduleProperties(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetSubscriptionProperties(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetSystemPolicies(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndSetSystemProperties(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndUpdateReportExecutionSnapshot(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public ExtensionParameter[] EndValidateExtensionSettings(IAsyncResult asyncResult)
        {
            object[] objArray1 = base.EndInvoke(asyncResult);
            return (ExtensionParameter[]) objArray1[0];
        }

        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ExecuteBatch", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public void ExecuteBatch()
        {
            base.Invoke("ExecuteBatch", new object[0]);
        }

        [return: XmlArray("Items")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/FindItems", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public CatalogItem[] FindItems(string Folder, BooleanOperatorEnum BooleanOperator, SearchCondition[] Conditions)
        {
            object[] objArray2 = new object[3] { Folder, BooleanOperator, Conditions } ;
            object[] objArray1 = base.Invoke("FindItems", objArray2);
            return (CatalogItem[]) objArray1[0];
        }

        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/FireEvent", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue")]
        public void FireEvent(string EventType, string EventData)
        {
            object[] objArray1 = new object[2] { EventType, EventData } ;
            base.Invoke("FireEvent", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/FlushCache", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public void FlushCache(string Report)
        {
            object[] objArray1 = new object[1] { Report } ;
            base.Invoke("FlushCache", objArray1);
        }

        [return: XmlElement("CacheReport")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetCacheOptions", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public bool GetCacheOptions(string Report, [XmlElement("ScheduleExpiration", typeof(ScheduleExpiration)), XmlElement("TimeExpiration", typeof(TimeExpiration))] out ExpirationDefinition Item)
        {
            object[] objArray2 = new object[1] { Report } ;
            object[] objArray1 = base.Invoke("GetCacheOptions", objArray2);
            Item = (ExpirationDefinition) objArray1[1];
            return (bool) objArray1[0];
        }

        [return: XmlElement("Owner")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetDataDrivenSubscriptionProperties", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string GetDataDrivenSubscriptionProperties(string DataDrivenSubscriptionID, out ExtensionSettings ExtensionSettings, out DataRetrievalPlan DataRetrievalPlan, out string Description, out ActiveState Active, out string Status, out string EventType, out string MatchData, out ParameterValueOrFieldReference[] Parameters)
        {
            object[] objArray2 = new object[1] { DataDrivenSubscriptionID } ;
            object[] objArray1 = base.Invoke("GetDataDrivenSubscriptionProperties", objArray2);
            ExtensionSettings = (ExtensionSettings) objArray1[1];
            DataRetrievalPlan = (DataRetrievalPlan) objArray1[2];
            Description = (string) objArray1[3];
            Active = (ActiveState) objArray1[4];
            Status = (string) objArray1[5];
            EventType = (string) objArray1[6];
            MatchData = (string) objArray1[7];
            Parameters = (ParameterValueOrFieldReference[]) objArray1[8];
            return (string) objArray1[0];
        }

        [return: XmlElement("Definition")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetDataSourceContents", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public DataSourceDefinition GetDataSourceContents(string DataSource)
        {
            object[] objArray2 = new object[1] { DataSource } ;
            object[] objArray1 = base.Invoke("GetDataSourceContents", objArray2);
            return (DataSourceDefinition) objArray1[0];
        }

        [return: XmlElement("ExecutionSetting")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetExecutionOptions", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public ExecutionSettingEnum GetExecutionOptions(string Report, [XmlElement("ScheduleDefinition", typeof(ScheduleDefinition)), XmlElement("ScheduleReference", typeof(ScheduleReference)), XmlElement("NoSchedule", typeof(NoSchedule))] out ScheduleDefinitionOrReference Item)
        {
            object[] objArray2 = new object[1] { Report } ;
            object[] objArray1 = base.Invoke("GetExecutionOptions", objArray2);
            Item = (ScheduleDefinitionOrReference) objArray1[1];
            return (ExecutionSettingEnum) objArray1[0];
        }

        [return: XmlArray("ExtensionParameters")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetExtensionSettings", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public ExtensionParameter[] GetExtensionSettings(string Extension)
        {
            object[] objArray2 = new object[1] { Extension } ;
            object[] objArray1 = base.Invoke("GetExtensionSettings", objArray2);
            return (ExtensionParameter[]) objArray1[0];
        }

        [return: XmlElement("Type")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetItemType", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public ItemTypeEnum GetItemType(string Item)
        {
            object[] objArray2 = new object[1] { Item } ;
            object[] objArray1 = base.Invoke("GetItemType", objArray2);
            return (ItemTypeEnum) objArray1[0];
        }

        [return: XmlArrayItem("Operation"), XmlArray("Permissions")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetPermissions", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public string[] GetPermissions(string Item)
        {
            object[] objArray2 = new object[1] { Item } ;
            object[] objArray1 = base.Invoke("GetPermissions", objArray2);
            return (string[]) objArray1[0];
        }

        [return: XmlArray("Policies")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetPolicies", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public Policy[] GetPolicies(string Item, out bool InheritParent)
        {
            object[] objArray2 = new object[1] { Item } ;
            object[] objArray1 = base.Invoke("GetPolicies", objArray2);
            InheritParent = (bool) objArray1[1];
            return (Policy[]) objArray1[0];
        }

        [return: XmlArray("Values")]
        [SoapHeader("ItemNamespaceHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetProperties", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public Property[] GetProperties(string Item, Property[] Properties)
        {
            object[] objArray2 = new object[2] { Item, Properties } ;
            object[] objArray1 = base.Invoke("GetProperties", objArray2);
            return (Property[]) objArray1[0];
        }

        [return: XmlElement("Result", DataType="base64Binary")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetRenderResource", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public byte[] GetRenderResource(string Format, string DeviceInfo, out string MimeType)
        {
            object[] objArray2 = new object[2] { Format, DeviceInfo } ;
            object[] objArray1 = base.Invoke("GetRenderResource", objArray2);
            MimeType = (string) objArray1[1];
            return (byte[]) objArray1[0];
        }

        [return: XmlArray("DataSourcePrompts")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetReportDataSourcePrompts", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public DataSourcePrompt[] GetReportDataSourcePrompts(string Report)
        {
            object[] objArray2 = new object[1] { Report } ;
            object[] objArray1 = base.Invoke("GetReportDataSourcePrompts", objArray2);
            return (DataSourcePrompt[]) objArray1[0];
        }

        [return: XmlArray("DataSources")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetReportDataSources", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public DataSource[] GetReportDataSources(string Report)
        {
            object[] objArray2 = new object[1] { Report } ;
            object[] objArray1 = base.Invoke("GetReportDataSources", objArray2);
            return (DataSource[]) objArray1[0];
        }

        [return: XmlElement("Definition", DataType="base64Binary")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetReportDefinition", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public byte[] GetReportDefinition(string Report)
        {
            object[] objArray2 = new object[1] { Report } ;
            object[] objArray1 = base.Invoke("GetReportDefinition", objArray2);
            return (byte[]) objArray1[0];
        }

        [return: XmlElement("HistoryLimit")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetReportHistoryLimit", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public int GetReportHistoryLimit(string Report, out bool IsSystem, out int SystemLimit)
        {
            object[] objArray2 = new object[1] { Report } ;
            object[] objArray1 = base.Invoke("GetReportHistoryLimit", objArray2);
            IsSystem = (bool) objArray1[1];
            SystemLimit = (int) objArray1[2];
            return (int) objArray1[0];
        }

        [return: XmlElement("EnableManualSnapshotCreation")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetReportHistoryOptions", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public bool GetReportHistoryOptions(string Report, out bool KeepExecutionSnapshots, [XmlElement("ScheduleDefinition", typeof(ScheduleDefinition)), XmlElement("ScheduleReference", typeof(ScheduleReference)), XmlElement("NoSchedule", typeof(NoSchedule))] out ScheduleDefinitionOrReference Item)
        {
            object[] objArray2 = new object[1] { Report } ;
            object[] objArray1 = base.Invoke("GetReportHistoryOptions", objArray2);
            KeepExecutionSnapshots = (bool) objArray1[1];
            Item = (ScheduleDefinitionOrReference) objArray1[2];
            return (bool) objArray1[0];
        }

        [return: XmlElement("Link")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetReportLink", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public string GetReportLink(string Report)
        {
            object[] objArray2 = new object[1] { Report } ;
            object[] objArray1 = base.Invoke("GetReportLink", objArray2);
            return (string) objArray1[0];
        }

        [return: XmlArray("Parameters")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetReportParameters", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public ReportParameter[] GetReportParameters(string Report, string HistoryID, bool ForRendering, ParameterValue[] Values, DataSourceCredentials[] Credentials)
        {
            object[] objArray2 = new object[5] { Report, HistoryID, ForRendering, Values, Credentials } ;
            object[] objArray1 = base.Invoke("GetReportParameters", objArray2);
            return (ReportParameter[]) objArray1[0];
        }

        [return: XmlElement("Contents", DataType="base64Binary")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetResourceContents", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public byte[] GetResourceContents(string Resource, out string MimeType)
        {
            object[] objArray2 = new object[1] { Resource } ;
            object[] objArray1 = base.Invoke("GetResourceContents", objArray2);
            MimeType = (string) objArray1[1];
            return (byte[]) objArray1[0];
        }

        [return: XmlArray("Tasks")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetRoleProperties", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public Task[] GetRoleProperties(string Name, out string Description)
        {
            object[] objArray2 = new object[1] { Name } ;
            object[] objArray1 = base.Invoke("GetRoleProperties", objArray2);
            Description = (string) objArray1[1];
            return (Task[]) objArray1[0];
        }

        [return: XmlElement("Schedule")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetScheduleProperties", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public Schedule GetScheduleProperties(string ScheduleID)
        {
            object[] objArray2 = new object[1] { ScheduleID } ;
            object[] objArray1 = base.Invoke("GetScheduleProperties", objArray2);
            return (Schedule) objArray1[0];
        }

        [return: XmlElement("Owner")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetSubscriptionProperties", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string GetSubscriptionProperties(string SubscriptionID, out ExtensionSettings ExtensionSettings, out string Description, out ActiveState Active, out string Status, out string EventType, out string MatchData, out ParameterValue[] Parameters)
        {
            object[] objArray2 = new object[1] { SubscriptionID } ;
            object[] objArray1 = base.Invoke("GetSubscriptionProperties", objArray2);
            ExtensionSettings = (ExtensionSettings) objArray1[1];
            Description = (string) objArray1[2];
            Active = (ActiveState) objArray1[3];
            Status = (string) objArray1[4];
            EventType = (string) objArray1[5];
            MatchData = (string) objArray1[6];
            Parameters = (ParameterValue[]) objArray1[7];
            return (string) objArray1[0];
        }

        [return: XmlArrayItem("Operation"), XmlArray("Permissions")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetSystemPermissions", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public string[] GetSystemPermissions()
        {
            object[] objArray1 = base.Invoke("GetSystemPermissions", new object[0]);
            return (string[]) objArray1[0];
        }

        [return: XmlArray("Policies")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetSystemPolicies", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public Policy[] GetSystemPolicies()
        {
            object[] objArray1 = base.Invoke("GetSystemPolicies", new object[0]);
            return (Policy[]) objArray1[0];
        }

        [return: XmlArray("Values")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/GetSystemProperties", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public Property[] GetSystemProperties(Property[] Properties)
        {
            object[] objArray2 = new object[1] { Properties } ;
            object[] objArray1 = base.Invoke("GetSystemProperties", objArray2);
            return (Property[]) objArray1[0];
        }

        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/InheritParentSecurity", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue")]
        public void InheritParentSecurity(string Item)
        {
            object[] objArray1 = new object[1] { Item } ;
            base.Invoke("InheritParentSecurity", objArray1);
        }

        [return: XmlArray("CatalogItems")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListChildren", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public CatalogItem[] ListChildren(string Item, bool Recursive)
        {
            object[] objArray2 = new object[2] { Item, Recursive } ;
            object[] objArray1 = base.Invoke("ListChildren", objArray2);
            return (CatalogItem[]) objArray1[0];
        }

        [return: XmlArray("Events")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListEvents", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public Event[] ListEvents()
        {
            object[] objArray1 = base.Invoke("ListEvents", new object[0]);
            return (Event[]) objArray1[0];
        }

        [return: XmlArray("Extensions")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListExtensions", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public Extension[] ListExtensions(ExtensionTypeEnum ExtensionType)
        {
            object[] objArray2 = new object[1] { ExtensionType } ;
            object[] objArray1 = base.Invoke("ListExtensions", objArray2);
            return (Extension[]) objArray1[0];
        }

        [return: XmlArray("Jobs")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListJobs", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public Job[] ListJobs()
        {
            object[] objArray1 = base.Invoke("ListJobs", new object[0]);
            return (Job[]) objArray1[0];
        }

        [return: XmlArray("Reports")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListLinkedReports", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public CatalogItem[] ListLinkedReports(string Report)
        {
            object[] objArray2 = new object[1] { Report } ;
            object[] objArray1 = base.Invoke("ListLinkedReports", objArray2);
            return (CatalogItem[]) objArray1[0];
        }

        [return: XmlArray("ReportHistory")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListReportHistory", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public ReportHistorySnapshot[] ListReportHistory(string Report)
        {
            object[] objArray2 = new object[1] { Report } ;
            object[] objArray1 = base.Invoke("ListReportHistory", objArray2);
            return (ReportHistorySnapshot[]) objArray1[0];
        }

        [return: XmlArray("Reports")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListReportsUsingDataSource", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public CatalogItem[] ListReportsUsingDataSource(string DataSource)
        {
            object[] objArray2 = new object[1] { DataSource } ;
            object[] objArray1 = base.Invoke("ListReportsUsingDataSource", objArray2);
            return (CatalogItem[]) objArray1[0];
        }

        [return: XmlArray("Roles")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListRoles", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public Role[] ListRoles()
        {
            object[] objArray1 = base.Invoke("ListRoles", new object[0]);
            return (Role[]) objArray1[0];
        }

        [return: XmlArray("Reports")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListScheduledReports", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public CatalogItem[] ListScheduledReports(string ScheduleID)
        {
            object[] objArray2 = new object[1] { ScheduleID } ;
            object[] objArray1 = base.Invoke("ListScheduledReports", objArray2);
            return (CatalogItem[]) objArray1[0];
        }

        [return: XmlArray("Schedules")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListSchedules", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public Schedule[] ListSchedules()
        {
            object[] objArray1 = base.Invoke("ListSchedules", new object[0]);
            return (Schedule[]) objArray1[0];
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListSecureMethods", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public string[] ListSecureMethods()
        {
            object[] objArray1 = base.Invoke("ListSecureMethods", new object[0]);
            return (string[]) objArray1[0];
        }

        [return: XmlArray("SubscriptionItems")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListSubscriptions", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public Subscription[] ListSubscriptions(string Report, string Owner)
        {
            object[] objArray2 = new object[2] { Report, Owner } ;
            object[] objArray1 = base.Invoke("ListSubscriptions", objArray2);
            return (Subscription[]) objArray1[0];
        }

        [return: XmlArray("SubscriptionItems")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListSubscriptionsUsingDataSource", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public Subscription[] ListSubscriptionsUsingDataSource(string DataSource)
        {
            object[] objArray2 = new object[1] { DataSource } ;
            object[] objArray1 = base.Invoke("ListSubscriptionsUsingDataSource", objArray2);
            return (Subscription[]) objArray1[0];
        }

        [return: XmlArray("Roles")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListSystemRoles", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public Role[] ListSystemRoles()
        {
            object[] objArray1 = base.Invoke("ListSystemRoles", new object[0]);
            return (Role[]) objArray1[0];
        }

        [return: XmlArray("Tasks")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListSystemTasks", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public Task[] ListSystemTasks()
        {
            object[] objArray1 = base.Invoke("ListSystemTasks", new object[0]);
            return (Task[]) objArray1[0];
        }

        [return: XmlArray("Tasks")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ListTasks", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public Task[] ListTasks()
        {
            object[] objArray1 = base.Invoke("ListTasks", new object[0]);
            return (Task[]) objArray1[0];
        }

        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/Logoff", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public void Logoff()
        {
            base.Invoke("Logoff", new object[0]);
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/LogonUser", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void LogonUser(string userName, string password, string authority)
        {
            object[] objArray1 = new object[3] { userName, password, authority } ;
            base.Invoke("LogonUser", objArray1);
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/MoveItem", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void MoveItem(string Item, string Target)
        {
            object[] objArray1 = new object[2] { Item, Target } ;
            base.Invoke("MoveItem", objArray1);
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/PauseSchedule", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void PauseSchedule(string ScheduleID)
        {
            object[] objArray1 = new object[1] { ScheduleID } ;
            base.Invoke("PauseSchedule", objArray1);
        }

        [return: XmlElement("DataSettings")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/PrepareQuery", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public DataSetDefinition PrepareQuery(DataSource DataSource, DataSetDefinition DataSet, out bool Changed)
        {
            object[] objArray2 = new object[2] { DataSource, DataSet } ;
            object[] objArray1 = base.Invoke("PrepareQuery", objArray2);
            Changed = (bool) objArray1[1];
            return (DataSetDefinition) objArray1[0];
        }

        [return: XmlElement("Result", DataType="base64Binary")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapHeader("SessionHeaderValue", Direction=SoapHeaderDirection.InOut), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/Render", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public byte[] Render(string Report, string Format, string HistoryID, string DeviceInfo, ParameterValue[] Parameters, DataSourceCredentials[] Credentials, string ShowHideToggle, out string Encoding, out string MimeType, out ParameterValue[] ParametersUsed, out Warning[] Warnings, out string[] StreamIds)
        {
            object[] objArray2 = new object[7] { Report, Format, HistoryID, DeviceInfo, Parameters, Credentials, ShowHideToggle } ;
            object[] objArray1 = base.Invoke("Render", objArray2);
            Encoding = (string) objArray1[1];
            MimeType = (string) objArray1[2];
            ParametersUsed = (ParameterValue[]) objArray1[3];
            Warnings = (Warning[]) objArray1[4];
            StreamIds = (string[]) objArray1[5];
            return (byte[]) objArray1[0];
        }

        [return: XmlElement("Result", DataType="base64Binary")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/RenderStream", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("SessionHeaderValue", Direction=SoapHeaderDirection.InOut)]
        public byte[] RenderStream(string Report, string Format, string StreamID, string HistoryID, string DeviceInfo, ParameterValue[] Parameters, out string Encoding, out string MimeType)
        {
            object[] objArray2 = new object[6] { Report, Format, StreamID, HistoryID, DeviceInfo, Parameters } ;
            object[] objArray1 = base.Invoke("RenderStream", objArray2);
            Encoding = (string) objArray1[1];
            MimeType = (string) objArray1[2];
            return (byte[]) objArray1[0];
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ResumeSchedule", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void ResumeSchedule(string ScheduleID)
        {
            object[] objArray1 = new object[1] { ScheduleID } ;
            base.Invoke("ResumeSchedule", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetCacheOptions", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void SetCacheOptions(string Report, bool CacheReport, [XmlElement("TimeExpiration", typeof(TimeExpiration)), XmlElement("ScheduleExpiration", typeof(ScheduleExpiration))] ExpirationDefinition Item)
        {
            object[] objArray1 = new object[3] { Report, CacheReport, Item } ;
            base.Invoke("SetCacheOptions", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetDataDrivenSubscriptionProperties", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public void SetDataDrivenSubscriptionProperties(string DataDrivenSubscriptionID, ExtensionSettings ExtensionSettings, DataRetrievalPlan DataRetrievalPlan, string Description, string EventType, string MatchData, ParameterValueOrFieldReference[] Parameters)
        {
            object[] objArray1 = new object[7] { DataDrivenSubscriptionID, ExtensionSettings, DataRetrievalPlan, Description, EventType, MatchData, Parameters } ;
            base.Invoke("SetDataDrivenSubscriptionProperties", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetDataSourceContents", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void SetDataSourceContents(string DataSource, DataSourceDefinition Definition)
        {
            object[] objArray1 = new object[2] { DataSource, Definition } ;
            base.Invoke("SetDataSourceContents", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetExecutionOptions", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void SetExecutionOptions(string Report, ExecutionSettingEnum ExecutionSetting, [XmlElement("ScheduleReference", typeof(ScheduleReference)), XmlElement("NoSchedule", typeof(NoSchedule)), XmlElement("ScheduleDefinition", typeof(ScheduleDefinition))] ScheduleDefinitionOrReference Item)
        {
            object[] objArray1 = new object[3] { Report, ExecutionSetting, Item } ;
            base.Invoke("SetExecutionOptions", objArray1);
        }

        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetPolicies", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public void SetPolicies(string Item, Policy[] Policies)
        {
            object[] objArray1 = new object[2] { Item, Policies } ;
            base.Invoke("SetPolicies", objArray1);
        }

        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetProperties", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue")]
        public void SetProperties(string Item, Property[] Properties)
        {
            object[] objArray1 = new object[2] { Item, Properties } ;
            base.Invoke("SetProperties", objArray1);
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetReportDataSources", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void SetReportDataSources(string Report, DataSource[] DataSources)
        {
            object[] objArray1 = new object[2] { Report, DataSources } ;
            base.Invoke("SetReportDataSources", objArray1);
        }

        [return: XmlArray("Warnings")]
        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetReportDefinition", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public Warning[] SetReportDefinition(string Report, [XmlElement(DataType="base64Binary")] byte[] Definition)
        {
            object[] objArray2 = new object[2] { Report, Definition } ;
            object[] objArray1 = base.Invoke("SetReportDefinition", objArray2);
            return (Warning[]) objArray1[0];
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetReportHistoryLimit", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void SetReportHistoryLimit(string Report, bool UseSystem, int HistoryLimit)
        {
            object[] objArray1 = new object[3] { Report, UseSystem, HistoryLimit } ;
            base.Invoke("SetReportHistoryLimit", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetReportHistoryOptions", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void SetReportHistoryOptions(string Report, bool EnableManualSnapshotCreation, bool KeepExecutionSnapshots, [XmlElement("ScheduleDefinition", typeof(ScheduleDefinition)), XmlElement("ScheduleReference", typeof(ScheduleReference)), XmlElement("NoSchedule", typeof(NoSchedule))] ScheduleDefinitionOrReference Item)
        {
            object[] objArray1 = new object[4] { Report, EnableManualSnapshotCreation, KeepExecutionSnapshots, Item } ;
            base.Invoke("SetReportHistoryOptions", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetReportLink", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void SetReportLink(string Report, string Link)
        {
            object[] objArray1 = new object[2] { Report, Link } ;
            base.Invoke("SetReportLink", objArray1);
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetReportParameters", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void SetReportParameters(string Report, ReportParameter[] Parameters)
        {
            object[] objArray1 = new object[2] { Report, Parameters } ;
            base.Invoke("SetReportParameters", objArray1);
        }

        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetResourceContents", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public void SetResourceContents(string Resource, [XmlElement(DataType="base64Binary")] byte[] Contents, string MimeType)
        {
            object[] objArray1 = new object[3] { Resource, Contents, MimeType } ;
            base.Invoke("SetResourceContents", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetRoleProperties", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void SetRoleProperties(string Name, string Description, Task[] Tasks)
        {
            object[] objArray1 = new object[3] { Name, Description, Tasks } ;
            base.Invoke("SetRoleProperties", objArray1);
        }

        [SoapHeader("BatchHeaderValue"), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetScheduleProperties", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public void SetScheduleProperties(string Name, string ScheduleID, ScheduleDefinition ScheduleDefinition)
        {
            object[] objArray1 = new object[3] { Name, ScheduleID, ScheduleDefinition } ;
            base.Invoke("SetScheduleProperties", objArray1);
        }

        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetSubscriptionProperties", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("BatchHeaderValue")]
        public void SetSubscriptionProperties(string SubscriptionID, ExtensionSettings ExtensionSettings, string Description, string EventType, string MatchData, ParameterValue[] Parameters)
        {
            object[] objArray1 = new object[6] { SubscriptionID, ExtensionSettings, Description, EventType, MatchData, Parameters } ;
            base.Invoke("SetSubscriptionProperties", objArray1);
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetSystemPolicies", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapHeader("BatchHeaderValue")]
        public void SetSystemPolicies(Policy[] Policies)
        {
            object[] objArray1 = new object[1] { Policies } ;
            base.Invoke("SetSystemPolicies", objArray1);
        }

        [SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/SetSystemProperties", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped), SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out)]
        public void SetSystemProperties(Property[] Properties)
        {
            object[] objArray1 = new object[1] { Properties } ;
            base.Invoke("SetSystemProperties", objArray1);
        }

        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapHeader("BatchHeaderValue"), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/UpdateReportExecutionSnapshot", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public void UpdateReportExecutionSnapshot(string Report)
        {
            object[] objArray1 = new object[1] { Report } ;
            base.Invoke("UpdateReportExecutionSnapshot", objArray1);
        }

        [return: XmlArray("ParameterErrors")]
        [SoapHeader("ServerInfoHeaderValue", Direction=SoapHeaderDirection.Out), SoapDocumentMethod("http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices/ValidateExtensionSettings", RequestNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", ResponseNamespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public ExtensionParameter[] ValidateExtensionSettings(string Extension, ParameterValueOrFieldReference[] ParameterValues)
        {
            object[] objArray2 = new object[2] { Extension, ParameterValues } ;
            object[] objArray1 = base.Invoke("ValidateExtensionSettings", objArray2);
            return (ExtensionParameter[]) objArray1[0];
        }


        // Fields
        public BatchHeader BatchHeaderValue;
        public ItemNamespaceHeader ItemNamespaceHeaderValue;
        public ServerInfoHeader ServerInfoHeaderValue;
        public SessionHeader SessionHeaderValue;
    }
}

