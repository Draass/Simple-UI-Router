using UnityEngine;

namespace Draas
{
    public abstract class Page<T> : MonoBehaviour
    {
        [SerializeField] private T pageType;
        [SerializeField] private Canvas canvas;

        public virtual T GetPageType()
        {
            return pageType;
        }

        public virtual void EnablePage()
        {
            canvas.enabled = true;
        }

        public virtual void DisablePage()
        {
            canvas.enabled = false;
        }
    }
}
