# Simple-UI-Router

## Table of contents
* Project description
* Installation
* Usage

## Project Description

Simple UI Router is one of the lightest solutions possible for switching views in your game using canvases. Should be fine using with any Unity version. 

## Installation

1) Clone it with https://github.com/Draass/Simple-UI-Router/tree/release.git#upm;
2) Download unitypackage and install if from releases;
3) Just download scripts and drag them in your project.

## Usage

To start using router, create a child of AbstractRouter and choose a type you will change your views with.

Here is the most basic example for a router base on enums:

```С#
public class EnumRouter : AbstractRouter<Enum>
    {
        // Any additional logic you need here       
    }
```

This is an enum view for such router:

```С#
public class SettingsView : AbstractView<Enum>
    {
        // Some enum
        [SerializeField] private MainScreenViews view;
        
        public override Enum GetViewType()
        {
            return view;
        }
    }
```

That's it! Simple and straightforward.
