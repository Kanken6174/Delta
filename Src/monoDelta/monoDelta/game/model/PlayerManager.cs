using Game.Model.Player;

namespace monoDelta.Game.Model
{
    /// <summary>
    /// This static class is responsible for managing the current player
    /// </summary>
    public static class PlayerManager
    {
        private static Player player;

        public static Player GetPlayer()
        {
            return player;
        }

        public static void SetPlayer(Player p)
        {
            player = p;

        }

    }
}
