using System;
using System.Collections.Generic;
using System.Text;

namespace Dialector
{
    public class Kufurbaz : Dialect
    {
        #region Dialect Members

        private int
            n0 = 0,
            n1 = 0,
            n2 = 0;

        public string getDialect(string Text)
        {
            string s = "";
            string cur, pre = "", mod;
            bool newSent = true;
            bool tagClose = true;

            for (int n = 0; n < Text.Length; n++)
            {
                cur = Text.Substring(n, 1);
                mod = cur;

                if (n > 0)
                {
                    switch (cur)
                    {
                        case "<":
                            tagClose = false;
                            break;
                        case ">":
                            tagClose = true;
                            break;
                        case ".":
                            if (tagClose && newSent && pre != ".") mod = getCurse(0) + ".";
                            newSent = true;
                            break;
                        case "!":
                            if (tagClose && newSent) mod = getCurse(0) + "!";
                            newSent = true;
                            break;
                        case ",":
                            if (tagClose && newSent) mod = getCurse(1) + ",";
                            newSent = false;
                            break;
                        /*case ";":
                            if (tagClose && newSent) mod = getCurse(1) + ";";
                            newSent = false;
                            break;*/
                        case "?":
                            if (tagClose && newSent) mod = getCurse(2) + "?";
                            newSent = true;
                            break;
                    }
                }

                s += mod;
                pre = cur;
            }

            return s;
        }

        private string getCurse(int Type)
        {

            switch (Type)
            {
                case 0:
                    n0++;
                    if (n0 > 4) n0 = 1;
                    switch (n0)
                    {
                        case 1: return ""; 
                        case 2: return " ulan";
                        case 3: return " mýna koyim";
                        case 4: return " agzina ziciim"; 
                    }
                    break;
                case 1:
                    n1++;
                    if (n1 > 3) n1 = 1;
                    switch (n1)
                    {
                        case 1: return "";
                        case 2: return " avradini zkim";
                        case 3: return " g.tune koyim";
                    }
                    break;
                case 2:
                    n2++;
                    if (n2 > 4) n2 = 1;
                    switch (n2)
                    {
                        case 1: return "";
                        case 2: return " anasýný zktiminin";
                        case 3: return " zkik";
                        case 4: return " agzina zictiiminin";
                    }
                    break;
            }

            return "";
        }

        #endregion
    }
}
