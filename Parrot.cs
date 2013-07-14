using System;

namespace Dialector
{
	/// <summary>
	/// Summary description for Parrot.
	/// </summary>
	public class Parrot : Dialect
	{
		public Turkish	language;

		public Parrot()
		{
			//
			// TODO: Add constructor logic here
			//
			language	= new Turkish();
		}

		public string getDialect(string Text)
		{
			return Text;
		}
	}
}
