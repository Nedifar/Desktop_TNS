﻿#pragma checksum "..\..\..\Forms\AbonentForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "71D9C14BD0D1533E08E9EB7F55FEDAE44F59F76FE57EAE6F367DB8A4AD8DA8F3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Desktop_TNS.Forms;
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


namespace Desktop_TNS.Forms {
    
    
    /// <summary>
    /// AbonentForm
    /// </summary>
    public partial class AbonentForm : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Forms\AbonentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgAbonents;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Forms\AbonentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbActive;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Forms\AbonentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbNeActive;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Forms\AbonentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrL;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Forms\AbonentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lv;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Forms\AbonentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchLastName;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Forms\AbonentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchLc;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Forms\AbonentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox searchStreet;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Forms\AbonentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox searchHome;
        
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
            System.Uri resourceLocater = new System.Uri("/Desktop_TNS;component/forms/abonentform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\AbonentForm.xaml"
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
            this.dgAbonents = ((System.Windows.Controls.DataGrid)(target));
            
            #line 17 "..\..\..\Forms\AbonentForm.xaml"
            this.dgAbonents.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgAbonents_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbActive = ((System.Windows.Controls.CheckBox)(target));
            
            #line 26 "..\..\..\Forms\AbonentForm.xaml"
            this.cbActive.Checked += new System.Windows.RoutedEventHandler(this.check);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\Forms\AbonentForm.xaml"
            this.cbActive.Unchecked += new System.Windows.RoutedEventHandler(this.uncheck);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbNeActive = ((System.Windows.Controls.CheckBox)(target));
            
            #line 27 "..\..\..\Forms\AbonentForm.xaml"
            this.cbNeActive.Checked += new System.Windows.RoutedEventHandler(this.check);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\Forms\AbonentForm.xaml"
            this.cbNeActive.Unchecked += new System.Windows.RoutedEventHandler(this.uncheck);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 33 "..\..\..\Forms\AbonentForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.scrL = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 6:
            this.lv = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            
            #line 46 "..\..\..\Forms\AbonentForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.searchLastName = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\Forms\AbonentForm.xaml"
            this.searchLastName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.searchLastName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.searchLc = ((System.Windows.Controls.TextBox)(target));
            
            #line 55 "..\..\..\Forms\AbonentForm.xaml"
            this.searchLc.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.searchLc_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 58 "..\..\..\Forms\AbonentForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clClear);
            
            #line default
            #line hidden
            return;
            case 11:
            this.searchStreet = ((System.Windows.Controls.ComboBox)(target));
            
            #line 62 "..\..\..\Forms\AbonentForm.xaml"
            this.searchStreet.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.searchStreet_TextChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.searchHome = ((System.Windows.Controls.ComboBox)(target));
            
            #line 66 "..\..\..\Forms\AbonentForm.xaml"
            this.searchHome.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.searchHome_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

