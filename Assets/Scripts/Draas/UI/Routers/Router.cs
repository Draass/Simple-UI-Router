using System.Collections.Generic;
using Draas.UI.Common;
using Draas.UI.Views;
using UnityEngine;

namespace Draas.UI.Routers
{
    public abstract class Router<T> : MonoBehaviour
    {
        //public event Action<T> OnStateChanged;
        [SerializeField] private View<T>[] viewsList;

        private Dictionary<T, View<T>> _views = new Dictionary<T, View<T>>();
        private View<T> _previousView;
        private View<T> _currentView;

        private void Awake()
        {
            InitializeViewsDictionary();
        }

        public void SetView(T view, ViewSetMode mode = ViewSetMode.Additive)
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

        public void ReturnToPreviousView()
        {
            if (_previousView is null)
            {
                Debug.LogWarning("Previous view does not exist!");
                return;
            }
            
            SwitchView(_previousView.GetViewType());
        }

        public void CloseView(T view)
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
            _previousView = _currentView;
            _previousView?.DisableView();
            
            _currentView = _views[view];
            _currentView.EnableView();
            
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
