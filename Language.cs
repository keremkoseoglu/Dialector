using System;
using System.Collections;

namespace Dialector
{
	/// <summary>
	/// Summary description for Language.
	/// </summary>
	public class Language
	{
		public Alphabet alphabet;
		public string	name;

		public Language()
		{
			//
			// TODO: Add constructor logic here
			//
			clear();
		}

		public void clear()
		{
			name		= "";
			alphabet	= new Alphabet();
		}

		public string getPureText(string Text)
		{
			string ret = "";
			string l;

			for (int n = 0; n < Text.Length; n++)
			{
				l = Text.Substring(n, 1);
				if (alphabet.letterExists(l) || l == " ")
				{
					ret += l;
				}
			}

			return ret;
		}

		public ArrayList getWordSyllabus(string Word)
		{
			return new ArrayList();
		}

		public ArrayList getTextSyllabus(string Text)
		{
			return new ArrayList();
		}
	}
}
