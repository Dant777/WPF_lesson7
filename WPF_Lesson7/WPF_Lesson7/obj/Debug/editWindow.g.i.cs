﻿#pragma checksum "..\..\editWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4858EA5761114F92D8E14C82C5FB7818D2791FF88B26D875F0DD2DF89DF39F3C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WPF_Lesson7;


namespace WPF_Lesson7 {
    
    
    /// <summary>
    /// editWindow
    /// </summary>
    public partial class editWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\editWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid addStackPanel;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\editWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddNameEmp;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\editWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddAgeEmp;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\editWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddSalaryEmp;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\editWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddOK;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\editWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF_Lesson7;component/editwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\editWindow.xaml"
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
            
            #line 8 "..\..\editWindow.xaml"
            ((WPF_Lesson7.editWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.addStackPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.txtAddNameEmp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtAddAgeEmp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtAddSalaryEmp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnAddOK = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\editWindow.xaml"
            this.btnAddOK.Click += new System.Windows.RoutedEventHandler(this.BtnAddOK_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnAddCancel = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\editWindow.xaml"
            this.btnAddCancel.Click += new System.Windows.RoutedEventHandler(this.BtnAddCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
