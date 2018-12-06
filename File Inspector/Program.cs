using System;
using System.Reflection;
using System.Windows.Forms;
using EdUtils.Filesystem;
using File_Inspector.Common;
using NLog;

namespace File_Inspector
{
    public static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /* Set up the logging framework */
            Logging.Initialize();
            logger.Info("Application started");
            logger.Info("App Version: {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            logger.Info("Portable Mode: {0}", AppFolders.PortableMode);
            logger.Info("Base Working Directory: {0}", AppFolders.BaseWorkingFolder);

            /* Ensure that required working folders are present */
            AppFolders.CreateWorkingFolders();

            if (args.Length >= 1)
            {
                Application.Run(new FileInspector(args[0]));
            }
            else
            {
                Application.Run(new FileInspector());
            }
        }
    }
}
