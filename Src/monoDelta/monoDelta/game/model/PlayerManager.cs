using Game.Model.Player;

namespace monoDelta.Game.Model
{
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
