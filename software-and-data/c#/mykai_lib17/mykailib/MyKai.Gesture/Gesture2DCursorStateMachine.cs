using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyKai.Gesture
{
	public class Gesture2DCursorStateMachine
	{
		public enum StateType
		{
			Undefined = 0,          // initial state
			Stopped,                // state machine is stopped
			Unstable,               // the cursor moves significantly
			Stabilizing,            // the cursor is still or it moves slightly
			Stable,                 // the cursor was stable for a period of time 
			JustStabilized,         // the cursor has entered stable just one cycle erlier
			Drawing,                // a gesture is being drawn as the cursor moves
			TryingToEndDraw,		// if the cursor is stable for a period of time in this state, drawing will end
			JustEndedDrawing        // the drawing was just ended
		};

		public struct StateParamsStruct
		{
			public int MaxStabilizingCounterValue;
		}

        public StateParamsStruct StateParams = new StateParamsStruct();

		StateType state;
		public StateType State { get => state; }

		StateVariables inputVariables;

		public struct StateVariables
		{
			public bool IsStable { get; set; }
			public bool IsCaptureOn { get; set; }
		}

		public struct InternalVariablesType
		{
			public int StabilizingFrameCounter { get; set; }
		}

		InternalVariablesType internalVariables;
		public InternalVariablesType InternalVariables { get => internalVariables; }

		delegate void ActionDelegateType();
		Dictionary<StateType, ActionDelegateType> actionDictionary;

		public Gesture2DCursorStateMachine()
		{
			InitStateMachine();
			InitActionDictionary();
		}

		void InitStateMachine()
		{
			state = StateType.Undefined;
			inputVariables.IsCaptureOn = true;
			internalVariables.StabilizingFrameCounter = 0;
		}

		void InitActionDictionary()
		{
			actionDictionary = new Dictionary<StateType, ActionDelegateType>();

			actionDictionary.Add(StateType.Undefined, ActionUndefined);
			actionDictionary.Add(StateType.Stopped, ActionStopped);
			actionDictionary.Add(StateType.Unstable, ActionUnstable);
			actionDictionary.Add(StateType.Stabilizing, ActionStabilizing);
			actionDictionary.Add(StateType.JustStabilized, ActionJustEneterdStable);
			actionDictionary.Add(StateType.Stable, ActionStable);
			actionDictionary.Add(StateType.Drawing, ActionDrawing);
			actionDictionary.Add(StateType.TryingToEndDraw, ActionTryingToEndDraw);
			actionDictionary.Add(StateType.JustEndedDrawing, ActionJustEndedDrawing);
		}

		public bool IsStateUndefined() 
		{
			return State == StateType.Undefined;
		}

		public void PerformAction(StateVariables pInputVariables)
        {
			inputVariables = pInputVariables;

			foreach (var item in actionDictionary)
				if (item.Key == state)
                {
					item.Value();
					break;
				}
		}

		// The following functions perform actions relevant to the particular states of the state machine.
		// For the sake of clarity, sepatare conditional instructions were used for each branch of the state machine. 
		// Symbols used in comments:
		// {->} <State> relates to "go to <State>",
		// {..} <State> relates to "stay in <State>".

		void ActionUndefined()
        {
			// {->} Undefined
			state = StateType.Unstable;
		}

		void ActionStopped()
		{
			// {..} Stopped
			if (!inputVariables.IsCaptureOn)
				return;

			// {->} Unstable
			if (inputVariables.IsCaptureOn)
			{
				state = StateType.Unstable;
				//PlaySound(TEXT("C:\\__VWorkboth\\research\\tapce\\git\\program\\tapce_re\\sounds\\start_stop.wav"), NULL, SND_ASYNC);
				return;
			}
		}

		void ActionUnstable()
		{
			// Init
			if (internalVariables.StabilizingFrameCounter != 0)
				internalVariables.StabilizingFrameCounter = 0;

			// {..} Unstable
			if (!inputVariables.IsStable && inputVariables.IsCaptureOn)
				return;

			// {->} Stabilizing
			if (inputVariables.IsStable && inputVariables.IsCaptureOn)
			{
				//await Task.Delay(Const.timeNeededToGoToStabilizing); 
				state = StateType.Stabilizing;
				return;
			}

			// {->} Stopped
			if (!inputVariables.IsCaptureOn)
			{
				state = StateType.Stopped;
				//PlaySound(TEXT("C:\\__VWorkboth\\research\\tapce\\git\\program\\tapce_re\\sounds\\start_stop.wav"), NULL, SND_ASYNC);
				return;
			}
		}

		void ActionStabilizing()
		{
			// {..}
			if (inputVariables.IsStable  && internalVariables.StabilizingFrameCounter < StateParams.MaxStabilizingCounterValue && inputVariables.IsCaptureOn)
			{
				internalVariables.StabilizingFrameCounter++;
				//pgbStab->Position = pStCount;
				return;
			}

			// {->} JustEnteredStable
			if (internalVariables.StabilizingFrameCounter >= StateParams.MaxStabilizingCounterValue && inputVariables.IsCaptureOn)
			{
				state = StateType.JustStabilized;
				//PlaySound(TEXT("C:\\__VWorkboth\\research\\tapce\\git\\program\\tapce_re\\sounds\\stable.wav"), NULL, SND_ASYNC);
				return;
			}

			// {->} Unstable
			if (!inputVariables.IsStable && inputVariables.IsCaptureOn)
			{
				//await Task.Delay(Const.timeNeededToReturnToUnstable);
				state = StateType.Unstable;
				return;
			}

			// {->} Stopped
			if (!inputVariables.IsCaptureOn)
			{
				state = StateType.Stopped;
				//PlaySound(TEXT("C:\\__VWorkboth\\research\\tapce\\git\\program\\tapce_re\\sounds\\start_stop.wav"), NULL, SND_ASYNC);
				return;
			}
		}

		void ActionJustEneterdStable()
		{
			// {->} Stable
			if ( state == StateType.JustStabilized && inputVariables.IsStable && inputVariables.IsCaptureOn)
			{
				state = StateType.Stable;
				return;
			}

			// {->} Stopped
			if (!inputVariables.IsCaptureOn)
			{
				state = StateType.Stopped;
				// PlaySound(TEXT("C:\\__VWorkboth\\research\\tapce\\git\\program\\tapce_re\\sounds\\start_stop.wav"), NULL, SND_ASYNC);
				return;
			}
		}

		void ActionStable()
		{
			// {..} Stable
			if (inputVariables.IsStable && inputVariables.IsCaptureOn)
				return;

			// {->} Drawing
			if (!inputVariables.IsStable && inputVariables.IsCaptureOn)
			{
				//reset the gesture vector data
				// GeVector.Reset();
				state = StateType.Drawing;
				return;
			}

			// {->} Stopped
			if (!inputVariables.IsCaptureOn)
			{
				state = StateType.Stopped;
				// PlaySound(TEXT("C:\\__VWorkboth\\research\\tapce\\git\\program\\tapce_re\\sounds\\start_stop.wav"), NULL, SND_ASYNC);
				return;
			}
		}

		void ActionDrawing()
		{
			// {..} Drawing
			if (!inputVariables.IsStable)
				return;

			// {->} TryingToEndDraw
			if (inputVariables.IsStable)
			{
				state = StateType.TryingToEndDraw;
				return;
			}
		}

		void ActionTryingToEndDraw()
		{
			// {..} TryingToEndDraw
			if (inputVariables.IsStable && internalVariables.StabilizingFrameCounter > 0)
			{
				internalVariables.StabilizingFrameCounter -= 2;
				//pgbStab->Position = pStCount;
				return;
			}

            // {->} Drawing
            if (!inputVariables.IsStable && internalVariables.StabilizingFrameCounter > 0)
            {
                state = StateType.Drawing;
                //set stcount max
                internalVariables.StabilizingFrameCounter = StateParams.MaxStabilizingCounterValue;
                //pgbStab->Position = ConstantsStruct.__SM_STC_MAX;
                return;
            }

            // {->} JustEndedDrawing
            if (internalVariables.StabilizingFrameCounter <= 0) // SKL - stCount ??!
			{
				internalVariables.StabilizingFrameCounter = 0; // SKL - stCount ??!
				state = StateType.JustEndedDrawing;
				//PlaySound(TEXT("C:\\__VWorkboth\\research\\tapce\\git\\program\\tapce_re\\sounds\\end_draw.wav"), NULL, SND_ASYNC);
				//SaveGesture();
				return;
			}
		}

		void ActionJustEndedDrawing()
		{
			// {->} Unstable
			state = StateType.Unstable;
		}
	}
}
