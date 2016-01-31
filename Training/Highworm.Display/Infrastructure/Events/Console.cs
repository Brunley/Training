namespace Highworm {
    /// <summary>
    /// Indicates that the console read input.
    /// </summary>
    /// <param name="input">The text that was read.</param>
    public delegate void ConsoleReadEventHandler(string input);

    /// <summary>
    /// Indicates that the console read empty input.
    /// </summary>
    public delegate void ConsoleReadEmptyEventHandler();
}

namespace Highworm.Displays {
    /// <summary>
    /// Indicates that a <see cref="Highworm.Displays.View"/> is
    /// ready to be drawn to the screen.
    /// </summary>
    /// <param name="view">The <see cref="Highworm.Displays.View"/> to be drawn.</param>
    public delegate void ConsolePaintEventHandler(View view);
}