// Project: MyKai
// Created Date: 2023-10-01
// Author: jsoftz
// Description: This file defines the FacadeComponentHolder class,
// which holds references to various components used in the MyKai application.
// (C) 2023-2025 jsoftz. All rights reserved.

using System.Windows.Forms;

using MyKai.Manager;
using MyKai.Communicator;
using MyKai.Gesture;
using MyKai.GUI;


namespace MyKai.Facade
{
    internal class FacadeComponentHolder
    {
        internal ContainerControl ownerControl;
        internal Panel gestureViewHostingPanel;
        internal GestureCursorParams gestureCursorParams;

        internal IKaiGestureViewableControl gestureViewControl;
        internal IKaiManager kaiManager;
        internal IKaiCommunicator kaiCommunicator;
        internal IGesture2DCapture gesture2DCapture;
        internal IKaiEventLogger kaiEventLogger;
        internal IKaiMessageLogUserControl kaiMessageLogUserControl;
        internal IKaiSDKWatchdog kaiSDKWatchdog;
    }
}
