using System.Collections.Generic;
using Draas.UI.Common;
using Draas.UI.Views;
using UnityEngine;

namespace Draas.UI.Routers
{
    public abstract class AbstractRouter<T> : MonoBehaviour
    {
        //public event Action<T> OnStateChanged;
        [SerializeField] private AbstractView<T>[] viewsList;

        private Dictionary<T, AbstractView<T>> _views = new Dictionary<T, AbstractView<T>>();
        private AbstractView<T> _previousAbstractView;
        private AbstractView<T> _currentAbstractView;

        private void Awake()
        {
            InitializeViewsDictionary();
        }

        public virtual void SetView(T view, ViewSetMode mode = ViewSetMode.Additive)
        {
            switch (mode)
            {
                case ViewSetMode.Replacing:
                    ActivateView(view);
                    break;
                case ViewSetMode.Additive:
                    SwitchView(view);
                    break;
            }
        }

        public virtual void ReturnToPreviousView()
        {
            if (_previousAbstractView is null)
            {
                Debug.LogWarning("Previous view does not exist!");
                return;
            }
            
            SwitchView(_previousAbstractView.GetViewType());
        }

        public virtual void CloseView(T view)
        {
            _views[view].DisableView();
        }
        
        private void InitializeViewsDictionary()
        {
            foreach (var view in viewsList)
            {
                _views.Add(view.GetViewType(), view);
            }
        }
        
        private bool CheckIfViewExists(T view)
        {
            return _views.ContainsKey(view);
        }

        private void SwitchView(T view)
        {
            _previousAbstractView = _currentAbstractView;
            _previousAbstractView?.DisableView();
            
            _currentAbstractView = _views[view];
            _currentAbstractView.EnableView();
            
            //OnStateChanged?.Invoke(view);
        }

        private void ActivateView(T view)
        {
            if (CheckIfViewExists(view) == false)
            {
                Debug.LogError("Page is not found!");
                return;
            }
            
            _views[view].EnableView();
        }
    }
}
