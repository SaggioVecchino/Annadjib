﻿#pragma checksum "..\..\..\..\..\View\UsrCtrl\Admin\ConfirmationSupprimAll.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F8FA962F2E03BF24EDCFC063A1B6CD56"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using Projet.View.UsrCtrl.Admin;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Projet.View.UsrCtrl.Admin {
    
    
    /// <summary>
    /// ConfirmationSupprimAll
    /// </summary>
    public partial class ConfirmationSupprimAll : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\..\View\UsrCtrl\Admin\ConfirmationSupprimAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border background;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\View\UsrCtrl\Admin\ConfirmationSupprimAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border backgrnd;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\View\UsrCtrl\Admin\ConfirmationSupprimAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button no;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\..\View\UsrCtrl\Admin\ConfirmationSupprimAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button yes;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Projet;component/view/usrctrl/admin/confirmationsupprimall.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\UsrCtrl\Admin\ConfirmationSupprimAll.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.background = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.backgrnd = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.no = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\..\View\UsrCtrl\Admin\ConfirmationSupprimAll.xaml"
            this.no.Click += new System.Windows.RoutedEventHandler(this.no_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.yes = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\..\..\View\UsrCtrl\Admin\ConfirmationSupprimAll.xaml"
            this.yes.Click += new System.Windows.RoutedEventHandler(this.yes_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

