using System;

namespace Dialector
{
	/// <summary>
	/// Summary description for Emmi.
	/// </summary>
	public class Emmi : Dialect
	{
		private Util u;

		public Emmi()
		{
			u = new Util();
		}
		#region Dialect Members

		public string getDialect(string Text)
		{
            string word = "";
            string s = "";
            bool tagClose = true;

            for (int n = 0; n < Text.Length; n++)
            {
                string cur = Text.Substring(n, 1);

                switch (cur)
                {
                    case "<": tagClose = false; break;
                    case ">": tagClose = true; break;
                }

                if (cur == " ")
                {
                    if (tagClose) replace(ref word);
                    s += " " + word;
                    word = "";
                }
                else
                {
                    word += cur;
                }
            }
			
			return s;
		}

        private void replace(ref string s)
        {
            s = s.Replace(" k", " g");
            s = s.Replace(" K", " G");
            s = u.replaceTextFirstCapital(s, "k", "h");

            u.replaceText(ref s, "�", "u", false, true);
            u.replaceText(ref s, "I", "U", false, true);
            u.replaceText(ref s, "i", "�", false, true);
            u.replaceText(ref s, "�", "�", false, true);
            u.replaceText(ref s, "p", "b", true, false);
            u.replaceText(ref s, "P", "B", true, false);
            u.replaceText(ref s, "s", "z", true, false);
            u.replaceText(ref s, "S", "Z", true, false);
            u.replaceText(ref s, "t", "d", true, false);
            u.replaceText(ref s, "T", "D", true, false);

            s = s.Replace("e�e", "ee");
            s = s.Replace("i�i", "ii");
            s = s.Replace("iyor", "��r");
            s = u.replaceTextFirstCapital(s, "hi�", "he�");
        }

		#endregion
	}
}
