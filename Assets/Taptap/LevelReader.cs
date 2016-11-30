using System;
using System.IO;
using System.Collections;

namespace AssemblyCSharp
{
	public class LevelReader {
		private int[] mBeats;
		private string mFolder;
		private int cursor;

		public const int TOP_LEFT = 1;
		public const int TOP_RIGHT = 2;
		public const int BOTTOM_LEFT = 4;
		public const int BOTTOM_RIGHT = 8;

		public LevelReader (string levelRootFolder) {
			mFolder = levelRootFolder;
			cursor = 0;
		}

		public void loadLevel(string levelName) {
			StreamReader reader = new StreamReader (mFolder + "/" + levelName);
			ArrayList list = new ArrayList ();
			string readLine = null;

			while ((readLine = reader.ReadLine ()) != null) {
				int value = int.Parse (readLine);
				list.Add (value);
			}

			mBeats = new int[list.Count];
			list.CopyTo (mBeats);
			reader.Close();
		}

		public bool hasNext() {
			return cursor < mBeats.Length;
		}

		public int nextBeat() {
			return mBeats [cursor++];
		}

		public static bool decodeBeat(int beat, int generatorId) {
			switch (generatorId) {
			case 0: // Top left
				return (beat & TOP_LEFT) != 0;
			case 1: // Top right
				return (beat & TOP_RIGHT) != 0;
			case 2: // Bottom left
				return (beat & BOTTOM_LEFT) != 0;
			case 3:
				return (beat & BOTTOM_RIGHT) != 0;
			default:
				return false;
			}
		}
	}
}

