using System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

namespace Hosting
{
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main ( string[] args )
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            workflowRuntime.StartRuntime();
            workflowRuntime.WorkflowCompleted += new
                EventHandler<WorkflowCompletedEventArgs>
                (workflowRuntime_WorkflowCompleted);

            Type type = typeof(HostingWorkflows);
            WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(type);
            workflowInstance.Start();

            waitHandle.WaitOne();
            workflowRuntime.StopRuntime();
        }
        static void workflowRuntime_WorkflowCompleted ( object sender,
    WorkflowCompletedEventArgs e )
        {
            waitHandle.Set();
        }
    }
}
