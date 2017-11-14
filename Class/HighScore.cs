using System;
using System.IO;
using SwinGameSDK;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

// Controls displaying and collecting high score data and Data is saved to a file.
static class HighScoreController
{
	private const int NAME_WIDTH = 9;
	private const int SCORES_LEFT = 50;
	private static Dictionary<string, Font> _Fonts = new Dictionary<string, Font> ();

	// The score structure is used to keep the name and score of the top players together.
	private struct ScoreObj : IComparable
	{
		public string Name;
		public int Value;
		// Allows scores to be compared to facilitate sorting
		public int CompareTo (object obj)
		{
			if (obj is ScoreObj) {
				ScoreObj other = (ScoreObj)obj;
				return other.Value - this.Value;
			} else {
				return 0;
			}
		}
	}

	private static List<ScoreObj> _Scores = new List<ScoreObj> ();

	// Loads the scores from the highscores text file.
	// The format is # of scores NNNNNNNNSSSS Where NNNNNNNN is the name and SSSS is the score
	private static void LoadScores ()
	{
		string filename = null;
		filename = SwinGame.PathToResource ("highscore.txt");

		StreamReader input = default (StreamReader);
		input = new StreamReader (filename);

		//Read in the # of scores
		int numScores = 0;
		numScores = Convert.ToInt32 (input.ReadLine ());

		_Scores.Clear ();

		int i = 0;

		for (i = 1; i <= numScores; i++) {
			ScoreObj s = default (ScoreObj);
			string line = null;

			line = input.ReadLine ();
			s.Name = line.Substring (0, NAME_WIDTH);
			s.Value = Convert.ToInt32 (line.Substring (NAME_WIDTH));
			_Scores.Add (s);
		}
		input.Close ();
	}

	// Draws the high scores to the screen.
	public static void DrawHighScores ()
	{
		const int SCORES_TOP = 150;
		const int SCORE_GAP = 30;
		SwinGame.DrawBitmap ("mainmenu.jpg", 0, 0);
		if (_Scores.Count == 0) {
			LoadScores ();
		}
		SwinGame.DrawText ("High Score List", Color.White, "arial", 50, 365, 50);

		//For all of the scores
		int i = 0;
		for (i = 0; i <= _Scores.Count - 1; i++) {
			ScoreObj s = default (ScoreObj);

			s = _Scores [i];

			//for scores 1 - 9 use 01 - 09
			if (i < 9) {
				SwinGame.DrawText (" " + (i + 1) + ". " + s.Name + "   " + s.Value, Color.White, "Envy Code R", 30, 380, SCORES_TOP + i * SCORE_GAP);
			} else {
				SwinGame.DrawText (i + 1 + ". " + s.Name + "   " + s.Value, Color.White, "Envy Code R", 30, 380, SCORES_TOP + i * SCORE_GAP);
			}
		}
	}

	// Saves the scores back to the highscores text file.
	// The format is # of scores NNNNNNNNSSSS Where NNNNNNNN is the name and SSSS is the score
	private static void SaveScores ()
	{
		string filename = null;
		filename = SwinGame.PathToResource ("highscore.txt");

		StreamWriter output = default (StreamWriter);
		output = new StreamWriter (filename);

		output.WriteLine (_Scores.Count);

		foreach (ScoreObj s in _Scores) {
			output.WriteLine (s.Name + s.Value);
		}
		output.Close ();
	}
	public static Font GameFont (string font)
	{
		return _Fonts [font];
	}
	private static void NewFont (string fontName, string filename, int size)
	{
		_Fonts.Add (fontName, SwinGame.LoadFont (SwinGame.PathToResource (filename, ResourceKind.FontResource), size));
	}

	// Read the user's name for their highsSwinGame.
	public static void ReadHighScore (int value)
	{
		const int ENTRY_TOP = 150;
		const int NEW_SCORES = 350;
		if (_Scores.Count == 0)
			LoadScores ();

		if (value > _Scores [_Scores.Count - 1].Value) {    //is it a high score
			ScoreObj s = new ScoreObj ();
			s.Value = value;
            NewFont ("Envy Code R", "Envy Code R.tff", 25);
			int x = 0;
			x = NEW_SCORES + SwinGame.TextWidth (GameFont ("Envy Code R"), "Name: ");
			SwinGame.StartReadingText (Color.Black, NAME_WIDTH, GameFont ("Envy Code R"), x, ENTRY_TOP);

			while (SwinGame.ReadingText ()) {   //Read the text from the user
				SwinGame.ProcessEvents ();
				DrawHighScores ();
				SwinGame.DrawText ("Name: ", Color.Black, "Envy Code R", 25, NEW_SCORES, ENTRY_TOP);
				SwinGame.RefreshScreen ();
			}

			s.Name = SwinGame.TextReadAsASCII ();
			if (s.Name.Length < NAME_WIDTH) {
				s.Name = s.Name + new string (Convert.ToChar (" "), NAME_WIDTH - s.Name.Length);
			}

			_Scores.RemoveAt (_Scores.Count - 1);
			_Scores.Add (s);
			_Scores.Sort ();
			SaveScores ();
		}
	}

}