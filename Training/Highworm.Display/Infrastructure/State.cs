namespace Highworm.Displays {
    public class State {
        /// <summary>
        /// The currently set state
        /// </summary>
        public string Current {
            get;
            set;
        }

        /// <summary>
        /// The starting default state
        /// </summary>
        public string Start {
            get;
            set;
        }

        /// <summary>
        /// Set the current state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public void To(string state) {
            Current = state;
        }

        public State Set(string state) {
            Current = Start = state; return this;
        }

        public void Empty() {
            Current = Start;
        }
    }
}