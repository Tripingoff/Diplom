﻿#pragma checksum "..\..\..\Pages\AddOmission.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "68489ED1FBD238841A3368306366DDCAC7242E2E066182E1AB5C6209391D237F"
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
using ИС_ККТД.Pages;


namespace ИС_ККТД.Pages {
    
    
    /// <summary>
    /// AddOmission
    /// </summary>
    public partial class AddOmission : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 89 "..\..\..\Pages\AddOmission.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtID;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Pages\AddOmission.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbStudent;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Pages\AddOmission.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbDisciplins;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\Pages\AddOmission.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbPropusc;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Pages\AddOmission.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DpDate;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\Pages\AddOmission.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DpTime;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\Pages\AddOmission.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Scan;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\Pages\AddOmission.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLoad;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\Pages\AddOmission.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSave;
        
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
            System.Uri resourceLocater = new System.Uri("/ИС ККТД;component/pages/addomission.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AddOmission.xaml"
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
            this.TxtID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.CmbStudent = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.CmbDisciplins = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.CmbPropusc = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.DpDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.DpTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Scan = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.BtnLoad = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\Pages\AddOmission.xaml"
            this.BtnLoad.Click += new System.Windows.RoutedEventHandler(this.BtnLoadClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BtnSave = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\..\Pages\AddOmission.xaml"
            this.BtnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSaveClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

