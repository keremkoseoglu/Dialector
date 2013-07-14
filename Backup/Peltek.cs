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
			strRet = strRet.Replace("r", "�");
			strRet = strRet.Replace("R", "�");
			strRet = strRet.Replace("s", "t");
			strRet = strRet.Replace("S", "T");
			strRet = strRet.Replace("z", "t");
			strRet = strRet.Replace("Z", "T");

			// D�zeltme
			strRet = strRet.Replace("<b�>", "<br>");
			strRet = strRet.Replace("h�ef", "href");
			strRet = strRet.Replace("atpx", "aspx");
			strRet = strRet.Replace("ta�get", "target");
			strRet = strRet.Replace("pa�ent", "parent");
			strRet = strRet.Replace("clatt", "class");
			

			// Bu kadar!
			return strRet;
		}
	}
}
