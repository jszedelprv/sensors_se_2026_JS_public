using System.Collections.Generic;
using MyKai.Manager;
using MyKai.Communicator;
using MyKai.Gesture;
using MyKai.Data;

namespace MyKai.General
{

    // Holds names of classes allowed to be created by MyKaiFactory
    public static class MyKaiClassRegistry
    {
        static List<string> registeredClasses = new List<string>
        {
            // MyKai classes registered here by default
            typeof(DefKaiManager).Name,
            typeof(KaiRichTextEventLogger).Name,
            typeof(FormKaiCommunicator).Name,
            typeof(Gesture2DCapture).Name,
            typeof(Gesture2DCursor).Name,
            typeof(Gesture2DCursorData).Name,
            typeof(Gesture2DIsStableChecker).Name,
            typeof(Gesture2DCursorStateMachine).Name,
            typeof(Gesture2DCursorViewWF).Name,
            typeof(GestureViewPanelHostedControl).Name,
            typeof(KaiControlNotifier).Name,
            typeof(KaiDataWorkspace).Name,
            typeof(KaiSDKWatchdog).Name
        };

        // Use AddCalss<T>() to register any other class
        public static void AddClass<T>()
        {
            registeredClasses.Add(typeof(T).Name);
        }

        public static bool IsClassRegistered<T>()
        {
            return registeredClasses.Contains(typeof(T).Name);
        }
    }
}
