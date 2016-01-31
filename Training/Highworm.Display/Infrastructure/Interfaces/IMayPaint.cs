namespace Highworm {
    /// <summary>
    /// Establishes a contract with an entity that may be painted to the screen.
    /// </summary>
    public interface IMayPaint {
        /// <summary>
        /// Used to compose the <see cref="System.Text.StringBuilder"/> content that
        /// will eventually be writen to the screen.
        /// </summary>
        /// <param name="displayState">
        /// The state of the <see cref="Highworm.Displays.Display"/>.
        /// </param>
        void Compose(string displayState);

        /// <summary>
        /// Indicates the current state of the view, and what
        /// states it is allowed to be painted in.
        /// </summary>
        Displays.View.State ViewState { get; set; }
    }
}