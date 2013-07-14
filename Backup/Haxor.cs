using System;

namespace Dialector
{
	/// <summary>
	/// Summary description for Haxor.
	/// </summary>
	public class Haxor : Dialect
	{
		public Haxor()
		{

		}

		public string getDialect(string Text)
		{
			string s = "";
			bool tagOpen = false;

			for (int n = 0; n < Text.Length; n++)
			{
				string c = Text.Substring(n, 1);
				if (c == "<") tagOpen = true;

				if (!tagOpen)
				{
					switch (c.ToUpper())
					{
						case "V": s += "\\/";	break;
						case "A": s += "4";		break;
						case "B": s += "8";		break;
						case "C": s += "c";		break;
						case "D": s += "|)";	break;
						case "E": s += "3";		break;
						case "F": s += "f";		break;
						case "G": s += "9";		break;
						case "H": s += "|-|";	break;
						case "I": s += "i";		break;
						case "Ý": s += "i";		break;
						case "J": s += "j";		break;
						case "K": s += "|&lt;";	break;
						case "L": s += "|";		break;
						case "M": s += "|V|";	break;
						case "N": s += "n";		break;
						case "O": s += "0";		break;
						case "Ö": s += "0";		break;
						case "P": s += "p";		break;
						case "Q": s += "q";		break;
						case "R": s += "|2";	break;
						case "S": s += "5";		break;
						case "Þ": s += "$";		break;
						case "T": s += "7";		break;
						case "U": s += "|_|";	break;
						case "Ü": s += "|_|";	break;
						case "X": s += "><";	break;
						case "W": s += "|_|_|";	break;
						case "Y": s += "y";		break;
						case "Z": s += "z";		break;
						default : s += c;		break;
					}
				}
				else
				{
					s += c;
				}

				if (c == ">") tagOpen = false;
			}

			return s;
		}
	}
}
