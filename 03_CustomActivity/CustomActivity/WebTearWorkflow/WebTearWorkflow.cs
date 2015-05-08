using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace WCommom//WebTearWorkflow
{
    public sealed partial class WebTearWorkflow : SequentialWorkflowActivity
    {
        private string pageUrl;
        private string pageData;

        private WebTearActivity webTearActivity;


        public WebTearWorkflow ()
        {
            InitializeComponent();
        }

       

        public string Url
        {
            get
            {
                return pageUrl;
            }
            set
            {
                pageUrl = value;
            }
        }
        public string Data
        {
            get
            {
                return pageData;
            }
            set
            {
                pageData = value;
            }
        }

   
    }

}
