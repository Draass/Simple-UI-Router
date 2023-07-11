using UnityEngine;

namespace Draas.UI.Views
{
    public abstract class View<T> : MonoBehaviour
    {
        [SerializeField] private T viewType;
        [SerializeField] private Canvas canvas;

        public virtual T GetViewType()
        {
            return viewType;
        }

        public virtual void EnableView()
        {
            canvas.enabled = true;
        }

        public virtual void DisableView()
        {
            canvas.enabled = false;
        }
    }
}
