using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamersfable_prototype.Classes
{
    public class Utils
    {
        public static string CutText(string text, int maxLength)
        {
            return (text.Length < maxLength || text == null) ? text : (text.Substring(0, maxLength) + "..."); 
        }
    }
}