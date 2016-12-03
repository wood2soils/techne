#region usings
using System;
using System.ComponentModel.Composition;

using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
using VVVV.Utils.VColor;
using VVVV.Utils.VMath;
using VVVV.Core.Helper;

using VVVV.Core.Logging;
#endregion usings

namespace VVVV.Nodes
{
	#region PluginInfo
	[PluginInfo(Name = "LineMove", Category = "Value", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class ValueLineMoveNode : IPluginEvaluate
	{
		
		/*
		* フィールド
		*/
		Vector3D p1;
		Vector3D p2;
		Vector3D nowP1;
		Vector3D nowP2;
		float _speed;
		Vector3D normal;
		Vector3D vec;
		Tweener tween;	
		
		
		/*
		* コンストラクタ
		*/
		public ValueLineMoveNode(){
			//p1.Normalize();
			nowP1 = p1;
			nowP2 = p1;
			Vector3D dir = p1 - p2;
			
			vec = new Vector3D(0.0, _speed ,0.0);
			
			
			
			
		}
		
		#region fields & pins
		[Input("FSpeed", DefaultValue = 1.0)]
		public ISpread<float> FSpeed;

		[Input("P1")]
		public ISpread<Vector3D> P1;
		[Input("P2")]
		public ISpread<Vector3D> P2;
		
		[Output("Output")]
		public ISpread<double> FOutput;

		[Output("from")]
		public ISpread<Vector3D> FromP;
		
		[Output("to")]
		public ISpread<Vector3D> Top;
		
		
		[Import()]
		public ILogger FLogger;
		#endregion fields & pins

		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			FOutput.SliceCount = SpreadMax;
			
			nowP1 += vec;
			
			//for (int i = 0; i < SpreadMax; i++)
				//FOutput[i] = FInput[i] * 2;

			//FLogger.Log(LogType.Debug, "hi tty!");
		}
	}
}

