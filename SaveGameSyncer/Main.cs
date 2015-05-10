using System.IO;
using System.Reflection;
using UnityEngine;

namespace SaveGameSyncer
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class SaveGameSyncer: MonoBehaviour
    {
        public static readonly string SavePath = Path.GetFullPath(Path.Combine(KSPUtil.ApplicationRootPath, "saves"));

        private string SyncPath { get; set; }

        public void Awake()
        {   
            var syncCfgPath = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "sync.cfg");
            if (!File.Exists(syncCfgPath))
                File.WriteAllText(syncCfgPath, "");

            SyncPath = File.ReadAllText(syncCfgPath);

            // Recursively copy all saves from the sync folder on startup
            RecursiveCopy(SyncPath, SavePath);

            GameEvents.onGameStateSaved.Add(OnSave);
        }

        void OnSave(Game data)
        {
            // Recursively copy to sync folder on save
            RecursiveCopy(SavePath, SyncPath);
        }

        private static void RecursiveCopy(string from, string to)
        {
            if (from == null || "".Equals(from) || to == null || "".Equals(to))
            {
                Debug.LogWarning("Save game sync: Copy failed, source or destination directory is not set");
                return;
            }

            Debug.LogWarning("Save game sync: Copying from '" + from + "' to '" + to + "'");

            // Find all files
            var files = Directory.GetFiles(from, "*", SearchOption.AllDirectories);

            // Copy all the files
            foreach (var file in files)
            {
                var rel = file.Substring(from.Length);
                if (rel.StartsWith("/") || rel.StartsWith("\\"))
                    rel = rel.Substring(1);

                var dir = Directory.GetParent(file).FullName;
                var relDir = dir.Substring(from.Length);
                if (relDir.StartsWith("/") || relDir.StartsWith("\\"))
                    relDir = relDir.Substring(1);

                var targetDir = Path.Combine(to, relDir);
                if(!Directory.Exists(targetDir))
                    Directory.CreateDirectory(targetDir);

                File.Copy(Path.Combine(from, rel), Path.Combine(to, rel), true);
            }
        }
    }
}