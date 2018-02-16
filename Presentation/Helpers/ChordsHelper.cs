using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Drawing;

namespace Gitarist.Helpers
{
    
    
    public static class ChordsHelper
    {

       // private static string allChordsTemplate = "_bm9|_b7/6|_b7sus4|_bdim7|_bm7|_bm6|_b6|_b9|_bsus4|_bmaj7|_bdim|_bdim7|_bm|_b+|_b|_m9|_#m9|_#9|_9|_#7/6|_7/6|_#7sus4|_#sus4|_7sus4|_#dim6|_#dim|_#dim7|_dim6|_dim7|_dim|_#m9|_#+|_+|_sus4|_maj7|_add9|_m7|_m6|_#m|_#m6|_#7|_#6|_#|_m6|_7|_6|_m|_";
   
        // private static string allChordsTemplate = "_m7|_m6|_#m|_#m6|_#7|_#6|_#|_m6|_7|_6|_m|_";

        private static string allChords;

        private static string custom = "_add9|";
        private static string sus = "_b7sus4|_#7sus4|_#sus4|_7sus4|_bsus4|_sus4|";

        private static string maj = "_maj9|_maj7|_maj6|_maj|";
        private static string dimsAndSharps = "_#dim9|_#dim7|_#dim6|_#dim|";
        private static string bemolsAndDims = "_bdim9|_bdim7|_bdim6|_bdim|";
        private static string dims = "_dim9|_dim7|_dim6|_dim|";
        private static string sharpsAndMinorsAndCifres = "_#m9|_#m7|_#m6|";
        private static string minorsAndCifres = "_m9|_m7|_m6|";
        private static string sharpsAndCifres = "_#9|_#7|_#6|";
        private static string bemols = "_b7sus4|_bsus4|_7sus4|_bsus4|";
        private static string sharpsMinors = "_#m|";
        private static string sharps = "_#|";
        private static string minorsPlus = "_m+|";
        private static string minors = "_m|";
        private static string cifres = "_9|_7|_6|";
        private static string plus = "_+|";
        private static string clear = "_|";


        private static string allChordsTemplate =
        custom +
        sus +
        maj +
        bemolsAndDims +
        dimsAndSharps +
        dims +
        sharpsAndMinorsAndCifres +
        minorsAndCifres +
        sharpsAndCifres +
        bemols +
        sharpsMinors +
        sharps +
        minorsPlus +
        minors +
        cifres +
        plus+
        clear;
      
        private static void GenerateChodsList()
        {
            string notes = "CDEFGAHB";
            allChords = "";
            foreach (char note in notes)
                allChords += allChordsTemplate.Replace('_', note);
           
            allChords = allChords.TrimEnd('|');
            allChords = string.Format("({0})",allChords)+"{1}";
        }
      
        static ChordsHelper()
        {
            ChordsHelper.GenerateChodsList();
          //  ChordsHelper.CutChordsImages();
        }

        public static MvcHtmlString FrameChords(this HtmlHelper helper, string chordsString)
        {
           
            var  result = Regex.Replace(chordsString, allChords, "<b class=\"chord\">$1</b>");

            result = Regex.Replace(result, @"(<b class=""chord"">)([\w#]+)(</b>)([\w])", "$2$4");
            
            return new MvcHtmlString(result);
        }

        public static string GetKeyChordKeySongName(this HtmlHelper helper,string songName)
        {
            Regex regex = new Regex("\\[(.+)\\]");
            var matches =  regex.Matches(songName);
            if (matches.Count==1)
                return "data-key=" +matches[0].Value.TrimStart('[').TrimEnd(']');
            else
                return "";
        }

        public static string ReplaceChordsHToB(string chords)
        {
           string HChords = allChordsTemplate.Replace("_", "H");
         
           HChords = HChords.TrimEnd('|');
           HChords = string.Format(" ({0}[ |\r|\n])", HChords);

            Regex regex = new Regex(HChords);

            foreach (Match match in regex.Matches(chords))
                RemoveHAtPosition(ref chords, match.Index);

            return chords;
        }

        private static void RemoveHAtPosition(ref string chords, int position)
        {
            string result = "";
            result = chords.Substring(0, position + 1) + "B" + chords.Substring(position + 2);
            chords = result;
        }


        public static string[] GetSongChords(string chordsString)
        {
            string notes = "CDEFGAHB";
            string allChords = "";
            foreach (char note in notes)
                allChords += allChordsTemplate.Replace('_', note);
            
            allChords = allChords.TrimEnd('|');
            allChords = string.Format("({0})",allChords)+"{1}";

            
           var regex = new Regex(allChords);
           var matches = regex.Matches(chordsString);
           
           string[] songChords = new string[matches.Count];
           int i=0;
           foreach(Match match in matches)
               songChords[i++] = match.Value;

           return songChords.Distinct().ToArray();
 
        }


        private static void CutChordsImages()
        {
            string notes = "CDEFGAHB";
            
            var pathToChords = System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/Chords/");


            foreach (char note in notes)
            {
                var curentNotePath = pathToChords + note+"\\";

                var files = System.IO.Directory.GetFiles(curentNotePath,"*.jpg");

                foreach(var file in files)
                {
                    
                    Bitmap src = Image.FromFile(file) as Bitmap;
                    if (src.Size.Height == 150 && src.Size.Width == 296) 
                    {
                        Rectangle cropRect = new Rectangle(76,0,220, 150);

                        Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

                        using(Graphics g = Graphics.FromImage(target))
                        {
                           g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), 
                                            cropRect,                        
                                            GraphicsUnit.Pixel);
                        }
                        src.Dispose();
                        src = null;
                        target.Save(file);
                    }
                    
                }


                
            }

           
        }

    }
}