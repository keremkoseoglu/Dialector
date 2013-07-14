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
						c != "�" &&
						c != "i" &&
						c != "o" &&
						c != "�" &&
						c != "u" &&
						c != "�" &&
						c != "A" &&
						c != "E" &&
						c != "I" &&
						c != "�" &&
						c != "O" &&
						c != "�" &&
						c != "U" &&
						c != "�") ||
						(c2 == " a" ||
						c2 == " e" ||
						c2 == " �" ||
						c2 == " i" ||
						c2 == " o" ||
						c2 == " �" ||
						c2 == " u" ||
						c2 == " �" ||
						c2 == " A" ||
						c2 == " E" ||
						c2 == " I" ||
						c2 == " �" ||
						c2 == " O" ||
						c2 == " �" ||
						c2 == " U" ||
						c2 == " �"))
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
