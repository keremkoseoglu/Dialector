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
			alphabet.appendLetter("�", "�", Letter.TYPE.CLOSE);
			alphabet.appendLetter("d", "D", Letter.TYPE.CLOSE);
			alphabet.appendLetter("e", "E", Letter.TYPE.OPEN);
			alphabet.appendLetter("f", "F", Letter.TYPE.CLOSE);
			alphabet.appendLetter("g", "G", Letter.TYPE.CLOSE);
			alphabet.appendLetter("�", "�", Letter.TYPE.CLOSE);
			alphabet.appendLetter("h", "H", Letter.TYPE.CLOSE);
			alphabet.appendLetter("�", "I", Letter.TYPE.OPEN);
			alphabet.appendLetter("i", "�", Letter.TYPE.OPEN);
			alphabet.appendLetter("j", "J", Letter.TYPE.CLOSE);
			alphabet.appendLetter("k", "K", Letter.TYPE.CLOSE);
			alphabet.appendLetter("l", "L", Letter.TYPE.CLOSE);
			alphabet.appendLetter("m", "M", Letter.TYPE.CLOSE);
			alphabet.appendLetter("n", "N", Letter.TYPE.CLOSE);
			alphabet.appendLetter("o", "O", Letter.TYPE.OPEN);
			alphabet.appendLetter("�", "�", Letter.TYPE.OPEN);
			alphabet.appendLetter("p", "P", Letter.TYPE.CLOSE);
			alphabet.appendLetter("q", "Q", Letter.TYPE.CLOSE);
			alphabet.appendLetter("r", "R", Letter.TYPE.CLOSE);
			alphabet.appendLetter("s", "S", Letter.TYPE.CLOSE);
			alphabet.appendLetter("�", "�", Letter.TYPE.CLOSE);
			alphabet.appendLetter("t", "T", Letter.TYPE.CLOSE);
			alphabet.appendLetter("u", "U", Letter.TYPE.OPEN);
			alphabet.appendLetter("�", "�", Letter.TYPE.OPEN);
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

				// Alfabede olmayan harfleri (garip karakterler de olabilir) do�rudan dahil edelim
				if (!alphabet.letterExists(currentLetter))
				{
					currentSyl += currentLetter;
					pos++;
				}
				else
				{
					// E�er sesli harf s�z konusuysa...
					if (alphabet.getLetterType(currentLetter) == Letter.TYPE.OPEN)
					{
						// E�er sesli harf kelimenin sonunda ise, bitirebiliriz
						if (pos == newWord.Length - 1)
						{
							currentSyl = newWord.Substring(posStart, newWord.Length - posStart);
							syl.Add(currentSyl);
							currentSyl = "";
							finished = true;
						}
						// Sesli harf kelimenin sonunda de�ilse...
						else
						{
							// Bir sonraki sesli harfi bulal�m
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

							// E�er bir sonraki sesli harf bulunduysa...
							if (nextOpenFound)
							{
								// Hemen bir sonraki sesli harfi ise (�ampUAn gibi)
								if (posNextOpen == pos + 1)
								{
									posNextClose = posNextOpen;
								}
									// Aksi takdirde...
								else
								{
									// Bir sonraki sesli harften �nce gelen ilk sessiz harfi bulal�m
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

								// Art�k hecemizin bitece�i ve bir sonraki hecenini ba�layaca�� yerleri biliyoruz
								if (posNextClose >= 1)
								{
									currentSyl	= newWord.Substring(posStart, posNextClose - posStart);
									syl.Add(currentSyl);
									currentSyl = "";
								}
								posStart	= posNextClose;			
								pos			= posNextClose;
							}
							// E�er bir sonraki sesli harf bulunmad�ysa, kelimenin son hecesindeyiz
							else
							{
								currentSyl = newWord.Substring(posStart, newWord.Length - posStart);
								syl.Add(currentSyl);
								currentSyl = "";
								finished = true;
							}

						}
					}
					// E�er sessiz harf s�z konusuysa...
					else
					{
						currentSyl += currentLetter;
						pos++;
					}
				}
			}

			// Sesli harfle bitmediyse, art�klar� son hece olarak ekleyelim
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
			s = s.Replace("�", "i");
			s = s.Replace("�", "g");
			s = s.Replace("�", "G");
			s = s.Replace("�", "u");
			s = s.Replace("�", "U");
			s = s.Replace("�", "s");
			s = s.Replace("�", "S");
			s = s.Replace("�", "GI");
			s = s.Replace("�", "o");
			s = s.Replace("�", "O");
			s = s.Replace("�", "c");
			s = s.Replace("�", "C");
			return s;
		}
	}
}

