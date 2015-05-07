using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.Activities;

namespace StateMachineWorkflow
{
    [ExternalDataExchange]
    public interface IOrderingService
    {
        void ItemStatusUpdate ( Guid orderId, string newStatus );
        event EventHandler<NewOrderEventArgs> NewOrder;
    }
}
