using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet.Turns
{
    /// <summary>
    /// An interface that keeps track on acotr turns
    /// </summary>
    public interface ITurnTracker
    {
        /// <summary>
        /// Called when a new turn starts
        /// </summary>
        internal void OnTurnStart();
    }
}
