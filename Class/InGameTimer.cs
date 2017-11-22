using System;
using SwinGameSDK;
namespace MyGame
{
	public class InGameTimer
	{
		private Timer GameTimer = SwinGame.CreateTimer ();
		private int x;
		private uint _time;

		public uint getTimer {
			get { return _time; }
			set { _time = value; }
		}

		public int getX {
			get { return x; }
			set { x = value; } 
		}

		public InGameTimer ()
		{
			x = 0;
		}

		public void drawTimer () {
			if (x == 0) {
				SwinGame.ResetTimer (GameTimer);
				SwinGame.StartTimer (GameTimer);
				x++;
			}
			_time = SwinGame.TimerTicks (GameTimer) / 1000;
			SwinGame.DrawText ("Time: " + _time.ToString (), Color.Green,SwinGame.LoadFont (SwinGame.PathToResource ("arial.ttf", ResourceKind.FontResource),30), SwinGame.PointAt (840, 90));
		}
	}
}
