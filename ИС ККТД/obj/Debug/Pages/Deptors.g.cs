﻿#pragma checksum "..\..\..\Pages\Deptors.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FAF2C65D50D9438E4FE93E163F9E0E3A1979A5CEF04BBE79E07241BD2EB1BDC6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Themes;
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
using ИС_ККТД.Pages;


namespace ИС_ККТД.Pages {
    
    
    /// <summary>
    /// Deptors
    /// </summary>
    public partial class Deptors : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 426 "..\..\..\Pages\Deptors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbGroup;
        
        #line default
        #line hidden
        
        
        #line 428 "..\..\..\Pages\Deptors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbDisciplines;
        
        #line default
        #line hidden
        
        
        #line 437 "..\..\..\Pages\Deptors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnpddf;
        
        #line default
        #line hidden
        
        
        #line 439 "..\..\..\Pages\Deptors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxDeptors;
        
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
            System.Uri resourceLocater = new System.Uri("/ИС ККТД;component/pages/deptors.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Deptors.xaml"
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
            this.CmbGroup = ((System.Windows.Controls.ComboBox)(target));
            
            #line 426 "..\..\..\Pages\Deptors.xaml"
            this.CmbGroup.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CmbGroup_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CmbDisciplines = ((System.Windows.Controls.ComboBox)(target));
            
            #line 428 "..\..\..\Pages\Deptors.xaml"
            this.CmbDisciplines.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CmbDisciplines_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnpddf = ((System.Windows.Controls.Button)(target));
            
            #line 437 "..\..\..\Pages\Deptors.xaml"
            this.btnpddf.Click += new System.Windows.RoutedEventHandler(this.btnpddf_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ListBoxDeptors = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

