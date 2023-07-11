using System;
using Draas.Examples;
using Draas.UI.Views;
using UnityEngine;

namespace Examples
{
    public class SettingsView : AbstractView<Enum>
    {
        [SerializeField] private MainScreenViews view;
        
        public override Enum GetViewType()
        {
            return view;
        }
    }
}
