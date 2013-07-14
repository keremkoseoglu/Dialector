using System;

namespace Dialector
{
	/// <summary>
	/// Summary description for Letter.
	/// </summary>
	public class Letter
	{
		public enum TYPE: long {OPEN, CLOSE};

		public string	minVal;
		public string	majVal;
		public TYPE		type;

		public Letter(string MinVal, string MajVal, TYPE Type)
		{
			//
			// TODO: Add constructor logic here
			//
			minVal	= MinVal;
			majVal	= MajVal;
			type	= Type;
		}
	}
}
