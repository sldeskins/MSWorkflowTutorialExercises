﻿using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace ExampleStateMachine//StateMachineWorkflow
{
    partial class OrderProcessingWorkflow
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
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.setStateActivityOrderCompleted = new System.Workflow.Activities.SetStateActivity();
            this.invokeOrderProcessedStatusUpdate = new System.Workflow.Activities.CallExternalMethodActivity();
            this.invokeProcessingNewOrderStatusUpdate = new System.Workflow.Activities.CallExternalMethodActivity();
            this.setStateActivityOrderProcessing = new System.Workflow.Activities.SetStateActivity();
            this.updatestatusOrderReceived = new System.Workflow.Activities.CallExternalMethodActivity();
            this.newOrderExternalEvent = new System.Workflow.Activities.HandleExternalEventActivity();
            this.initializeOrderOpenStateActivity = new System.Workflow.Activities.StateInitializationActivity();
            this.eventDriven1 = new System.Workflow.Activities.EventDrivenActivity();
            this.OrderCompletedStateActivity = new System.Workflow.Activities.StateActivity();
            this.OrderProcessingStateActivity = new System.Workflow.Activities.StateActivity();
            this.WaitingForOrderStateActivity = new System.Workflow.Activities.StateActivity();
            // 
            // setStateActivityOrderCompleted
            // 
            this.setStateActivityOrderCompleted.Name = "setStateActivityOrderCompleted";
            this.setStateActivityOrderCompleted.TargetStateName = "OrderCompletedStateActivity";
            // 
            // invokeOrderProcessedStatusUpdate
            // 
            this.invokeOrderProcessedStatusUpdate.InterfaceType = typeof(ExampleStateMachine.IOrderingService);
            this.invokeOrderProcessedStatusUpdate.MethodName = "ItemStatusUpdate";
            this.invokeOrderProcessedStatusUpdate.Name = "invokeOrderProcessedStatusUpdate";
            activitybind1.Name = "OrderProcessingWorkflow";
            activitybind1.Path = "orderId";
            workflowparameterbinding1.ParameterName = "orderId";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "OrderProcessingWorkflow";
            activitybind2.Path = "orderItemStatus";
            workflowparameterbinding2.ParameterName = "newStatus";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.invokeOrderProcessedStatusUpdate.ParameterBindings.Add(workflowparameterbinding1);
            this.invokeOrderProcessedStatusUpdate.ParameterBindings.Add(workflowparameterbinding2);
            this.invokeOrderProcessedStatusUpdate.MethodInvoking += new System.EventHandler(this.FinalizeOrder);
            // 
            // invokeProcessingNewOrderStatusUpdate
            // 
            this.invokeProcessingNewOrderStatusUpdate.InterfaceType = typeof(ExampleStateMachine.IOrderingService);
            this.invokeProcessingNewOrderStatusUpdate.MethodName = "ItemStatusUpdate";
            this.invokeProcessingNewOrderStatusUpdate.Name = "invokeProcessingNewOrderStatusUpdate";
            this.invokeProcessingNewOrderStatusUpdate.ParameterBindings.Add(workflowparameterbinding1);
            this.invokeProcessingNewOrderStatusUpdate.ParameterBindings.Add(workflowparameterbinding2);
            this.invokeProcessingNewOrderStatusUpdate.MethodInvoking += new System.EventHandler(this.ProcessNewOrder);
            // 
            // setStateActivityOrderProcessing
            // 
            this.setStateActivityOrderProcessing.Name = "setStateActivityOrderProcessing";
            this.setStateActivityOrderProcessing.TargetStateName = "OrderProcessingStateActivity";
            // 
            // updatestatusOrderReceived
            // 
            this.updatestatusOrderReceived.InterfaceType = typeof(ExampleStateMachine.IOrderingService);
            this.updatestatusOrderReceived.MethodName = "ItemStatusUpdate";
            this.updatestatusOrderReceived.Name = "updatestatusOrderReceived";
            this.updatestatusOrderReceived.ParameterBindings.Add(workflowparameterbinding1);
            this.updatestatusOrderReceived.ParameterBindings.Add(workflowparameterbinding2);
            this.updatestatusOrderReceived.MethodInvoking += new System.EventHandler(this.OrderReceived);
            // 
            // newOrderExternalEvent
            // 
            this.newOrderExternalEvent.EventName = "NewOrder";
            this.newOrderExternalEvent.InterfaceType = typeof(ExampleStateMachine.IOrderingService);
            this.newOrderExternalEvent.Name = "newOrderExternalEvent";
            activitybind3.Name = "OrderProcessingWorkflow";
            activitybind3.Path = "receivedOrderDetails";
            workflowparameterbinding3.ParameterName = "e";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.newOrderExternalEvent.ParameterBindings.Add(workflowparameterbinding3);
            this.newOrderExternalEvent.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.newOrderExternalEvent_Invoked);
            // 
            // initializeOrderOpenStateActivity
            // 
            this.initializeOrderOpenStateActivity.Activities.Add(this.invokeProcessingNewOrderStatusUpdate);
            this.initializeOrderOpenStateActivity.Activities.Add(this.invokeOrderProcessedStatusUpdate);
            this.initializeOrderOpenStateActivity.Activities.Add(this.setStateActivityOrderCompleted);
            this.initializeOrderOpenStateActivity.Name = "initializeOrderOpenStateActivity";
            // 
            // eventDriven1
            // 
            this.eventDriven1.Activities.Add(this.newOrderExternalEvent);
            this.eventDriven1.Activities.Add(this.updatestatusOrderReceived);
            this.eventDriven1.Activities.Add(this.setStateActivityOrderProcessing);
            this.eventDriven1.Name = "eventDriven1";
            // 
            // OrderCompletedStateActivity
            // 
            this.OrderCompletedStateActivity.Name = "OrderCompletedStateActivity";
            // 
            // OrderProcessingStateActivity
            // 
            this.OrderProcessingStateActivity.Activities.Add(this.initializeOrderOpenStateActivity);
            this.OrderProcessingStateActivity.Name = "OrderProcessingStateActivity";
            // 
            // WaitingForOrderStateActivity
            // 
            this.WaitingForOrderStateActivity.Activities.Add(this.eventDriven1);
            this.WaitingForOrderStateActivity.Name = "WaitingForOrderStateActivity";
            // 
            // OrderProcessingWorkflow
            // 
            this.Activities.Add(this.WaitingForOrderStateActivity);
            this.Activities.Add(this.OrderProcessingStateActivity);
            this.Activities.Add(this.OrderCompletedStateActivity);
            this.CompletedStateName = "OrderCompletedStateActivity";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "WaitingForOrderStateActivity";
            this.Name = "OrderProcessingWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private SetStateActivity setStateActivityOrderProcessing;

        private CallExternalMethodActivity updatestatusOrderReceived;

        private SetStateActivity setStateActivityOrderCompleted;

        private CallExternalMethodActivity invokeOrderProcessedStatusUpdate;

        private CallExternalMethodActivity invokeProcessingNewOrderStatusUpdate;

        private StateInitializationActivity initializeOrderOpenStateActivity;

        private StateActivity OrderCompletedStateActivity;

        private StateActivity OrderProcessingStateActivity;

        private StateActivity WaitingForOrderStateActivity;

        private HandleExternalEventActivity newOrderExternalEvent;

        private EventDrivenActivity eventDriven1;































    }
}
