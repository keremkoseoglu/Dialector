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
			u.replaceText(ref s, "maktadýr", "ýyor", false, true);
			u.replaceText(ref s, "mektedir", "iyor", false, true);
			u.replaceText(ref s, "ar", "ýyor", false, true);
			u.replaceText(ref s, "deðil", "dermiþim", false, true);
			u.replaceText(ref s, "ir", "iyor", false, true);

			u.replaceText(ref s, "yorsunuz", "yorsunaaaz", false, true);
			u.replaceText(ref s, "yoruz", "yoruaaz", false, true);
			u.replaceText(ref s, "yorlar", "yorluaar", false, true);
			u.replaceText(ref s, "yor", "aar", false, true);
			
			u.replaceText(ref s, "acak", "cak", false, true);			
			u.replaceText(ref s, "dý", "dýaa", false, true);
			u.replaceText(ref s, "dýr", "dýaar filan yani", false, true);
			u.replaceText(ref s, "dir", "dieer filan yani", false, true);
			u.replaceText(ref s, "dur", "duaar filan yani", false, true);
			u.replaceText(ref s, "di", "diee", false, true);
			u.replaceText(ref s, "du", "duaa", false, true);
			u.replaceText(ref s, "ecek", "cek", false, true);
			u.replaceText(ref s, "ým", "ýaam", false, true);
			u.replaceText(ref s, "ýn", "ýaan", false, true);
			u.replaceText(ref s, "im", "ieem", false, true);
			u.replaceText(ref s, "in", "ieen", false, true);
			u.replaceText(ref s, "iniz", "ineez", false, true);
			u.replaceText(ref s, "lý", "lýaa", false, true);
			u.replaceText(ref s, "li", "liee", false, true);
			u.replaceText(ref s, "mý", "mýaa", false, true);
			u.replaceText(ref s, "mi", "miee", false, true);
			u.replaceText(ref s, "týr", "týaar filan yani", false, true);
			u.replaceText(ref s, "tir", "tieer filan yani", false, true);
			u.replaceText(ref s, "um", "aam", false, true);
			u.replaceText(ref s, "un", "aan", false, true);

			s = u.replaceTextFirstCapital(s, "anne", "mami");
			s = u.replaceTextFirstCapital(s, "berbat", "yivreanç");
			s = u.replaceTextFirstCapital(s, "filan", "felan");
			s = u.replaceTextFirstCapital(s, "gibi", "gibee");
			s = u.replaceTextFirstCapital(s, "iðrenç", "yivreanç");
			s = u.replaceTextFirstCapital(s, "kötü", "yivreanç");
			s = u.replaceTextFirstCapital(s, "peki", "pekiee");
			s = u.replaceTextFirstCapital(s, "problem", "prablým");
			s = u.replaceTextFirstCapital(s, "süper", "süpeaar");
			s = u.replaceTextFirstCapital(s, "yani", "yanee");

			return s;
		}

		#endregion
	}
}
