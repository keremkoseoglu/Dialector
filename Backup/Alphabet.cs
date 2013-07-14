using System;

namespace Dialector
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Alphabet
	{
		public Letter[] letter;
		public int		letterCount;

		public Alphabet()
		{
			//
			// TODO: Add constructor logic here
			//
			clear();
		}

		public void appendLetter(string MinVal, string MajVal, Letter.TYPE Type)
		{
			letter[letterCount] = new Letter(MinVal, MajVal, Type);
			letterCount++;
		}

		public void clear()
		{
			letter		= new Letter[255];
			letterCount	= 0;
		}

		public Letter.TYPE getLetterType(string Letter)
		{
			Letter.TYPE lRet = new Dialector.Letter.TYPE();

			for (int n = 0; n < letterCount; n++)
			{
				if (letter[n].majVal == Letter || letter[n].minVal == Letter)
				{
					lRet = letter[n].type;
				}
			}

			return lRet;
		}

		public bool letterExists(string Letter)
		{
			bool ret = false;

			for (int n = 0; n < letterCount; n++)
			{
				if (letter[n].majVal == Letter || letter[n].minVal == Letter)
				{
					ret = true;
				}				
			}

			return ret;
		}
	}
}
