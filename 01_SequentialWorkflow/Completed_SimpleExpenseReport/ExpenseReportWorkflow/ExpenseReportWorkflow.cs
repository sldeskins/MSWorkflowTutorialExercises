using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace ExpenseReportWorkflow
{
    public sealed partial class ExpenseReportWorkflow : SequentialWorkflowActivity
    {
        private int reportAmount = 0;
        public int Amount
        {
            set
            {
                this.reportAmount = value;
            }
        }

        private string reportResult = "";
        public string Result
        {
            get
            {
                return this.reportResult;
            }
        }
        //
        private IfElseActivity evaluateExpenseReportAmount;
        private IfElseBranchActivity ifNeedsLeadApproval;
        private IfElseBranchActivity elseNeedsManagerApproval;
        private CallExternalMethodActivity invokeGetLeadApproval;
        private CallExternalMethodActivity invokeGetManagerApproval;


        public ExpenseReportWorkflow ()
        {
            InitializeComponent();
        }
       
    }

}
