using System;
using System.Collections.Generic;
using UnityEngine;

namespace Draas
{
    public abstract class Router<T> : MonoBehaviour
    {
        public event Action<T> OnStateChanged;
        [SerializeField] private Page<T>[] pagesList;

        private Dictionary<T, Page<T>> _pages = new Dictionary<T, Page<T>>();
        private Page<T> _previousPage;
        private Page<T> _currentPage;

        private void Awake()
        {
            InitializePagesDictionary();
        }

        public void SetPage(T content, PageSetMode mode = PageSetMode.Single)
        {
            switch (mode)
            {
                case PageSetMode.Additive:
                    ActivatePage(content);
                    break;
                case PageSetMode.Single:
                    SwitchPage(content);
                    break;
            }
        }

        public void ReturnToPreviousPage()
        {
            if (_previousPage is null)
            {
                Debug.LogWarning("Previous page does not exist!");
                return;
            }
            
            SwitchPage(_previousPage.GetPageType());
        }

        public void ClosePage(T page)
        {
            _pages[page].DisablePage();
        }
        
        private void InitializePagesDictionary()
        {
            foreach (var pg in pagesList)
            {
                _pages.Add(pg.GetPageType(), pg);
            }
        }
        
        private bool CheckIfPageExists(T page)
        {
            return _pages.ContainsKey(page);
        }

        private void SwitchPage(T page)
        {
            _previousPage = _currentPage;
            _previousPage?.DisablePage();
            
            _currentPage = _pages[page];
            _currentPage.EnablePage();
            
            OnStateChanged?.Invoke(page);
        }

        private void ActivatePage(T page)
        {
            if (_pages.TryGetValue(page, out Page<T> success))
            {
                Debug.LogError("Page is not found!");
            }
            
            _pages[page].EnablePage();
        }
    }
}
