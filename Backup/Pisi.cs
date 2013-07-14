using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dialector
{
    public class Pisi : Dialect
    {
        private Util u;
        public Turkish language;

        public Pisi()
        {
            u = new Util();
            language = new Turkish();
        }

        #region Dialect Members

        public string getDialect(string Text)
        {
            ArrayList alMain;
            bool tagOpen;
            bool wordModified = false;
            bool firstSyl = true;
            int sylPos;
            string curSyl;
            string strRet = "";

            alMain = new ArrayList();
            alMain = language.getTextSyllabus(Text);

            tagOpen = false;
            for (sylPos = 0; sylPos < alMain.Count; sylPos++)
            {
                curSyl = alMain[sylPos].ToString().ToLower();

                if (!wordModified)
                {
                    // sabun => pisiabun
                    if (!wordModified && curSyl.Length >= 2 && 
                        curSyl.Substring(0, 1) == "s" && 
                        language.alphabet.getLetterType(curSyl.Substring(1, 1)) == Letter.TYPE.OPEN &&
                        (
                        curSyl.Substring(1, 1) == "a" || curSyl.Substring(1, 1) == "e" || curSyl.Substring(1, 1) == "i" || curSyl.Substring(1, 1) == "ö" || curSyl.Substring(1, 1) == "ü" 
                        )
                       )
                    {
                        if (curSyl.Substring(1, 1) != "i")
                        {
                            curSyl = "pisi" + curSyl.Substring(1, curSyl.Length - 1);
                        }
                        else
                        {
                            curSyl = "pis" + curSyl.Substring(1, curSyl.Length - 1);
                        }
                        wordModified = true;
                    }

                    // performans => mýrformans
                    if (!wordModified && firstSyl && curSyl.Length >= 3 && language.alphabet.getLetterType(curSyl.Substring(0, 1)) == Letter.TYPE.CLOSE && language.alphabet.getLetterType(curSyl.Substring(1, 1)) == Letter.TYPE.OPEN && curSyl.Substring(2, 1) == "r")
                    {
                        curSyl = "mýr" + curSyl.Substring(3, curSyl.Length - 3);
                        wordModified = true;
                    }

                    // That's all!
                    alMain[sylPos] = curSyl;
                }

                if (curSyl == " ")
                {
                    wordModified = false;
                    firstSyl = true;
                }
                else
                {
                    firstSyl = false;
                }
            }

            // Metnimizi oluþturalým
            strRet = "";
            for (sylPos = 0; sylPos < alMain.Count; sylPos++)
            {
                strRet += alMain[sylPos].ToString();
            }

            // Son ayarlar
            u.replaceText(ref strRet, "edi", "kedi", false, false);
            u.replaceText(ref strRet, "kisi", "pisi", true, false);
            u.replaceText(ref strRet, "kiþi", "pisi", true, false);
            u.replaceText(ref strRet, "pr", "mýr", false, false);
            u.replaceText(ref strRet, "!", " mau!", false, false);

            // Döndürelim
            return strRet;
        }

        #endregion
    }
}
