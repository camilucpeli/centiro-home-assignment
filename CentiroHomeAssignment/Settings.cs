using System;

namespace CentiroHomeAssignment
{
    public class Settings
    {
        public string AppDataFolderPath { get; internal set; }

        public Settings()
        {
            AppDataFolderPath = Environment.CurrentDirectory + "\\App_Data";
        }
    }
}