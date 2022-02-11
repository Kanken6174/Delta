
using Game.Model.observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.loops{
    public class LoopsManager {

        public LoopsManager() {
        }

        private List<TimedLoop> loops;



        /// <summary>
        /// @param subscriber 
        /// @param period
        /// </summary>
        public void Schedule(ISubscriber subscriber, int period) {
            // TODO implement here
        }

        public void StopAll() {
            // TODO implement here
        }

        public void StartAll() {
            // TODO implement here
        }

    }
}