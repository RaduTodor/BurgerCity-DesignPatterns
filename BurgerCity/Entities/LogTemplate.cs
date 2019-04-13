using System;

namespace BurgerCity.Entities
{
    public class LogTemplate
    {
        private String Date { get; set; }
        private String Time { get; set; }
        private String Message { get; set; }
        private String Exception { get; set; }

        public LogTemplate(String message)
        {
            Date = DateTime.Now.ToString("d");
            Time = DateTime.Now.ToString("T");
            Message = message;
            Exception = String.Empty;
        }

        public LogTemplate(String message, String exception) : this(message)
        {
            Exception = exception;
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Exception))
            {
                return string.Format(
                    "--------------------\n" +
                    "Date: {0}\n" +
                    "Time: {1}\n" +
                    "Message: {2}\n" +
                    "--------------------\n",
                    Date, Time, Message);
            }
            else
            {
                return string.Format(
                    "--------------------\n" +
                    "Date: {0}\n" +
                    "Time: {1}\n" +
                    "Exception Message: {2}\n" +
                    "Exception StackTrace: {3}\n" +
                    "--------------------\n",
                    Date, Time, Message, Exception);
            }
        }
    }
}
