using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.Activities;

namespace ExampleStateMachine //StateMachineWorkflow
{
    [Serializable]
    public class NewOrderEventArgs : ExternalDataEventArgs
    {
        private Guid orderItemId;

        private string orderItem;

        private Int32 orderQuantity;

        public NewOrderEventArgs ( Guid itemId, string item, Int32 quantity )
            : base(itemId)
        {
            this.orderItemId = itemId;
            this.orderItem = item;
            this.orderQuantity = quantity;
        }
        public Guid ItemId
        {
            get
            {
                return this.orderItemId;
            }
            set
            {
                this.orderItemId = value;
            }
        }

        public string Item
        {
            get
            {
                return this.orderItem;
            }
            set
            {
                this.orderItem = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this.orderQuantity;
            }
            set
            {
                this.orderQuantity = value;
            }
        }
    }

}
