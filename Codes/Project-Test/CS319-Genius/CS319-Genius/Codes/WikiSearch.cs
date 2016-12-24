using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CS319_Genius.Codes
{
    class WikiSearch : Job
    {
        public delegate void resultString(string resultString);
        public event resultString resString;

        // @Meder, check this page for further information 
        // https://www.mediawiki.org/wiki/API:Main_page
        // You have to handle with multiple choice queries. So reading documentation can be really helpful. 
        // This is just an example you probably need to change it. 

        private string searchUrlHead = "https://en.wikipedia.org/w/api.php?action=query&titles=";
        private string searchUrlLast = "&prop=revisions&rvprop=content&format=json";


        /// Simple usage of these two should be like that,
        /// str = String which user trying to search
        /// searchUrlHead + str + searchUrlLast 
        /// We already passing str and assign it to parameter " keyWord ". So you can use that directly. 

        // You don't need to touch here for now. If you want to add something, go ahead.
        public WikiSearch(Responder.JobType jobType, string inputWord) : base(jobType, inputWord)
        {
        }

        // Well.. You have to parse JSON as you already know.
        public override bool doJob() {
            string wordToSearch = this.keyWord;
            // Once you are done, you should call this resString( RESULTSTRING ); and you should return true
            string result = getResult(wordToSearch);
            if (result != null)
            {
                resString(result);
                return true;
            }
            return false;
        }

        public static String getResult(String token)
        {
            string resultString = "";
            string sURL;
            if (token == null)
            {

                return null;
            }
            sURL = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&explaintext=&titles=" + token;
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);



            wrGETURL.Proxy = WebProxy.GetDefaultProxy();

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();


            StreamReader objReader = new StreamReader(objStream);

            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    resultString += sLine; // Console.WriteLine("{0}:{1}", i, sLine);
            }

            return resultString;
        }


    }
}
