using System;
using SwinGameSDK;
namespace MyGame
{
	public class InGameTimer
	{
		private Timer GameTimer = SwinGame.CreateTimer ();
		private int x;
		private uint _time;
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
			SwinGame.DrawText ("Time: " + _time.ToString (), Color.SkyBlue,SwinGame.LoadFont (SwinGame.PathToResource ("arial.ttf", ResourceKind.FontResource),25), SwinGame.PointAt (870, 185));
		}
	}
}
