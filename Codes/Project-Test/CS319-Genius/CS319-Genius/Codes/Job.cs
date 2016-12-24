using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS319_Genius.Codes
{
    class Job
    {
        protected Responder.JobType jobType;
        protected string keyWord;


        public Job(Responder.JobType typeJob, string inputWord)
        {
            jobType = typeJob;
            keyWord = inputWord;
        }

        public virtual bool doJob() {
            return true;
        }

        public string getKeyword() { return keyWord;  }

        public Responder.JobType getJobType() { return jobType; } 
    }
}
