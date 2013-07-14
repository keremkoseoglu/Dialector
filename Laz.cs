using System;

namespace Dialector
{
	/// <summary>
	/// Summary description for Laz.
	/// </summary>
	public class Laz : Dialect
	{
		private Util u;

		public Laz()
		{
			//
			// TODO: Add constructor logic here
			//
			u = new Util();
		}

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

        private void replace(ref string strRet)
        {
            strRet = " " + strRet + " ";

			u.replaceText(ref strRet, "b"	, "p"			, true, false);
			u.replaceText(ref strRet, "g"	, "c"			, true, false);
			u.replaceText(ref strRet, "k"	, "ç"			, true, false);
			u.replaceText(ref strRet, "ci"	, "cu"			, false, true);
			u.replaceText(ref strRet, "çý"	, "çi"			, false, true);
			u.replaceText(ref strRet, "du"	, "di"			, false, true);
			u.replaceText(ref strRet, "dü"	, "di"			, false, true);
			u.replaceText(ref strRet, "dý"	, "du"			, false, true);
			u.replaceText(ref strRet, "in"	, "un"			, false, true);
			u.replaceText(ref strRet, "ýk"	, "uk"			, false, true);
			u.replaceText(ref strRet, "ýp"	, "up"			, false, true);
			u.replaceText(ref strRet, "ip"	, "up"			, false, true);
			u.replaceText(ref strRet, "ki"	, "çi"			, false, false);
			u.replaceText(ref strRet, "ým"	, "um"			, false, true);
			u.replaceText(ref strRet, "im"	, "um"			, false, true);
			u.replaceText(ref strRet, "lý"	, "lu"			, false, true);
			u.replaceText(ref strRet, "li"	, "lu"			, false, true);
			u.replaceText(ref strRet, "sý"	, "su"			, false, true);
			u.replaceText(ref strRet, "si"	, "su"			, false, true);
			u.replaceText(ref strRet, "ti"	, "tu"			, false, false);
			u.replaceText(ref strRet, "dýr"	, "dur daa"		, false, true);
			u.replaceText(ref strRet, "dir"	, "dur daa"		, false, true);
			u.replaceText(ref strRet, "ýðý"	, "ýðu"			, false, false);
			u.replaceText(ref strRet, "iði"	, "iðu"			, false, false);
			u.replaceText(ref strRet, "iði"	, "uðu"			, false, true);
			u.replaceText(ref strRet, "igi"	, "ugu"			, false, true);
			u.replaceText(ref strRet, "ini"	, "inu"			, false, true);
			u.replaceText(ref strRet, "lýk"	, "luk"			, false, true);
			u.replaceText(ref strRet, "lik"	, "luk"			, false, true);
			u.replaceText(ref strRet, "lýr"	, "lur"			, false, true);
			u.replaceText(ref strRet, "lir"	, "lur"			, false, true);
			u.replaceText(ref strRet, "nýn"	, "nun"			, false, true);
			u.replaceText(ref strRet, "sýz"	, "suz"			, false, true);
			u.replaceText(ref strRet, "týr"	, "tur daa"		, false, true);
			u.replaceText(ref strRet, "tir"	, "tur daa"		, false, true);
			u.replaceText(ref strRet, "imiz"	, "umuz"		, false, true);
			u.replaceText(ref strRet, "ýyor"	, "iir"			, false, false);
			u.replaceText(ref strRet, "iyor"	, "iir"			, false, false);

			// Rötuþ
			u.replaceText(ref strRet, "uði"	, "iðu"			, false, true);
			u.replaceText(ref strRet, "pur"	, "bir"			, true, false);
			u.replaceText(ref strRet, "Pur"	, "Bir"			, true, false);
			u.replaceText(ref strRet, "uðý"	, "uðu"			, false, true);
			u.replaceText(ref strRet, "ugi"	, "ugu"			, false, true);
			u.replaceText(ref strRet, "umýz"	, "umuz"		, false, true);

			// Kelime tercümeleri
			u.replaceTextFirstCapital(strRet, "adam", "koçi");
			u.replaceTextFirstCapital(strRet, "asla", "varþa");
			u.replaceTextFirstCapital(strRet, "baþka", "çkva");

			u.replaceTextFirstCapital(strRet, "benim", "çkimi");
			
			u.replaceTextFirstCapital(strRet, "beraber", "arto");

			u.replaceTextFirstCapital(strRet, "bizim", "çkuni");

			u.replaceTextFirstCapital(strRet, "buyuk", "didi");
			u.replaceTextFirstCapital(strRet, "büyük", "didi");

			u.replaceTextFirstCapital(strRet, "dogru", "mtini");
			u.replaceTextFirstCapital(strRet, "doðru", "mtini");
			u.replaceTextFirstCapital(strRet, "eski", "mcveþi");

			u.replaceTextFirstCapital(strRet, "herþey", "irikolo");
			u.replaceTextFirstCapital(strRet, "her þey", "irikolo");

			u.replaceTextFirstCapital(strRet, "insan", "koçi");
			u.replaceTextFirstCapital(strRet, "kayýp", "gondineri");

			u.replaceTextFirstCapital(strRet, "kýsa", "mkule");
			u.replaceTextFirstCapital(strRet, "kisa", "mkule");

			u.replaceTextFirstCapital(strRet, "kisi", "koçi");
			u.replaceTextFirstCapital(strRet, "kiþi", "koçi");
			u.replaceTextFirstCapital(strRet, "kucuk", "çuta");
			u.replaceTextFirstCapital(strRet, "küçük", "çuta");
			u.replaceTextFirstCapital(strRet, "ruzgar", "ixi");
			u.replaceTextFirstCapital(strRet, "rüzgar", "ixi");

			u.replaceTextFirstCapital(strRet, "sans", "bedi");
			u.replaceTextFirstCapital(strRet, "þans", "bedi");

			u.replaceTextFirstCapital(strRet, "senin", "skani");
			
			u.replaceTextFirstCapital(strRet, "sizin", "tkvani");
			u.replaceTextFirstCapital(strRet, "talih", "bedi");

			u.replaceTextFirstCapital(strRet, "umit", "imedi");
			u.replaceTextFirstCapital(strRet, "umut", "imedi");
			u.replaceTextFirstCapital(strRet, "ümit", "imedi");

			u.replaceTextFirstCapital(strRet, "uzun", "gunze");
			u.replaceTextFirstCapital(strRet, "yalnýz", "xvala");
			u.replaceTextFirstCapital(strRet, "yeni", "aðani");

            // Boþluklarý alalým
            strRet = strRet.Substring(1, strRet.Length - 2);
        }

	}

}
