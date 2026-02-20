//
// Kai basic - DefKaiManager.cs
//

using System;
using System.Windows.Forms;
using Kai.Module;
// using MyKai.Manager; // better version of the following line - can not use it because settings editor changes the namespace to the full name path.
//using kaibasic.MyKai.Manager.Properties;
using Microsoft.Win32;


//  Summary of Kai capabilities (SDK v1.0.0-beta14)
//
//  -------------------------------------------------------------------------------------------------------------------------------------------
//	| Name                  | Flag | Arg values         | Type               | Tested as available (*) | Remarks                              |
//  |-----------------------|------|--------------------|--------------------|-------------------------|--------------------------------------|
//  |+GestureData           | 1    | Gesture            | enum Gesture       | Yes                     | Capability is always on              |
//	| LinearFlickData       | 2    | Flick              | string             | No                      | No events received                   |
//  |+FingerShortcutData    | 4    | Fingers (**)       | bool[]             | Yes                     | Incorrect if the battery level < 80% |
//  | FingerPositionalData  | 8    | Fingers (***)      | int[]              | No                      | No events received                   |
//  |+PYRData               | 16   | Pitch,Yaw,Roll     | all: float         | Yes                     | Produces a large number of events    | 
//  |+QuaternionData        | 32   | w,x,y,z            | all: float         | Yes                     | Produces a large number of events    | 
//  | AccelerometerData     | 64   | Accelerometer	    | Vector3 (****)     | No                      | No events received                   |
//  | GyroscopeData         | 128  | Gyroscope          | Vector3            | No                      | No events received                   |
//  | MagnetometerData      | 256  | Magnetometer       | Vector3            | No                      | No events received                   |
//  -------------------------------------------------------------------------------------------------------------------------------------------
//
//
// (*)    - tests succeeded using v1.0.0 environment
// (**)   - also available as: bool LittleFinger, bool RingFinger, bool MiddleFinger, bool IndexFinger
// (***)  - also available as: int LittleFinger, int RingFinger, int MiddleFinger, int IndexFinger
// (****) - float x,y,z 
//


namespace MyKai.Manager
{
	// DefaultKaiManager - wraps basic KaiSDK functions using DefaultKai object 
	internal class DefKaiManager : KaiManagerBase
	{
        public DefKaiManager() : base() { }

        public override void InitializeManager(string processName, string processSecret)
		{
            ResetErrorFiltering();
			InitializeKaiSDK(processName, processSecret);
			kaiEventHandler.AssignGlobalHandlers();
			//KaiEventHandler.AssignRegularHandlers(KaiSDK.DefaultKai);
			Connect();

			isManagerActive = false;
		}

        public override void StartEventAcquisition()
		{ 
            if (!isManagerActive)
                if (!KaiSession.Query.IsAcquisitionOn())
                {
                    KaiSession.StateMachine.SwichAcquisitionOn();
                    kaiEventHandler.AssignRegularHandlers(KaiSDK.DefaultKai);
                }

            isManagerActive = true;
		}

        public override void StopEventAcquisition()
		{
            if (KaiSession.Query.IsAcquisitionOn())
            {
                KaiSession.StateMachine.SwichAcquisitionOnOff();
                kaiEventHandler.RetractRegularHandlers(KaiSDK.DefaultKai);
                isManagerActive = false;
            }
        }

        public override void SetEventDecimation(KaiEventType pKaiEventType, int pFrequency)
        {
            KaiEventRegistry.DefKaiEventParameters.KaiEventItems[pKaiEventType].EventHandlingFrequency = pFrequency;
        }

        public override string GetLastEventMessage() => communicator.LastEventText;

        public override EventArgs GetLastEventArgsIfType<T>()
        {
            if (communicator.LastEventArgs == null || !AreEventArgsOfType<T>())
                return null;

            return communicator.LastEventArgs;
        }

        internal void SendTextMessageViaCommunicator()
        {
            if (!isManagerActive)
                return;

            if (communicator == null)
                throw new Exception("DefaultKaiManager: IKaiManagerCommunicator is not set");
            else
                communicator.InformKaiEventRaised();
        }

        protected void Connect()
        {
            if (KaiSession.Query.IsSDKInitialized())
            {
                KaiSDK.Connect();
                KaiSession.StateMachine.SwitchSDKConnected();
                communicator.InformSpecialActionNeeded();
            }
        }

        protected override void SetTracedCapabilities(KaiCapabilities pNewCapabilities)
		{
			KaiSession.StateMachine.SwichCapabilitiesUnset();
			if (!KaiSession.Error)
			{
				KaiSDK.DefaultKai.UnsetCapabilities(activeCapabilities);
				activeCapabilities = pNewCapabilities;
			}

			KaiSession.StateMachine.SwitchCapabilitiesSet();
			if (!KaiSession.Error)
				if (activeCapabilities != 0)
					KaiSDK.DefaultKai.SetCapabilities(activeCapabilities);
				
			
			ResetErrorFiltering();
		}

        private bool AreEventArgsOfType<T>() => typeof(T) == communicator.LastEventArgs.GetType();

        private void ResetErrorFiltering()
        {
			KaiRegularEvent<Kai.Module.ErrorEventArgs>.ResetLastError();
        }
	}
}

