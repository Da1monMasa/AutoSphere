﻿#pragma checksum "..\..\LogINPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EDF17A235F8509FD9FF8A849B63A557CD7FA6783BD43816AA2725B9B34FF2EBA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoSphereApp;
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


namespace AutoSphereApp {
    
    
    /// <summary>
    /// LogINPage
    /// </summary>
    public partial class LogINPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\LogINPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginTB;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\LogINPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbPassword;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\LogINPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\LogINPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBoxPass;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\LogINPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Noises;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\LogINPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel SymbolsGen;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\LogINPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GetCapcha;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\LogINPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateCapcha;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\LogINPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConfirmCapcha;
        
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
            System.Uri resourceLocater = new System.Uri("/AutoSphereApp;component/loginpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LogINPage.xaml"
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
            this.LoginTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TxbPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.CheckBoxPass = ((System.Windows.Controls.CheckBox)(target));
            
            #line 21 "..\..\LogINPage.xaml"
            this.CheckBoxPass.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_UnChecked);
            
            #line default
            #line hidden
            
            #line 21 "..\..\LogINPage.xaml"
            this.CheckBoxPass.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Noises = ((System.Windows.Controls.Canvas)(target));
            return;
            case 6:
            this.SymbolsGen = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.GetCapcha = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.UpdateCapcha = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\LogINPage.xaml"
            this.UpdateCapcha.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ConfirmCapcha = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            
            #line 30 "..\..\LogINPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
