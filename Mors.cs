using System;

namespace Dialector
{
	/// <summary>
	/// Summary description for Mors.
	/// </summary>
	public class Mors : Dialect
	{
		private Turkish trk;

		public Mors()
		{
			trk = new Turkish();
		}

		public string getDialect(string Text)
		{
			string s = trk.getPureText(Text).ToLower();
			string s2 = "";
			bool tagOpen = false;

			for (int n = 0; n < s.Length; n++)
			{
				string c = s.Substring(n, 1);
				if (c == "<") tagOpen = true;

				if (tagOpen)
				{
					s2 += c;
				}
				else
				{
					switch (c)
					{
						case "a": s2 += ".-"; break;
						case "b": s2 += "-..."; break;
						case "c": s2 += "-.-."; break;
						case "d": s2 += "-.."; break;
						case "e": s2 += "."; break;
						case "f": s2 += "..-."; break;
						case "g": s2 += "--."; break;
						case "h": s2 += "...."; break;
						case "i": s2 += ".."; break;
						case "j": s2 += ".---"; break;
						case "k": s2 += "-.-"; break;
						case "l": s2 += ".-.."; break;
						case "m": s2 += "--"; break;
						case "n": s2 += "-."; break;
						case "o": s2 += "---"; break;
						case "p": s2 += ".--."; break;
						case "q": s2 += "--.-"; break;
						case "r": s2 += ".-."; break;
						case "s": s2 += "..."; break;
						case "t": s2 += "-"; break;
						case "u": s2 += "..-"; break;
						case "v": s2 += "...-"; break;
						case "w": s2 += ".--"; break;
						case "x": s2 += "-..-"; break;
						case "y": s2 += "-.--"; break;
						case "z": s2 += "--.."; break;
						case "0": s2 += "-----"; break;
						case "1": s2 += ".----"; break;
						case "2": s2 += "..---"; break;
						case "3": s2 += "...--"; break;
						case "4": s2 += "....-"; break;
						case "5": s2 += "....."; break;
						case "6": s2 += "-...."; break;
						case "7": s2 += "--..."; break;
						case "8": s2 += "---.."; break;
						case "9": s2 += "----."; break;
						case ".": s2 += ".-.-.-"; break;
						case ",": s2 += "--..--"; break;						
					}
				}

				if (c == ">") tagOpen = false;
			}

			return s2;
		}
	}
}
