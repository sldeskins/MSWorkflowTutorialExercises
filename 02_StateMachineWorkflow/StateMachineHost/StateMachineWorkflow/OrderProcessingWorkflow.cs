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

namespace ExampleStateMachine//StateMachineWorkflow
{
    public sealed partial class OrderProcessingWorkflow : StateMachineWorkflowActivity
    {


        //
        public NewOrderEventArgs receivedOrderDetails = null;

        // OrderProcessingStateActivity Activities
        public Guid orderId;
        public Guid Id
        {
            get
            {
                return this.orderId;
            }
        }

        private string orderItem;
        public string Item
        {
            get
            {
                return this.orderItem;
            }
        }

        private Int32 orderQuantity;


        public string orderItemStatus;
        public string ItemStatus
        {
            get
            {
                return this.orderItemStatus;
            }
        }


        public OrderProcessingWorkflow ()
        {
            InitializeComponent();
        }

        private void OrderReceived ( object sender, EventArgs e )
        {
            this.orderId = receivedOrderDetails.ItemId;
            this.orderItem = receivedOrderDetails.Item;
            this.orderQuantity = receivedOrderDetails.Quantity;
            this.orderItemStatus = "Received order";
        }

        private void ProcessNewOrder ( object sender, EventArgs e )
        {
            this.orderItemStatus = "Processing order";
        }
        private void FinalizeOrder ( object sender, EventArgs e )
        {
            this.orderItemStatus = "Order processed";
        }

        public static DependencyProperty invokeProcessingNewOrderStatusUpdate_newStatus1Property = DependencyProperty.Register("invokeProcessingNewOrderStatusUpdate_newStatus1", typeof(System.String), typeof(ExampleStateMachine.OrderProcessingWorkflow));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public String invokeProcessingNewOrderStatusUpdate_newStatus1
        {
            get
            {
                return ((string)(base.GetValue(ExampleStateMachine.OrderProcessingWorkflow.invokeProcessingNewOrderStatusUpdate_newStatus1Property)));
            }
            set
            {
                base.SetValue(ExampleStateMachine.OrderProcessingWorkflow.invokeProcessingNewOrderStatusUpdate_newStatus1Property, value);
            }
        }

        public static DependencyProperty invokeOrderProcessedStatusUpdate_newStatus1Property = DependencyProperty.Register("invokeOrderProcessedStatusUpdate_newStatus1", typeof(System.String), typeof(ExampleStateMachine.OrderProcessingWorkflow));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public String invokeOrderProcessedStatusUpdate_newStatus1
        {
            get
            {
                return ((string)(base.GetValue(ExampleStateMachine.OrderProcessingWorkflow.invokeOrderProcessedStatusUpdate_newStatus1Property)));
            }
            set
            {
                base.SetValue(ExampleStateMachine.OrderProcessingWorkflow.invokeOrderProcessedStatusUpdate_newStatus1Property, value);
            }
        }

        private void newOrderExternalEvent_Invoked ( object sender, ExternalDataEventArgs e )
        {

        }




    }

}
