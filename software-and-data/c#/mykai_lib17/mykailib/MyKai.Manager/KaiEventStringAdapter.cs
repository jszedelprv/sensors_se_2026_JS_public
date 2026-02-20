//
// Kai basic - KaiEventArgsStringAdapter.cs
//

using Kai.Module;
using Newtonsoft.Json.Linq;

namespace MyKai.Manager
{
	/// <summary>Class <c>KaiEventStringAdapter</c> converts Kai event arguments' data to string .</summary>
	internal static class KaiEventStringAdapter
	{
		const string defFloatFormat = "F4";

		// Conversion methods overloaded for each type of kai event args (regular events)
		public static string EventArgsToString(GestureEventArgs gestureArg) => $"{gestureArg.Gesture}";

		public static string EventArgsToString(LinearFlickEventArgs flickArg) => flickArg.ToString();

		public static string EventArgsToString(FingerShortcutEventArgs fingerShortcutArg)
		{
			string res;
			int l, m, r, i;

			l = fingerShortcutArg.LittleFinger ? 1 : 0;
			m = fingerShortcutArg.MiddleFinger ? 1 : 0;
			r = fingerShortcutArg.RingFinger ? 1 : 0;
			i = fingerShortcutArg.IndexFinger ? 1 : 0;


			res = "(" + i.ToString() + "," + m.ToString() + "," + r.ToString() + "," + l.ToString() + ")";

			return res;
		}

		public static string EventArgsToString(FingerPositionalEventArgs fingerShortcutArg) => 
			"(" + fingerShortcutArg.IndexFinger.ToString() + "," + fingerShortcutArg.MiddleFinger.ToString() + "," + 
			fingerShortcutArg.RingFinger.ToString() + "," + fingerShortcutArg.IndexFinger.ToString() + ")";
		
		public static string EventArgsToString(PYREventArgs pyrEventArg) =>
			"(" + pyrEventArg.Pitch.ToString(defFloatFormat) + ", " + pyrEventArg.Yaw.ToString(defFloatFormat) + ", " + 
			pyrEventArg.Roll.ToString(defFloatFormat) + ")";

		public static string EventArgsToString(QuaternionEventArgs quaterionArg) =>
			"(" + quaterionArg.Quaternion.w.ToString(defFloatFormat) + "," + quaterionArg.Quaternion.x.ToString(defFloatFormat) + "," +
			quaterionArg.Quaternion.y.ToString(defFloatFormat) + "," + quaterionArg.Quaternion.z.ToString(defFloatFormat) + ")";

		public static string EventArgsToString(AccelerometerEventArgs accelerometerArg) => Vector3ToString(accelerometerArg.Accelerometer);

		public static string EventArgsToString(GyroscopeEventArgs gyroscopeArg) => Vector3ToString(gyroscopeArg.Gyroscope);

		public static string EventArgsToString(MagnetometerEventArgs magnetometerArg) => Vector3ToString(magnetometerArg.Magnetometer);



		// Conversion method overloaded for error event
		public static string EventArgsToString(Kai.Module.ErrorEventArgs errorArg) => $"({errorArg.Error})";

		// Conversion metod overloaded for unhandled data event
		public static string EventArgsToString(JObject pData) => $"( {pData} )";		
		
		// Helper conversion for Vector3
		public static string Vector3ToString(Vector3 vector3) =>
			"(" + vector3.x.ToString(defFloatFormat) + ", " + vector3.y.ToString(defFloatFormat) + ", " + vector3.z.ToString(defFloatFormat) + ")";
	}
}
