using System.Collections.Generic;

namespace Task.Application.Models.Common
{
    public class EmailRequestMultipleRecipients
    {
        public List<string> Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public List<string> Attachments { get; set; }
     
    }
}
