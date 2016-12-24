/* Responder.cs, v 1.0 23/12/2016 rana */
/* Future work: small talk, open help section */
/* Bug: private string getFirstWord(string input), input = " search", output = "arch" */
/* Note:  private void readFiles(), writes to console if catches an exception */
using System;
using System.IO;
using System.Collections.Generic;

namespace CS319_Genius
{
    class Responder
    {
        public enum JobType
        {
            LAUNCH,     // create launcher with jobDetail
            KILL,       // create killer with jobDetail
            GOOGLE,     // create googleSearch with jobDetail
            WIKI,       // create wikiSearch with jobDetail
            IDLE        // do nothing
        };

        private enum Key
        {
            NONE,
            LAUNCH = 1,
            START = 1,
            OPEN = 1,
            EXECUTE = 1,
            KILL = 5,
            END = 5,
            STOP = 5,
            CLOSE = 5,
            SEARCH = 9
        };

        private enum Status
        {
            NONE,
            NONCOMMAND = 1,
            FULLJOB = 2,
            HALFJOB = 3
        };

        private enum Engine
        {
            NONE,
            GOOGLE = 1,
            WIKI = 2,
            WIKIPEDIA = 2
        };

        private string fileName = "responder.txt";
        private string response;
        private string detail;
        private short searchPreference;
        private JobType type;
        private List<string> jobMessages;
        private List<string> errorMessages;
        private List<string> warningMessages;

        public Responder()
        {
            response = "";
            type = JobType.IDLE;
            detail = "";
            searchPreference = 0;
            jobMessages = new List<string>();
            errorMessages = new List<string>();
            warningMessages = new List<string>();
            readFiles();
        }

        public string respond(string input)
        {
            Status status;
            status = understandCommand(input);
            generateResponse(status, input);
            return response;
        }

        public string error(Responder.JobType jobType, string jobDetail)
        {
            int jobValue;
            jobValue = Array.IndexOf(Enum.GetValues(jobType.GetType()), jobType);
            if (jobValue > 3 || jobValue < 0)
            {
                response = "";
            }
            response = errorMessages[jobValue] + " " + jobDetail + ".";
            return response;
        }

        public Responder.JobType getJobType()
        {
            return type;
        }

        public String getJobDetail()
        {
            return detail;
        }

        public void setSearchPreference(short input)
        {
            searchPreference = input;
        }

        // private methods
        private Responder.Status understandCommand(string input)
        {
            string first;
            string second;
            string third;
            string current;
            Key keyName;
            Engine engineName;
            int keyValue;
            int engineValue;
            bool engineStatus;

            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                type = JobType.IDLE;
                detail = "";
                return Status.NONE;
            }
            first = getFirstWord(input);
            first = first.ToUpperInvariant();
            if (string.IsNullOrEmpty(first) || string.IsNullOrWhiteSpace(first))
            {
                type = JobType.IDLE;
                detail = "";
                return Status.NONE;
            }
            try
            {
                keyName = (Key)Enum.Parse(typeof(Key), first);
                if (Enum.IsDefined(typeof(Key), keyName))
                {
                    // key found
                    current = removeFirstWord(input);
                    if (string.IsNullOrEmpty(current) || string.IsNullOrWhiteSpace(current))
                    {
                        type = JobType.IDLE;
                        detail = "";
                        return Status.HALFJOB;
                    }
                    second = getFirstWord(current);
                    second = second.ToUpperInvariant();
                    if (string.IsNullOrEmpty(second) || string.IsNullOrWhiteSpace(second))
                    {
                        // half job
                        type = JobType.IDLE;
                        detail = "";
                        return Status.HALFJOB;
                    }
                    else
                    {
                        keyValue = Array.IndexOf(Enum.GetValues(keyName.GetType()), keyName);
                        switch (keyValue)
                        {
                            case 1: // launch
                                type = JobType.LAUNCH;
                                detail = current;
                                return Status.FULLJOB;
                            case 5: // kill
                                type = JobType.KILL;
                                detail = current;
                                return Status.FULLJOB;
                            case 9: // search
                                try
                                {
                                    engineName = (Engine)Enum.Parse(typeof(Engine), second);
                                    if (Enum.IsDefined(typeof(Engine), engineName))
                                    {
                                        // engine found
                                        current = removeFirstWord(current);
                                        third = getFirstWord(current);
                                        if (string.IsNullOrEmpty(third) || string.IsNullOrWhiteSpace(third))
                                        {
                                            return Status.HALFJOB;
                                        }
                                        else
                                        {
                                            engineValue = Array.IndexOf(Enum.GetValues(engineName.GetType()), engineName);
                                            if (engineValue == 1)
                                            {
                                                type = JobType.GOOGLE;
                                            }
                                            else if (engineValue == 2)
                                            {
                                                type = JobType.WIKI;
                                            }
                                            detail = current;
                                            return Status.FULLJOB;
                                        }
                                    }
                                    else
                                    {
                                        // engine not found
                                        if (engineStatus = checkSearchPreference())
                                        {
                                            detail = current;
                                            return Status.FULLJOB;
                                        }
                                        else
                                        {
                                            return Status.HALFJOB;
                                        }
                                    }
                                }
                                catch (ArgumentException)
                                {
                                    // engine not found
                                    if (engineStatus = checkSearchPreference())
                                    {
                                        detail = current;
                                        return Status.FULLJOB;
                                    }
                                    else
                                    {
                                        return Status.HALFJOB;
                                    }
                                }
                            default:
                                type = JobType.IDLE;
                                detail = "";
                                return Status.NONCOMMAND;
                        }
                    }
                }
                else
                {
                    type = JobType.IDLE;
                    detail = "";
                    return Status.NONCOMMAND;
                }
            }
            catch (ArgumentException)
            {
                type = JobType.IDLE;
                detail = "";
                return Status.NONCOMMAND;
            }
        }

        private void generateResponse(Responder.Status status, string input)
        {
            int statusValue;
            int jobValue;

            statusValue = Array.IndexOf(Enum.GetValues(status.GetType()), status);
            jobValue = Array.IndexOf(Enum.GetValues(type.GetType()), type);
            switch (statusValue)
            {
                case 1:  // non-command
                    if (!smallTalk(input))
                    {
                        // did not understand
                        response = warningMessages[0];
                    }
                    break;
                case 2:  // full job
                    response = jobMessages[jobValue] + " " + detail + ".";
                    break;
                case 3:  // half job
                    response = warningMessages[1];
                    break;
                default: // none
                    response = "";
                    break;
            }
        }

        private bool smallTalk(string input)
        {
            return false;
        }

        private string getFirstWord(string input)
        {
            int index;
            string temp;

            if (input == null)
            {
                return null;
            }
            temp = input.Trim();
            index = temp.IndexOf(' ');
            if (index != -1)
            {
                return temp.Substring(0, index).Trim();
            }
            else
            {
                return temp;
            }
        }

        private string removeFirstWord(string input)
        {
            int index;
            string temp;

            temp = input.Trim();
            index = temp.IndexOf(' ');
            if (index != -1)
            {
                return input.Substring(index).Trim();
            }
            else
            {
                return null;
            }
        }

        private bool checkSearchPreference()
        {
            switch (searchPreference)
            {
                case 0: // no engine
                    return false;
                case 1: // google
                    type = JobType.GOOGLE;
                    return true;
                case 2: // wikipedia
                    type = JobType.WIKI;
                    return true;
                default:
                    return false;
            }
        }

        private void readFiles()
        {
            string line;
            StreamReader file;
            int count = 0;

            file = new StreamReader(fileName);
            try
            {
                using (file)
                {
                    // job messages
                    line = file.ReadLine();
                    count = Int32.Parse(line);
                    for (int i = 0; i < count; i++)
                    {
                        line = file.ReadLine();
                        jobMessages.Add(line);
                    }
                    // error messages
                    line = file.ReadLine();
                    count = Int32.Parse(line);
                    for (int j = 0; j < count; j++)
                    {
                        line = file.ReadLine();
                        errorMessages.Add(line);
                    }
                    // warning messages
                    line = file.ReadLine();
                    count = Int32.Parse(line);
                    for (int k = 0; k < count; k++)
                    {
                        line = file.ReadLine();
                        warningMessages.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                // file error
                Console.WriteLine("responder.txt file error:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
