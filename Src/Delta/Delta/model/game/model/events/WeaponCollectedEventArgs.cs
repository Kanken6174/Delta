
using game.model.weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.events{
    public class WeaponCollectedEventArgs : EventArgs {

        public WeaponCollectedEventArgs() {
        }

        public Gun collectedWeapon;

    }
}