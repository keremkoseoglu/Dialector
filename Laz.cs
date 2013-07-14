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
			u.replaceText(ref strRet, "k"	, "�"			, true, false);
			u.replaceText(ref strRet, "ci"	, "cu"			, false, true);
			u.replaceText(ref strRet, "��"	, "�i"			, false, true);
			u.replaceText(ref strRet, "du"	, "di"			, false, true);
			u.replaceText(ref strRet, "d�"	, "di"			, false, true);
			u.replaceText(ref strRet, "d�"	, "du"			, false, true);
			u.replaceText(ref strRet, "in"	, "un"			, false, true);
			u.replaceText(ref strRet, "�k"	, "uk"			, false, true);
			u.replaceText(ref strRet, "�p"	, "up"			, false, true);
			u.replaceText(ref strRet, "ip"	, "up"			, false, true);
			u.replaceText(ref strRet, "ki"	, "�i"			, false, false);
			u.replaceText(ref strRet, "�m"	, "um"			, false, true);
			u.replaceText(ref strRet, "im"	, "um"			, false, true);
			u.replaceText(ref strRet, "l�"	, "lu"			, false, true);
			u.replaceText(ref strRet, "li"	, "lu"			, false, true);
			u.replaceText(ref strRet, "s�"	, "su"			, false, true);
			u.replaceText(ref strRet, "si"	, "su"			, false, true);
			u.replaceText(ref strRet, "ti"	, "tu"			, false, false);
			u.replaceText(ref strRet, "d�r"	, "dur daa"		, false, true);
			u.replaceText(ref strRet, "dir"	, "dur daa"		, false, true);
			u.replaceText(ref strRet, "���"	, "��u"			, false, false);
			u.replaceText(ref strRet, "i�i"	, "i�u"			, false, false);
			u.replaceText(ref strRet, "i�i"	, "u�u"			, false, true);
			u.replaceText(ref strRet, "igi"	, "ugu"			, false, true);
			u.replaceText(ref strRet, "ini"	, "inu"			, false, true);
			u.replaceText(ref strRet, "l�k"	, "luk"			, false, true);
			u.replaceText(ref strRet, "lik"	, "luk"			, false, true);
			u.replaceText(ref strRet, "l�r"	, "lur"			, false, true);
			u.replaceText(ref strRet, "lir"	, "lur"			, false, true);
			u.replaceText(ref strRet, "n�n"	, "nun"			, false, true);
			u.replaceText(ref strRet, "s�z"	, "suz"			, false, true);
			u.replaceText(ref strRet, "t�r"	, "tur daa"		, false, true);
			u.replaceText(ref strRet, "tir"	, "tur daa"		, false, true);
			u.replaceText(ref strRet, "imiz"	, "umuz"		, false, true);
			u.replaceText(ref strRet, "�yor"	, "iir"			, false, false);
			u.replaceText(ref strRet, "iyor"	, "iir"			, false, false);

			// R�tu�
			u.replaceText(ref strRet, "u�i"	, "i�u"			, false, true);
			u.replaceText(ref strRet, "pur"	, "bir"			, true, false);
			u.replaceText(ref strRet, "Pur"	, "Bir"			, true, false);
			u.replaceText(ref strRet, "u��"	, "u�u"			, false, true);
			u.replaceText(ref strRet, "ugi"	, "ugu"			, false, true);
			u.replaceText(ref strRet, "um�z"	, "umuz"		, false, true);

			// Kelime terc�meleri
			u.replaceTextFirstCapital(strRet, "adam", "ko�i");
			u.replaceTextFirstCapital(strRet, "asla", "var�a");
			u.replaceTextFirstCapital(strRet, "ba�ka", "�kva");

			u.replaceTextFirstCapital(strRet, "benim", "�kimi");
			
			u.replaceTextFirstCapital(strRet, "beraber", "arto");

			u.replaceTextFirstCapital(strRet, "bizim", "�kuni");

			u.replaceTextFirstCapital(strRet, "buyuk", "didi");
			u.replaceTextFirstCapital(strRet, "b�y�k", "didi");

			u.replaceTextFirstCapital(strRet, "dogru", "mtini");
			u.replaceTextFirstCapital(strRet, "do�ru", "mtini");
			u.replaceTextFirstCapital(strRet, "eski", "mcve�i");

			u.replaceTextFirstCapital(strRet, "her�ey", "irikolo");
			u.replaceTextFirstCapital(strRet, "her �ey", "irikolo");

			u.replaceTextFirstCapital(strRet, "insan", "ko�i");
			u.replaceTextFirstCapital(strRet, "kay�p", "gondineri");

			u.replaceTextFirstCapital(strRet, "k�sa", "mkule");
			u.replaceTextFirstCapital(strRet, "kisa", "mkule");

			u.replaceTextFirstCapital(strRet, "kisi", "ko�i");
			u.replaceTextFirstCapital(strRet, "ki�i", "ko�i");
			u.replaceTextFirstCapital(strRet, "kucuk", "�uta");
			u.replaceTextFirstCapital(strRet, "k���k", "�uta");
			u.replaceTextFirstCapital(strRet, "ruzgar", "ixi");
			u.replaceTextFirstCapital(strRet, "r�zgar", "ixi");

			u.replaceTextFirstCapital(strRet, "sans", "bedi");
			u.replaceTextFirstCapital(strRet, "�ans", "bedi");

			u.replaceTextFirstCapital(strRet, "senin", "skani");
			
			u.replaceTextFirstCapital(strRet, "sizin", "tkvani");
			u.replaceTextFirstCapital(strRet, "talih", "bedi");

			u.replaceTextFirstCapital(strRet, "umit", "imedi");
			u.replaceTextFirstCapital(strRet, "umut", "imedi");
			u.replaceTextFirstCapital(strRet, "�mit", "imedi");

			u.replaceTextFirstCapital(strRet, "uzun", "gunze");
			u.replaceTextFirstCapital(strRet, "yaln�z", "xvala");
			u.replaceTextFirstCapital(strRet, "yeni", "a�ani");

            // Bo�luklar� alal�m
            strRet = strRet.Substring(1, strRet.Length - 2);
        }

	}

}
