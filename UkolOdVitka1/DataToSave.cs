using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkolOdVitka1
{
    class DataToSave
    {
        public string Time {
            get {return GetDayTime().ToString();  }
            set {; }
        }
        public string Function { get; set; }
        public int Number {
            get { return GetRandomNumber(0, 500); }
            set { ; } 
        }
        private DateTime dateTime = new DateTime();
        
        public string GetDayTime()
        {
            DateTime date = DateTime.Now;

            return date.ToString();
        }
        private  Random random = new Random();
        public int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
        
        public DataToSave (string _function)
        {
            this.Function = _function;
        }
        public override string ToString()
        {
            return String.Format("{0} : {1} : {2}", Function, Time, Number);
        }
    }

   
}
