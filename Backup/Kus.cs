using System;
using System.Collections;

namespace Dialector
{
	/// <summary>
	/// Summary description for Kus.
	/// </summary>
	public class Kus : Dialect
	{
		public Turkish	language;

		public Kus()
		{
			//
			// TODO: Add constructor logic here
			//
			language	= new Turkish();
		}

		public string getDialect(string Text)
		{
			ArrayList	alMain;
			bool		tagOpen = false;
			string		curSyl;
			string		strRet = "";

			// General
			alMain = new ArrayList();
			alMain = language.getTextSyllabus(Text);

			for (int n = 0; n < alMain.Count; n++)
			{
				curSyl = alMain[n].ToString();

				if (curSyl.IndexOf("<") >= 0) tagOpen = true;

				if (tagOpen)
				{
					strRet += curSyl;
				}
				else
				{
					switch(curSyl.Length)
					{
						case 1:
							if (language.alphabet.letterExists(curSyl))
							{
								strRet += curSyl + "g" + curSyl;
							}
							else
							{
								strRet += curSyl;
							}
							break;
						case 2:
							// XA
							if (language.alphabet.getLetterType(curSyl.Substring(0, 1)) == Letter.TYPE.CLOSE)
							{
								strRet += curSyl + "g" + curSyl.Substring(1, 1);
							}
							// AX
							else
							{
								strRet += curSyl.Substring(0, 1) + "g" + curSyl.Substring(0, 1) + curSyl.Substring(1, 1);
							}
							break;
						case 3:
							// AXX
							if (language.alphabet.getLetterType(curSyl.Substring(1, 1)) == Letter.TYPE.CLOSE)
							{
								strRet += curSyl.Substring(0, 1) + "g" + curSyl;
							}
							// XAX
							else
							{
								strRet += curSyl.Substring(0, 2) + "g" + curSyl.Substring(1, 2);
							}
							break;
						case 4:
							// XXAX
							if (language.alphabet.getLetterType(curSyl.Substring(1, 1)) == Letter.TYPE.CLOSE)
							{
								strRet += curSyl;
							}
							// XAXX
							else
							{
								strRet += curSyl.Substring(0, 2) + "g" + curSyl.Substring(1, 3);
							}
							break;
						default:
							strRet += curSyl;
							break;
					}
				}

				if (curSyl.IndexOf(">") >= 0) tagOpen = false;
			}

			// Fine tuning
			strRet = strRet.Replace(".g", ".");
			strRet = strRet.Replace(",g", ",");
			strRet = strRet.Replace("`g", ",");
			strRet = strRet.Replace("!g", ",");
			strRet = strRet.Replace("?g", ",");

			// Thats all
			return strRet;
		}
	}
}
