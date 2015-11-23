using System;

namespace Module2HomeWork._9_task
{
    public sealed class ApplicationSettings
    {
        public static readonly ApplicationSettings Instance = new ApplicationSettings();

        public string userLanguage;
        public int countUser;
        public string databaseConnect;

        private ApplicationSettings()
        {
            this.userLanguage = "en";
            this.countUser = 2;
            this.databaseConnect = "localDB";
        }
    }
}