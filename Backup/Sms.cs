using System;

namespace Dialector
{
	/// <summary>
	/// Summary description for Sms.
	/// </summary>
	public class Sms : Dialect
	{
		public Sms()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region Dialect Members

		public string getDialect(string Text)
		{
			string s = "";
			bool tagOpen = false;

			for (int n = 0; n < Text.Length; n++)
			{
				string c = Text.Substring(n, 1);
				string c2 = "";

				if (n > 0) c2 = Text.Substring(n - 1, 2);

				if (c == "<") tagOpen = true;

				if (tagOpen)
				{
					s += c;
				}
				else
				{
					if 
						((c != "a" &&
						c != "e" &&
						c != "ý" &&
						c != "i" &&
						c != "o" &&
						c != "ö" &&
						c != "u" &&
						c != "ü" &&
						c != "A" &&
						c != "E" &&
						c != "I" &&
						c != "Ý" &&
						c != "O" &&
						c != "Ö" &&
						c != "U" &&
						c != "Ü") ||
						(c2 == " a" ||
						c2 == " e" ||
						c2 == " ý" ||
						c2 == " i" ||
						c2 == " o" ||
						c2 == " ö" ||
						c2 == " u" ||
						c2 == " ü" ||
						c2 == " A" ||
						c2 == " E" ||
						c2 == " I" ||
						c2 == " Ý" ||
						c2 == " O" ||
						c2 == " Ö" ||
						c2 == " U" ||
						c2 == " Ü"))
					{
						s += c;
					}


				}

				if (c == ">") tagOpen = false;
			}

			return s;
		}

		#endregion
	}
}
