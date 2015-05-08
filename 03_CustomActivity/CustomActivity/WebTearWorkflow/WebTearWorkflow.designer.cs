using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design; 
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace WCommom//WebTearWorkflow
{
    partial class WebTearWorkflow
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("", "")]
        private void InitializeComponent ()
        {
            this.CanModifyActivities = true;
            ActivityBind activitybind1 = new ActivityBind();
            this.webTearActivity = new WCommom.WebTearActivity();
            // 
            // webTearActivity
            // 
            this.webTearActivity.Name = "webTearActivity";
            activitybind1.Name = "WebTearWorkflow";
            activitybind1.Path = "Url";
            this.webTearActivity.PageFinished += new WCommom.WebTearActivity.PageFinishedEventHandler(this.webTearActivity_PageFinished);
            this.webTearActivity.SetBinding(WCommom.WebTearActivity.UrlProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // WebTearWorkflow
            // 
            this.Activities.Add(this.webTearActivity);
            this.Name = "WebTearWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private void webTearActivity_PageFinished ( object sender, PageFinishedEventArgs e )
        {
            this.pageData = e.Data;
        }


    }
}
