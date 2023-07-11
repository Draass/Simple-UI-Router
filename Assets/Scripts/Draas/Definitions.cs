using UnityEngine;

namespace Draas
{
    public enum PageSetMode
    {
        /// <summary>
        /// Perform action only for selected page
        /// </summary>
        Single,
        
        /// <summary>
        /// Perform action for selected page and a previous page
        /// </summary>
        Additive
    }
}
