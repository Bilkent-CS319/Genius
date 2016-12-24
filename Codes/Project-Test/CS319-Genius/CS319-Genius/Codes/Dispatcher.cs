using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CS319_Genius.Codes
{
     class Dispatcher
    {
        // Interface manager for handling UI work.
        protected InterfaceManager interfaceObject;
        // Responder object for parsing exact commands
        private Responder responderObject;

        // Creating holder for Job List, so we can kill them from here easily.
        private List<Job> jobList;

        // For stroing output. i.e response from small talk.
        private string outputForUser = "";


        private bool debug = false;

        public Dispatcher()
        {
            jobList = new List<Job>();
            responderObject = new Responder();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            interfaceObject = new InterfaceManager();

            // Register for interface changes. For, obviously, getting user inputs.
            interfaceObject.inputEventTrigger += inputEventHandler;
            interfaceObject.searchSelectionChecker += İnterfaceObject_searchSelectionChecker;
        }

        private void İnterfaceObject_searchSelectionChecker(short selection)
        {
            responderObject.setSearchPreference(selection);
        }

        private void inputEventHandler(string input)
        {           
            // Get input from InterfaceManager
            Console.WriteLine("*DEBUG* You have new input from UI! = " + input);

            if (debug) { outputForUser = "Okay..."; interfaceObject.setOutput(outputForUser); understandJob(Responder.JobType.LAUNCH); return; }
            
            // Get user output. Might be anything, like "I'm launching it right away" etc...
            outputForUser = responderObject.respond(input);
            interfaceObject.setOutput(outputForUser);  // Set it. So user can also see this..

            Console.WriteLine("*DEBUG* Output that will go to user is : " + outputForUser);
            // Start doing process...
            understandJob(responderObject.getJobType());
        }


        // This is for understanding the job and doing it. Determine what you are going to do with the cases in your hand.
        private void understandJob(Responder.JobType jobType)
        {
            bool jobResult = false;
            Job tempJob = null;

            Console.WriteLine("*DEBUG* Incoming job type is : " + jobType.ToString());

            switch (jobType)
            {
                case Responder.JobType.GOOGLE:{
                        jobResult = true;
                        if (debug) Process.Start("https://www.google.com/search?q=" + "sucuk"); else
                            Process.Start("https://www.google.com/search?q=" + responderObject.getJobDetail().Replace(" ", "+"));
                        break;}
                case Responder.JobType.KILL:{
                        for (int i = 0; i < jobList.Count; i++)
                            if (jobList[i].getKeyword() == responderObject.getJobDetail()){
                                Console.WriteLine("Am I here? Job Exe Location: " + ((Launcher)(jobList[i])).getExeLocation());
                                jobResult = KillApplication( ((Launcher)(jobList[i])).getExeLocation());
                                jobList.RemoveAt(i);
                            }
                        break;}
                case Responder.JobType.LAUNCH:{
                        tempJob = new Launcher(jobType, responderObject.getJobDetail());
                        jobList.Add(tempJob);
                        if (debug) ((Launcher)tempJob).searchInFolders(); else jobResult = tempJob.doJob();
                        break;}
                case Responder.JobType.WIKI:{
                        WikiSearch wikiObject = new WikiSearch(jobType, responderObject.getJobDetail());
                        wikiObject.resString += wikiResultHandler;
                        jobResult = wikiObject.doJob();
                        tempJob = wikiObject;
                        break;}
                case Responder.JobType.IDLE:
                    {
                        jobResult = true;
                        break;
                    }
            }

            // If job result is negative, get error.
            if (!jobResult)
            {
                if (jobType == Responder.JobType.KILL )
                    interfaceObject.setOutput(responderObject.error(jobType, responderObject.getJobDetail()));
                else
                    interfaceObject.setOutput( responderObject.error(jobType, tempJob.getKeyword()));

                // If WIKI fails to find, let Google search it.
                if (jobType == Responder.JobType.WIKI)
                    understandJob(Responder.JobType.GOOGLE);
            }

        }

        private void wikiResultHandler(string resultString)
        {
            interfaceObject.setOutput(resultString);
        }

        public bool  KillApplication(string appName) {
            Process[] procs = null;
            appName = appName.Substring(0,appName.Length-4);
            Console.WriteLine("**INSIDE KILL** Appname is : "+ appName);
            try {

                foreach (var process in Process.GetProcessesByName(appName))
                {
                    Console.WriteLine("Found! Name : " + process.ProcessName);
                    process.Kill();
                    return true;
                }
            }
            catch (Exception e) { Console.WriteLine("CLOSE EXCEPTION " + e.ToString()); return false; }
            finally
            {
                if (procs != null){
                    foreach (Process p in procs){
                        p.Dispose();
                    }
                }
            }

            return false;
        }

        // I wouldn't recommend any of you to change this main part if you know what you are doing. So guys, Meder Said and Rana
        // please don't touch here even for the test.
        [STAThread]
        static void Main()
        {
            Dispatcher dispatcherObject = new Dispatcher();       
            Application.Run(dispatcherObject.interfaceObject);
        }

    }
}
