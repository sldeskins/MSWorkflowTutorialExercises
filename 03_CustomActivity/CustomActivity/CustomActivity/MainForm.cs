using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Workflow.Runtime;

namespace WCommom //CustomActivity
{
    public partial class Mainform : Form
    {
        private WorkflowRuntime workflowRuntime;
        public Mainform ()
        {
            InitializeComponent();
            workflowRuntime = new WorkflowRuntime();
            workflowRuntime.StartRuntime();
            workflowRuntime.WorkflowCompleted +=
                new EventHandler<WorkflowCompletedEventArgs>
                (workflowRuntime_WorkflowCompleted);
        }

        private void goButton_Click ( object sender, EventArgs e )
        {
            Type type = typeof(WCommom.WebTearWorkflow);
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("Url", address.Text);
            workflowRuntime.CreateWorkflow(type, properties).Start();
        }

        private void workflowRuntime_WorkflowCompleted ( object sender,
            WorkflowCompletedEventArgs e )
        {
            // Retrieve the downloaded page data
            if (data.InvokeRequired)
                data.Invoke(new EventHandler<WorkflowCompletedEventArgs>
                    (workflowRuntime_WorkflowCompleted), sender, e);
            else
                data.Text = e.OutputParameters["Data"].ToString();
        }

    }
}
