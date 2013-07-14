using System;

namespace Dialector
{
	/// <summary>
	/// Summary description for Util.
	/// </summary>
	public class Util
	{
		public Util()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void replaceText(ref string Source, string Old, string New, bool leadingSpace, bool trailingSpace)
		{
			string newTxt = Source;

			if (leadingSpace && !trailingSpace)
			{
				newTxt = replaceTextFirstCapital(newTxt, " " + Old, " " + New);
				newTxt = replaceTextFirstCapital(newTxt, "." + Old, "." + New);
				newTxt = replaceTextFirstCapital(newTxt, "," + Old, "," + New);
				newTxt = replaceTextFirstCapital(newTxt, ";" + Old, ";" + New);
				newTxt = replaceTextFirstCapital(newTxt, "`" + Old, "`" + New);
				newTxt = replaceTextFirstCapital(newTxt, "?" + Old, "?" + New);
				newTxt = replaceTextFirstCapital(newTxt, "!" + Old, "!" + New);
				newTxt = replaceTextFirstCapital(newTxt, ">" + Old, ">" + New);
			}
			if (!leadingSpace && trailingSpace)
			{
				newTxt = replaceTextFirstCapital(newTxt, Old + " ", New + " ");
				newTxt = replaceTextFirstCapital(newTxt, Old + ".", New + ".");
				newTxt = replaceTextFirstCapital(newTxt, Old + ",", New + ",");
				newTxt = replaceTextFirstCapital(newTxt, Old + ";", New + ";");
				newTxt = replaceTextFirstCapital(newTxt, Old + "`", New + "`");
				newTxt = replaceTextFirstCapital(newTxt, Old + "?", New + "?");
				newTxt = replaceTextFirstCapital(newTxt, Old + "!", New + "!");
				newTxt = replaceTextFirstCapital(newTxt, Old + "<", New + "<");
			}
			if (!leadingSpace && !trailingSpace)
			{
				newTxt = replaceTextFirstCapital(newTxt, Old, New);
			}

			Source = newTxt;
		}

		public string replaceTextFirstCapital(string source, string Old, string New)
		{
			string ret = source;
			string oldCaps, newCaps;

			if (Old.Length <= 1)
			{
				oldCaps = Old.ToUpper();
			}
			else
			{
				oldCaps = Old.Substring(0, 1).ToUpper() + Old.Substring(1, Old.Length - 1);
			}

			if (New.Length <= 1)
			{
				newCaps = New.ToUpper();
			}
			else
			{
				newCaps = New.Substring(0, 1).ToUpper() + New.Substring(1, New.Length - 1);
			}

			newCaps = New.Substring(0, 1).ToUpper() + New.Substring(1, New.Length - 1);
			
			ret = ret.Replace(Old, New);
			ret = ret.Replace(oldCaps, newCaps);

			return ret;
		}

	}
}
