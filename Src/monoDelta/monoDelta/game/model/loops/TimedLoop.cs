
using game.model.observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.loops{
    public abstract class TimedLoop : Observable {

        public TimedLoop() {
        }

        private int period;


        public abstract void Start();

        public abstract void Stop();

    }
}