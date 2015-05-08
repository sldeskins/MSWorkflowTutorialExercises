using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Linq;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Net;

namespace WCommom//WebTearWorkflow
{
    public partial class WebTearActivity : Activity
    {
        public delegate void PageFinishedEventHandler ( object sender, PageFinishedEventArgs e );

        private event PageFinishedEventHandler pageFinishedEvent;
        public event PageFinishedEventHandler PageFinished
        {
            add
            {
                pageFinishedEvent += value;
            }
            remove
            {
                pageFinishedEvent -= value;
            }
        }

        protected override ActivityExecutionStatus Execute ( ActivityExecutionContext executionContext )
        {
            string pageData;

            WebClient client = new WebClient();
            try
            {
                pageData = client.DownloadString(this.Url);
            }
            catch (Exception e)
            {
                pageData = e.Message;
            }

            pageFinishedEvent(null, new PageFinishedEventArgs(pageData));

            return ActivityExecutionStatus.Closed;
        }
        
        public static DependencyProperty UrlProperty =
                 DependencyProperty.RegisterAttached("Url", typeof(System.String), typeof(WebTearActivity));


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        [Description("Url to download")]
        [Category("WebTearActivity Property")]
        public string Url
        {
            get
            {
                return ((string)(base.GetValue(WebTearActivity.UrlProperty)));
            }
            set    
            {
                base.SetValue(WebTearActivity.UrlProperty, value);
            }
        }

     
    }
}
