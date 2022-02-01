
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.observable{
    public abstract class Observable {

        public Observable() {
        }

        private List<Subscriber> subscribers;


        /// <summary>
        /// @param subscriber
        /// </summary>
        public void subscribe(Subscriber subscriber) {
            // TODO implement here
        }

        /// <summary>
        /// @param subscriber
        /// </summary>
        public void unsubscribe(Subscriber subscriber) {
            // TODO implement here
        }

    }
}