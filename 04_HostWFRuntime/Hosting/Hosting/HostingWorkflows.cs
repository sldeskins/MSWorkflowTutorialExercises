using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.Runtime;
using System.Workflow.Activities;


namespace Hosting
{
   public sealed class HostingWorkflows : SequentialWorkflowActivity
   {
       private DelayActivity delayActivity1;
       private CodeActivity codeActivity2;
       private CodeActivity codeActivity1;

       public HostingWorkflows ()
       {
           InitializeComponent();
       }

       private void InitializeComponent ()
       {
           this.CanModifyActivities = true;

           this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
           this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
           this.codeActivity2 = new System.Workflow.Activities.CodeActivity();

           // 
           // codeActivity1
           // 
           this.codeActivity1.Name = "codeActivity1";
           this.codeActivity1.ExecuteCode +=
               new System.EventHandler(this.codeActivity1_ExecuteCode);
           // 
           // delayActivity1
           // 
           this.delayActivity1.Name = "delayActivity1";
           this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:05");
           // 
           // codeActivity2
           // 
           this.codeActivity2.Name = "codeActivity2";
           this.codeActivity2.ExecuteCode +=
               new System.EventHandler(this.codeActivity2_ExecuteCode);


           // 
           // HostingWorkflows
           // 
           this.Activities.Add(this.codeActivity1);
           this.Activities.Add(this.delayActivity1);
           this.Activities.Add(this.codeActivity2);
           this.Name = "HostingWorkflows";

           this.CanModifyActivities = false;
       }

      
       private void codeActivity1_ExecuteCode ( object sender, EventArgs e )
       {
           Console.WriteLine("In codeActivity1_ExecuteCode ");
       }
       private void codeActivity2_ExecuteCode ( object sender, EventArgs e )
       {
           Console.WriteLine("In codeActivity2_ExecuteCode ");
       }

    }
}
