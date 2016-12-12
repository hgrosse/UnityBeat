using System;
using System.IO;
using System.Collections;
using UnityEngine;

namespace AssemblyCSharp
{
	/**
	 * Classe permettant de lire un fichier contenant le codage d'un niveau.
	 * Chaque battement est codé par un nombre entre 0 et 15, 
	 * où 0 représent aucun battement,
	 * 1 pour en haut à gauche,
	 * 2 pour en haut à droite,
	 * 4 pour en bas à gauche,
	 * 8 pour en bas à droite.
	 * Les autres nombres sont des combinaisons des autres.
	 */
	public class LevelReader {
		private string[] mBeats;
		private string mFolder;
		private int mCursor;

		private const int TOP_LEFT = 1;
		private const int TOP_RIGHT = 2;
		private const int BOTTOM_LEFT = 4;
		private const int BOTTOM_RIGHT = 8;

		/**
		 * Crée un nouveau lecteur de niveau.
		 * levelRootFolder est le nom du dossier qui contient les niveaux.
		 */ 
		public LevelReader () {
			mCursor = 0;
		}

		/**
		 * Charge un niveau donné par son nom.
		 */ 
		public void LoadLevel(string levelName) {
			TextAsset level = Resources.Load ("levels/" + levelName) as TextAsset;
			mBeats = level.text.Split(new char[] {'\n'});
			mCursor = 0;
		}

		/**
		 * Indique s'il y a encore des battements à lire, 
		 * ie. si le niveau n'est pas terminé.
		 */ 
		public bool HasNext() {
			return mCursor < mBeats.Length;
		}

		/**
		 * Récupère la valeur du prochain battement et passe au suivant.
		 */ 
		public int NextBeat() {
			return int.Parse(mBeats [mCursor++]);
		}

		/**
		 * Indique si un battement doit générer une sphère pour un cylindre donné.
		 */
		public static bool DecodedBeat(int beat, int index) {
			switch (index) {
			case 0: // Top left
				return (beat & TOP_LEFT) != 0;
			case 1: // Top right
				return (beat & TOP_RIGHT) != 0;
			case 2: // Bottom left
				return (beat & BOTTOM_LEFT) != 0;
			case 3: // Bottom right
				return (beat & BOTTOM_RIGHT) != 0;
			default:
				return false;
			}
		}
	}
}