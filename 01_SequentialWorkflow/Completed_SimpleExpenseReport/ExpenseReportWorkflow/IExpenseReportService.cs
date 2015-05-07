using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.Activities;

namespace ExpenseReportWorkflow
{
    [ExternalDataExchange]
    public interface IExpenseReportService
    {
        void GetLeadApproval ( string message );
        void GetManagerApproval ( string message );
        event EventHandler<ExternalDataEventArgs> ExpenseReportApproved;
        event EventHandler<ExternalDataEventArgs> ExpenseReportRejected;
    }
}
