using System;

namespace Dialector
{
	/// <summary>
	/// Summary description for Tiki.
	/// </summary>
	public class Tiki : Dialect
	{
		private Util u;

		public Tiki()
		{
			u = new Util();
		}
		#region Dialect Members

		public string getDialect(string Text)
		{
			string s = Text;

			s = s.Replace("!", " filan oldum yani!");
			s = s.Replace("olur", "filan olur");
			u.replaceText(ref s, "maktad�r", "�yor", false, true);
			u.replaceText(ref s, "mektedir", "iyor", false, true);
			u.replaceText(ref s, "ar", "�yor", false, true);
			u.replaceText(ref s, "de�il", "dermi�im", false, true);
			u.replaceText(ref s, "ir", "iyor", false, true);

			u.replaceText(ref s, "yorsunuz", "yorsunaaaz", false, true);
			u.replaceText(ref s, "yoruz", "yoruaaz", false, true);
			u.replaceText(ref s, "yorlar", "yorluaar", false, true);
			u.replaceText(ref s, "yor", "aar", false, true);
			
			u.replaceText(ref s, "acak", "cak", false, true);			
			u.replaceText(ref s, "d�", "d�aa", false, true);
			u.replaceText(ref s, "d�r", "d�aar filan yani", false, true);
			u.replaceText(ref s, "dir", "dieer filan yani", false, true);
			u.replaceText(ref s, "dur", "duaar filan yani", false, true);
			u.replaceText(ref s, "di", "diee", false, true);
			u.replaceText(ref s, "du", "duaa", false, true);
			u.replaceText(ref s, "ecek", "cek", false, true);
			u.replaceText(ref s, "�m", "�aam", false, true);
			u.replaceText(ref s, "�n", "�aan", false, true);
			u.replaceText(ref s, "im", "ieem", false, true);
			u.replaceText(ref s, "in", "ieen", false, true);
			u.replaceText(ref s, "iniz", "ineez", false, true);
			u.replaceText(ref s, "l�", "l�aa", false, true);
			u.replaceText(ref s, "li", "liee", false, true);
			u.replaceText(ref s, "m�", "m�aa", false, true);
			u.replaceText(ref s, "mi", "miee", false, true);
			u.replaceText(ref s, "t�r", "t�aar filan yani", false, true);
			u.replaceText(ref s, "tir", "tieer filan yani", false, true);
			u.replaceText(ref s, "um", "aam", false, true);
			u.replaceText(ref s, "un", "aan", false, true);

			s = u.replaceTextFirstCapital(s, "anne", "mami");
			s = u.replaceTextFirstCapital(s, "berbat", "yivrean�");
			s = u.replaceTextFirstCapital(s, "filan", "felan");
			s = u.replaceTextFirstCapital(s, "gibi", "gibee");
			s = u.replaceTextFirstCapital(s, "i�ren�", "yivrean�");
			s = u.replaceTextFirstCapital(s, "k�t�", "yivrean�");
			s = u.replaceTextFirstCapital(s, "peki", "pekiee");
			s = u.replaceTextFirstCapital(s, "problem", "prabl�m");
			s = u.replaceTextFirstCapital(s, "s�per", "s�peaar");
			s = u.replaceTextFirstCapital(s, "yani", "yanee");

			return s;
		}

		#endregion
	}
}
