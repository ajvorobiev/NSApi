namespace NSApiForge
{
    using System;
    using System.IO;
    using System.Reflection;

    using Newtonsoft.Json;
    
    /// <summary>
    /// The settings manager.
    /// </summary>
    public class SettingsManager
    {
        /// <summary>
        /// The instance.
        /// </summary>
        private static SettingsManager instance = null;

        /// <summary>
        /// The settings file name
        /// </summary>
        private string settingsFileName = "settings.json";

        /// <summary>
        /// Prevents a default instance of the <see cref="SettingsManager"/> class from being created.
        /// </summary>
        private SettingsManager()
        {
            this.LoadSettings();
        }

        /// <summary>
        /// Gets the assembly directory.
        /// </summary>
        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static SettingsManager Instance
        {
            get
            {
                return instance ?? (instance = new SettingsManager());
            }
        }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        public Settings Settings { get; set; }

        /// <summary>
        /// Gets or sets the full path to settings.
        /// </summary>
        public string FullPathToSettings
        {
            get
            {
                return Path.Combine(AssemblyDirectory, this.settingsFileName);
            }
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            if (!File.Exists(this.FullPathToSettings))
            {
                throw new FileNotFoundException("The settings.json file was not found!");
            }

            var settingsJson = File.ReadAllText(this.FullPathToSettings);

            if (string.IsNullOrEmpty(settingsJson))
            {
                throw new InvalidDataException("The settings file is empty.");
            }

            var settings = JsonConvert.DeserializeObject<Settings>(settingsJson);

            if (settings == null)
            {
                throw new JsonSerializationException("The settings file contains errors and cannot be deserialized.");
            }

            this.Settings = settings;
        }
    }
}
