using Game.Model.Entity.Projectiles;
using Game.Model.Weapons;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace monoDelta.Game.Model.Levels
{
    /// <summary>
    /// This static class will manage level-related operations
    /// </summary>
    public static class LevelManager
    {
        private static string levelFolderPath = @".\level\";

        public static Level CurrentLevel = new Level();

        private static List<Level> _levels = new List<Level>(); //list of the levels loaded by the game

        public static void serializeCurrentLevel()
        {
            string fileName = levelFolderPath + CurrentLevel.LevelName + ".json";
            //string jsonObj = JsonSerializer.Serialize(CurrentLevel);
            string jsonObj = JsonConvert.SerializeObject(CurrentLevel, Formatting.Indented,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
            if (!Directory.Exists(levelFolderPath))
                Directory.CreateDirectory(levelFolderPath);
            if (File.Exists(fileName))
                File.Delete(fileName);
            var fileStream = File.Create(fileName);
            fileStream.Close();
            File.WriteAllText(fileName, jsonObj);
        }
        /// <summary>
        /// will load every level in the level folder into _levels
        /// </summary>
        /// <param name="game"></param>
        public static void loadAllLevels(Microsoft.Xna.Framework.Game game)
        {
            foreach (string levelname in Directory.GetFiles(levelFolderPath))
            {
                _levels.Add(JsonConvert.DeserializeObject<Level>(File.ReadAllText(levelname), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects })); ;
            }

            foreach (Level level in _levels)
            {
                foreach (Gun gun in level.PossibleWeapons)
                {
                    gun.ReArmDefault(game);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> all levels in a list of levels</returns>
        public static List<Level> getAllLevels()
        {
            return _levels;
        }
    }
}
