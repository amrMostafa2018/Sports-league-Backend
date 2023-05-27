namespace Task.Shared.Logging
{
    public class SerilogOptions 
    {
        public bool ConsoleEnabled { get; set; }
        public string LoggingFilePath { get; set; }
        public string Level { get; set; }
    }
}