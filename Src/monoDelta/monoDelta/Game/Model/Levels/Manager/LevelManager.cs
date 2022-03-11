using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace monoDelta.Game.Model.Levels
{
    public static class LevelManager
    {
        private static string levelFolderPath = @".\level\";

        public static Level CurrentLevel = new Level();

        private static List<Level> _levels = new List<Level>();

        public static void serializeCurrentLevel()
        {
            string fileName = levelFolderPath + CurrentLevel.LevelName+".json";
            string jsonObj = JsonSerializer.Serialize(CurrentLevel);
            if(!Directory.Exists(levelFolderPath))
                Directory.CreateDirectory(levelFolderPath);
            if (File.Exists(fileName))
                File.Delete(fileName);
            var fileStream = File.Create(fileName);
            fileStream.Close();
            File.WriteAllText(fileName, jsonObj);
        }

        public static void loadAllLevels()
        {
            foreach(string levelname in Directory.GetFiles(levelFolderPath))
            {
                _levels.Add(JsonSerializer.Deserialize<Level>(File.ReadAllText(levelFolderPath+levelname)));
            }
        }

        public static List<Level> getAllLevels()
        {
            return _levels;
        }
    }
}
