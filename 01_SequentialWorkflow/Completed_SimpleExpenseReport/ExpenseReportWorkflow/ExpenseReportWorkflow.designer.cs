using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace ExpenseReportWorkflow
{
    partial class ExpenseReportWorkflow
    {

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("", "")]
        private void InitializeComponent ()
        {
            this.Name = "Workflow1";
            this.evaluateExpenseReportAmount = new IfElseActivity();
            this.ifNeedsLeadApproval = new IfElseBranchActivity();
            this.elseNeedsManagerApproval = new IfElseBranchActivity();
            this.invokeGetLeadApproval = new CallExternalMethodActivity();
            this.invokeGetManagerApproval = new CallExternalMethodActivity();

            //
            CodeCondition ifElseLogicStatement = new CodeCondition();
            WorkflowParameterBinding workflowparameterbinding1 = new WorkflowParameterBinding();
            WorkflowParameterBinding workflowparameterbinding2 = new WorkflowParameterBinding();

            //
            this.evaluateExpenseReportAmount.Activities.Add(this.ifNeedsLeadApproval);
            this.evaluateExpenseReportAmount.Activities.Add(this.elseNeedsManagerApproval);
            this.evaluateExpenseReportAmount.Name = "evaluateExpenseReportAmount";

            //
            ifNeedsLeadApproval.Activities.Add(this.invokeGetLeadApproval);
            ifElseLogicStatement.Condition += new EventHandler<ConditionalEventArgs>(this.DeterminApprovalContact);

            ifNeedsLeadApproval.Condition = ifElseLogicStatement;
            this.ifNeedsLeadApproval.Name = "ifNeedsLeadApproval";

            //
            elseNeedsManagerApproval.Activities.Add(invokeGetManagerApproval);
            elseNeedsManagerApproval.Name = "elseNeedsManagerApproval";

            //  //
            this.CanModifyActivities = true;
              //
            this.eventDriven1 = new EventDrivenActivity();
            this.eventDriven2 = new EventDrivenActivity();
            this.listenApproveReject = new ListenActivity();
            this.approveEvent = new HandleExternalEventActivity();
            this.rejectEvent = new HandleExternalEventActivity();
        
            // /
            this.invokeGetLeadApproval.InterfaceType = typeof(IExpenseReportService);
            this.invokeGetLeadApproval.MethodName = "GetLeadApproval";
            this.invokeGetLeadApproval.Name = "invokeGetLeadApproval";
            workflowparameterbinding1.ParameterName = "message";
            workflowparameterbinding1.Value = "Lead approval needed";

            this.invokeGetLeadApproval.ParameterBindings.Add(workflowparameterbinding1);
            
             // /
            this.invokeGetManagerApproval.InterfaceType = typeof(IExpenseReportService);
            this.invokeGetManagerApproval.MethodName = "GetManagerApproval";
            this.invokeGetManagerApproval.Name = "invokeGetManagerApproval";
            workflowparameterbinding2.ParameterName = "message";
            workflowparameterbinding2.Value = "Manager approval meeded";

            this.invokeGetManagerApproval.ParameterBindings.Add(workflowparameterbinding2);

  //
            this.eventDriven1.Activities.Add(this.approveEvent);
            this.eventDriven1.Name = "eventDriven1";

            this.eventDriven2.Activities.Add(this.rejectEvent);
            this.eventDriven2.Name = "eventDriven2";

            this.listenApproveReject.Activities.Add(eventDriven1);
            this.listenApproveReject.Activities.Add(this.eventDriven2);
            this.listenApproveReject.Name = "listenApproveReject";

            //
            this.approveEvent.EventName = "ExpenseReportApproved";
            this.approveEvent.InterfaceType = typeof(IExpenseReportService);
            this.approveEvent.Name = "approveEvent";
            this.approveEvent.Invoked += new
                System.EventHandler<ExternalDataEventArgs>(this.approveEvent_Invoked);

            //
            this.rejectEvent.EventName = "ExpenseReportRejected";
            this.rejectEvent.InterfaceType = typeof(IExpenseReportService);
            this.rejectEvent.Name = "rejectEvent";
            this.rejectEvent.Invoked += new
                System.EventHandler<ExternalDataEventArgs>(this.rejectEvent_Invoked);

            //
            this.Activities.Add(this.evaluateExpenseReportAmount);
            this.Activities.Add(this.listenApproveReject);
            this.Name = "ExpenseReportWorkflow";
            this.CanModifyActivities = false;
            
        }

        private void DeterminApprovalContact ( object sender, ConditionalEventArgs e )
        {
            if (this.reportAmount < 1000)
            {
                e.Result = true;
            }
            else
            {
                e.Result = false;
            }
        }
        //
        private void approveEvent_Invoked ( Object sender, ExternalDataEventArgs e )
        {
            this.reportResult = "Report Approved";
        }
        private void rejectEvent_Invoked ( Object sender, ExternalDataEventArgs e )
        {
            this.reportResult = "Report Rejected";
        }

        private ListenActivity listenApproveReject;
        private EventDrivenActivity eventDriven1;
        private EventDrivenActivity eventDriven2;
        private HandleExternalEventActivity approveEvent;
        private HandleExternalEventActivity rejectEvent;


    }
}
