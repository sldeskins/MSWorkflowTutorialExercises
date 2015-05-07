using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using ExpenseReportWorkflow;

namespace SimpleExpenseReport
{
    public partial class MainForm : Form, IExpenseReportService
    {
        private WorkflowRuntime workflowRuntime = null;
        private WorkflowInstance workflowInstance = null;


        private ExternalDataExchangeService exchangeService = null;


        public MainForm ()
        {
            InitializeComponent();

            this.workflowRuntime = new WorkflowRuntime();

            this.exchangeService = new ExternalDataExchangeService();
            this.workflowRuntime.AddService(exchangeService);
            exchangeService.AddService(this);
            this.workflowRuntime.StartRuntime();

            workflowRuntime.WorkflowCompleted +=
                new EventHandler<WorkflowCompletedEventArgs>
                (workflowRuntime_WorkflowCompleted);

            // Collapse approve/reject panel
            this.Height = this.MinimumSize.Height;


        }

        public void GetLeadApproval ( string message )
        {
            if (this.approvalState.InvokeRequired)
            {
                this.approvalState.Invoke(new GetApprovalDelegate(this.GetLeadApproval), message);
            }
            else
            {
                this.approvalState.Text = message;
                this.approveButton.Enabled = true;
                this.rejectButton.Enabled = true;

                // expand the panel
                this.Height = this.MinimumSize.Height + this.panel1.Height;
                this.submitButton.Enabled = false;
            }
        }

        public void GetManagerApproval (string message)
        {
            if(approveButton.InvokeRequired)
            {
                approveButton.Invoke(new GetApprovalDelegate(this.GetManagerApproval), message);
            }
            else
            {
                this.approvalState.Text = message;
                this.approveButton.Enabled = true;
                this.rejectButton.Enabled = true;

                // expand the panel
                this.Height = this.MinimumSize.Height + this.panel1.Height;
                this.submitButton.Enabled = false;
            }

        }
        //Data exchange events
        public event EventHandler<ExternalDataEventArgs> ExpenseReportApproved
        {
            add
            {
                reportApproved += value;
            }
            remove
            {
                reportApproved -= value;
            }
        }
        public event EventHandler<ExternalDataEventArgs> ExpenseReportRejected
        {
            add
            {
                reportRejected += value;
            }
            remove
            {
                reportRejected -= value;
            }
        }

      
        //form control events
        private void submitButton_Click ( object sender, EventArgs e )
        {
            // Construct workflow parameters
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("Amount", Int32.Parse(this.amount.Text));

            // Start the workflow.
            Type type = typeof( ExpenseReportWorkflow.ExpenseReportWorkflow);
            this.workflowInstance = workflowRuntime.CreateWorkflow(type, properties);
            this.workflowInstance.Start();


        }

        private void approveButton_Click ( object sender, EventArgs e )
        {  // Raise the ExpenseReportApproved event back to the workflow
            reportApproved(null, new ExternalDataEventArgs
                (this.workflowInstance.InstanceId));
            this.Height = this.MinimumSize.Height;
            this.submitButton.Enabled = true;
        }

        private void rejectButton_Click ( object sender, EventArgs e )
        {
            // Raise the ExpenseReportRejected event back to the workflow
            reportRejected(null, new ExternalDataEventArgs
                (this.workflowInstance.InstanceId));
            this.Height = this.MinimumSize.Height;
            this.submitButton.Enabled = true;
        }

        private void amount_KeyPress ( object sender, KeyPressEventArgs e )
        {
            if (!Char.IsControl(e.KeyChar) && (!Char.IsDigit(e.KeyChar)))
                e.KeyChar = Char.MinValue;
        }

        private void amount_TextChanged ( object sender, EventArgs e )
        {
            submitButton.Enabled = amount.Text.Length > 0;
        }

        private void MainForm_Load ( object sender, EventArgs e )
        {

        }

        void workflowRuntime_WorkflowCompleted ( object sender,WorkflowCompletedEventArgs e )
        {
            if (this.result.InvokeRequired)
            {
                this.result.Invoke(new EventHandler<WorkflowCompletedEventArgs>
  (this.workflowRuntime_WorkflowCompleted), sender, e);
            }
            else
            {
                result.Text = e.OutputParameters["Result"].ToString();

                // Clear fields
                this.amount.Text = string.Empty;

                // Disable buttons
                approveButton.Enabled = false;
                rejectButton.Enabled = false;
            }
        }

        //
        private delegate void GetApprovalDelegate (string message);
        private EventHandler<ExternalDataEventArgs> reportApproved;
        private EventHandler<ExternalDataEventArgs> reportRejected;

    }
}
