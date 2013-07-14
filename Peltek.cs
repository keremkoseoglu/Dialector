using System;

namespace Dialector
{
	/// <summary>
	/// Summary description for Peltek.
	/// </summary>
	public class Peltek : Dialect
	{
		public Peltek()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string getDialect(string Text)
		{
			string		strRet = "";

			strRet = Text;

			// Genel
			strRet = strRet.Replace("r", "ð");
			strRet = strRet.Replace("R", "Ð");
			strRet = strRet.Replace("s", "t");
			strRet = strRet.Replace("S", "T");
			strRet = strRet.Replace("z", "t");
			strRet = strRet.Replace("Z", "T");

			// Düzeltme
			strRet = strRet.Replace("<bð>", "<br>");
			strRet = strRet.Replace("hðef", "href");
			strRet = strRet.Replace("atpx", "aspx");
			strRet = strRet.Replace("taðget", "target");
			strRet = strRet.Replace("paðent", "parent");
			strRet = strRet.Replace("clatt", "class");
			

			// Bu kadar!
			return strRet;
		}
	}
}
