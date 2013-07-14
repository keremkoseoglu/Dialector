using System;
using System.Collections;

namespace Dialector
{
	/// <summary>
	/// Summary description for Turkish.
	/// </summary>
	public class Turkish : Language
	{
		public Turkish()
		{
			//
			// TODO: Add constructor logic here
			//
			alphabet.appendLetter("a", "A", Letter.TYPE.OPEN);
			alphabet.appendLetter("b", "B", Letter.TYPE.CLOSE);
			alphabet.appendLetter("c", "C", Letter.TYPE.CLOSE);
			alphabet.appendLetter("ç", "Ç", Letter.TYPE.CLOSE);
			alphabet.appendLetter("d", "D", Letter.TYPE.CLOSE);
			alphabet.appendLetter("e", "E", Letter.TYPE.OPEN);
			alphabet.appendLetter("f", "F", Letter.TYPE.CLOSE);
			alphabet.appendLetter("g", "G", Letter.TYPE.CLOSE);
			alphabet.appendLetter("ð", "Ð", Letter.TYPE.CLOSE);
			alphabet.appendLetter("h", "H", Letter.TYPE.CLOSE);
			alphabet.appendLetter("ý", "I", Letter.TYPE.OPEN);
			alphabet.appendLetter("i", "Ý", Letter.TYPE.OPEN);
			alphabet.appendLetter("j", "J", Letter.TYPE.CLOSE);
			alphabet.appendLetter("k", "K", Letter.TYPE.CLOSE);
			alphabet.appendLetter("l", "L", Letter.TYPE.CLOSE);
			alphabet.appendLetter("m", "M", Letter.TYPE.CLOSE);
			alphabet.appendLetter("n", "N", Letter.TYPE.CLOSE);
			alphabet.appendLetter("o", "O", Letter.TYPE.OPEN);
			alphabet.appendLetter("ö", "Ö", Letter.TYPE.OPEN);
			alphabet.appendLetter("p", "P", Letter.TYPE.CLOSE);
			alphabet.appendLetter("q", "Q", Letter.TYPE.CLOSE);
			alphabet.appendLetter("r", "R", Letter.TYPE.CLOSE);
			alphabet.appendLetter("s", "S", Letter.TYPE.CLOSE);
			alphabet.appendLetter("þ", "Þ", Letter.TYPE.CLOSE);
			alphabet.appendLetter("t", "T", Letter.TYPE.CLOSE);
			alphabet.appendLetter("u", "U", Letter.TYPE.OPEN);
			alphabet.appendLetter("ü", "Ü", Letter.TYPE.OPEN);
			alphabet.appendLetter("v", "V", Letter.TYPE.CLOSE);
			alphabet.appendLetter("w", "W", Letter.TYPE.CLOSE);
			alphabet.appendLetter("x", "X", Letter.TYPE.CLOSE);
			alphabet.appendLetter("y", "Y", Letter.TYPE.CLOSE);
			alphabet.appendLetter("z", "Z", Letter.TYPE.CLOSE);
		}

		public ArrayList getWordSyllabus(string Word)
		{
			ArrayList	syl;
			int			pos;
			int			posStart;
			int			posNextOpen;
			int			posNextClose;
			string		nextOpenLetter;
			string		nextCloseLetter;
			string		currentLetter;
			string		currentSyl;
			string		newWord;
			bool		nextOpenFound;
			bool		nextCloseFound;
			bool		finished;

			syl					= new ArrayList();
			currentSyl			= "";
			posStart			= 0;
			pos					= 0;
			finished			= false;

			//newWord = getPureText(Word);
			newWord = Word;

			while (!finished && pos < newWord.Length)
			{
				currentLetter = newWord.Substring(pos, 1);

				// Alfabede olmayan harfleri (garip karakterler de olabilir) doðrudan dahil edelim
				if (!alphabet.letterExists(currentLetter))
				{
					currentSyl += currentLetter;
					pos++;
				}
				else
				{
					// Eðer sesli harf söz konusuysa...
					if (alphabet.getLetterType(currentLetter) == Letter.TYPE.OPEN)
					{
						// Eðer sesli harf kelimenin sonunda ise, bitirebiliriz
						if (pos == newWord.Length - 1)
						{
							currentSyl = newWord.Substring(posStart, newWord.Length - posStart);
							syl.Add(currentSyl);
							currentSyl = "";
							finished = true;
						}
						// Sesli harf kelimenin sonunda deðilse...
						else
						{
							// Bir sonraki sesli harfi bulalým
							nextOpenFound	= false;
							posNextOpen		= 0;
							for (int n = pos + 1; n < newWord.Length; n++)
							{
								nextOpenLetter = newWord.Substring(n, 1);

								if (!nextOpenFound && alphabet.getLetterType(nextOpenLetter) == Letter.TYPE.OPEN)
								{
									nextOpenFound	= true;
									posNextOpen		= n;
								}
							}

							// Eðer bir sonraki sesli harf bulunduysa...
							if (nextOpenFound)
							{
								// Hemen bir sonraki sesli harfi ise (þampUAn gibi)
								if (posNextOpen == pos + 1)
								{
									posNextClose = posNextOpen;
								}
									// Aksi takdirde...
								else
								{
									// Bir sonraki sesli harften önce gelen ilk sessiz harfi bulalým
									nextCloseFound	= false;
									posNextClose	= 0;
									for (int n = posNextOpen; n >= 0; n--)
									{
										nextCloseLetter = newWord.Substring(n, 1);

										if (!nextCloseFound && alphabet.getLetterType(nextCloseLetter) == Letter.TYPE.CLOSE)
										{
											nextCloseFound	= true;
											posNextClose	= n;
										}
									}
								}

								// Artýk hecemizin biteceði ve bir sonraki hecenini baþlayacaðý yerleri biliyoruz
								if (posNextClose >= 1)
								{
									currentSyl	= newWord.Substring(posStart, posNextClose - posStart);
									syl.Add(currentSyl);
									currentSyl = "";
								}
								posStart	= posNextClose;			
								pos			= posNextClose;
							}
							// Eðer bir sonraki sesli harf bulunmadýysa, kelimenin son hecesindeyiz
							else
							{
								currentSyl = newWord.Substring(posStart, newWord.Length - posStart);
								syl.Add(currentSyl);
								currentSyl = "";
								finished = true;
							}

						}
					}
					// Eðer sessiz harf söz konusuysa...
					else
					{
						currentSyl += currentLetter;
						pos++;
					}
				}
			}

			// Sesli harfle bitmediyse, artýklarý son hece olarak ekleyelim
			if (!finished)
			{
				try
				{
					//currentSyl	= newWord.Substring(posStart, newWord.Length - 1);
				}
				catch {}

				syl.Add(currentSyl);
			}

			return syl;
		}

		public ArrayList getTextSyllabus(string Text)
		{
			ArrayList	syl;
			ArrayList	word;
			string		currentWord;
			string		currentLetter;
			int			pos;

			word = new ArrayList();
			currentWord = "";
			for (pos = 0; pos < Text.Length; pos++)
			{
				currentLetter = Text.Substring(pos, 1);

				if (currentLetter == " ")
				{
					if (currentWord.Length > 0)
					{
						syl = getWordSyllabus(currentWord);
						for (int n = 0; n < syl.Count; n++)
						{
							word.Add(syl[n].ToString());
						}
						currentWord = "";
						word.Add(" ");
					}
				}
				else
				{
					currentWord += currentLetter;
				}
			}

			if (currentWord.Length > 0)
			{
				syl = getWordSyllabus(currentWord);
				for (int n = 0; n < syl.Count; n++)
				{
					word.Add(syl[n].ToString());
				}
			}

			return word;
		}
		public string removeSpecialCharacters(string Text)
		{
			string s = Text;
			s = s.Replace("ý", "i");
			s = s.Replace("ð", "g");
			s = s.Replace("Ð", "G");
			s = s.Replace("ü", "u");
			s = s.Replace("Ü", "U");
			s = s.Replace("þ", "s");
			s = s.Replace("Þ", "S");
			s = s.Replace("Ý", "GI");
			s = s.Replace("ö", "o");
			s = s.Replace("Ö", "O");
			s = s.Replace("ç", "c");
			s = s.Replace("Ç", "C");
			return s;
		}
	}
}

