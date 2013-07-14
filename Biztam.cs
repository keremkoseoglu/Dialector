using System;
using System.Collections;

namespace Dialector
{
	/// <summary>
	/// Summary description for Biztam.
	/// </summary>
	public class Biztam : Dialect
	{
		public Turkish	language;

		public Biztam()
		{
			//
			// TODO: Add constructor logic here
			//
			language	= new Turkish();
		}

		public string getDialect(string Text)
		{
			ArrayList	alMain;
			bool		tagOpen;
			int			sylPos;
			string		curSyl;
			string		strRet = "";

			alMain = new ArrayList();
			alMain = language.getTextSyllabus(Text);

			tagOpen		= false;
			for (sylPos = 0; sylPos < alMain.Count; sylPos++)
			{
				curSyl = alMain[sylPos].ToString().ToLower();

				// TAG açýk mý?
				if (curSyl.IndexOf("<") >= 0) tagOpen = true;
				if (!tagOpen)
				{
					// Kelimenin veya metnin sonu ise...
					if (curSyl == " " || sylPos == alMain.Count - 1)
					{
						int n;

						// Son hecenin son harfi ünsüz ise öncesine "R" ekleyelim
						if (curSyl == " ")
						{
							n		= sylPos - 1;
							curSyl	= alMain[sylPos - 1].ToString();
						}
						else
						{
							n		= sylPos;
						}
						if (language.alphabet.getLetterType(curSyl.Substring(curSyl.Length - 1, 1)) == Letter.TYPE.CLOSE)
						{
							alMain[n] = curSyl.Substring(0, curSyl.Length - 1) + "r" + curSyl.Substring(curSyl.Length - 1, 1);
						}
					}
					else
					{
						// Son harfi ünlü ise sonuna "R" ekleyelim
						if (language.alphabet.getLetterType(curSyl.Substring(curSyl.Length - 1, 1)) == Letter.TYPE.OPEN)
						{
							bool b = true;
							string s;

							// Tek harfli bir hece ise, sonraki hecenin ilk harfi "R" olmamalý
							if (curSyl.Length == 1)
							{
								s = alMain[sylPos + 1].ToString().Substring(0, 1);
								if (s == "r" || s == "R") b = false;
							}

							// Son harften önceki harf "r" olmamalý
							if (curSyl.Length > 1)
							{
								s = curSyl.Substring(curSyl.Length - 2, 1);
								if (s == "R" && s == "r") b = false;
							}

							// Bütün kontrollerden geçtiysek ekleyebiliriz
							if (b) alMain[sylPos] = curSyl + "r";
						}
					}
				}

				if (curSyl.IndexOf(">") >= 0) tagOpen = false;
			}

			// Metnimizi oluþturalým
			strRet = "";
			for (sylPos = 0; sylPos < alMain.Count; sylPos++)
			{
				strRet += alMain[sylPos].ToString();
			}

			// Son rötuþlar
			strRet = strRet.Replace("rb", "b");
			strRet = strRet.Replace("rl", "r");
			strRet = strRet.Replace("rð", "ð");
			strRet = strRet.Replace("rr", "r");
			strRet = strRet.Replace("rv", "v");
			strRet = strRet.Replace("ry", "y");
			strRet = strRet.Replace("l", "r");
			strRet = strRet.Replace("n", "r");
			strRet = strRet.Replace(".r", ".");
			strRet = strRet.Replace(",r", ",");
			strRet = strRet.Replace("!r", "!");
			strRet = strRet.Replace(";r", ";");
			strRet = strRet.Replace("cat=fer", "cat=fel");
			strRet = strRet.Replace("crass=", "class=");

			// Bu kadar!
			return strRet;
		}
	}
}
