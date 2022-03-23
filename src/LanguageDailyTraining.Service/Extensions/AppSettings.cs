namespace LanguageDailyTraining.Service.Extensions
{
    public class AppSettings
    {
        // encryption key
        public string Secret { get; set; }

        // token valid time in hours
        public int HoursExpiration { get; set; }

        // issuer application
        public string Issuer { get; set; }

        // valid urls 
        public string ValidOn { get; set; }
    }
}
