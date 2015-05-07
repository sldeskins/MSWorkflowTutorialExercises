using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Workflow.Activities;
using System.Workflow.Runtime;
using System.Workflow.ComponentModel;
using StateMachineWorkflow;


namespace StateMachineHost
{
    public partial class MainForm : Form, IOrderingService
    {
        private WorkflowRuntime workflowRuntime = null;
        private ExternalDataExchangeService exchangeService = null;


        private event EventHandler<NewOrderEventArgs> newOrderEvent;
        public event EventHandler<NewOrderEventArgs> NewOrder
        {
            add
            {
                newOrderEvent += value;
            }
            remove
            {
                newOrderEvent -= value;
            }
        }

        private Dictionary<string, List<string>> orderHistory;



        private string[] inventoryItems = {"Apple", "Orange", 
            "Banana", "Pear", "Watermelon", "Grapes" };

        public MainForm ()
        {
            InitializeComponent();

            foreach (string item in this.inventoryItems)
            {
                this.itemsList.Items.Add(item);
            }
            this.itemsList.SelectedIndex = 0;


            //
            this.orderHistory = new Dictionary<string, List<string>>();
            this.workflowRuntime = new WorkflowRuntime();
            this.exchangeService = new ExternalDataExchangeService();

            this.workflowRuntime.AddService(this.exchangeService);

            // This allows the Mainform object itself to act as a messaging service for the workflow run-time object.
            this.exchangeService.AddService(this);

            this.workflowRuntime.StartRuntime();

        }

        private delegate void ItemStatusUpdateDelegate ( Guid orderId, string newStatus );

        public void ItemStatusUpdate ( Guid orderId, string newStatus )
        {
            if (ordersIdList.InvokeRequired)
            {
                object[] args = new object[2] { orderId, newStatus };
                ItemStatusUpdateDelegate statusUpdate = new ItemStatusUpdateDelegate(ItemStatusUpdate);
                this.Invoke(statusUpdate, args);
            }
            else
            {
                if (orderHistory.ContainsKey(orderId.ToString()))
                {
                    this.orderHistory[orderId.ToString()].Add
                            (DateTime.Now + " - " + newStatus);

                    // Update order status data UI info
                    if (this.ordersIdList.Items.Contains(orderId.ToString()) == false)
                    {
                        this.ordersIdList.Items.Add(orderId.ToString());
                    }

                    this.ordersIdList.SelectedItem = orderId.ToString();
                    this.orderStatus.Text = GetOrderHistory(orderId.ToString());
                }
            }
        }

        //
        private string GetOrderHistory ( string orderId )
        {
            // Retrieve the order status
            StringBuilder itemHistory = new StringBuilder();

            foreach (string status in this.orderHistory[orderId])
            {
                itemHistory.Append(status);
                itemHistory.Append(Environment.NewLine);
            }
            return itemHistory.ToString();
        }

        private void submitButton_Click ( object sender, EventArgs e )
        {
            string item = this.itemsList.SelectedItem.ToString();
            Int32 quantity = (int)this.itemQuantity.Value;

            Type orderWorkflow = typeof(OrderProcessingWorkflow);
            WorkflowInstance workflowInstance = this.workflowRuntime.CreateWorkflow(orderWorkflow);

            this.orderHistory[workflowInstance.InstanceId.ToString()] = new List<string>();
            this.orderHistory[workflowInstance.InstanceId.ToString()].Add("Item: " + item + "; Quantity:" + quantity);

            workflowInstance.Start();
            newOrderEvent(null, new NewOrderEventArgs(workflowInstance.InstanceId, item, quantity));
        }

        private void ordersIdList_SelectedIndexChanged ( object sender, EventArgs e )
        {
            this.orderStatus.Text = GetOrderHistory(this.ordersIdList.SelectedItem.ToString());
        }

    }
}
