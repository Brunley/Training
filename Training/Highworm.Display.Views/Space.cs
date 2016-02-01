using Highworm.Displays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Highworm.Display.Views
{
    /// <summary>
    /// This should display a blank space, for better spacing.
    /// </summary>
    public class space : View<string>
    {
        /// <summary>
        /// The printable component's output text.
        /// </summary>
        /// <returns>
        /// A string to write at the component's cursor position.
        /// </returns>

        public override void Compose(string displayState)
        {
            ViewBuilder.Append($" \n ");
        }
    }
}
