﻿#pragma checksum "..\..\..\Viewers\ViewRadar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4F2ED827CD3FDBB5604D1675B1ABA11E36F486A8276725908A69750C5306D3F4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AcusticDetector.Viewers;
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


namespace AcusticDetector.Viewers {
    
    
    /// <summary>
    /// ViewRadar
    /// </summary>
    public partial class ViewRadar : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Viewers\ViewRadar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border BorderG1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Viewers\ViewRadar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas mainCanvas;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Viewers\ViewRadar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path backgroundPath;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Viewers\ViewRadar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path fillPath;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Viewers\ViewRadar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.RotateTransform fillPathRT;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Viewers\ViewRadar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line needleLine;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Viewers\ViewRadar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line needleLine1;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\Viewers\ViewRadar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line needleLine2;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\Viewers\ViewRadar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line needleLine3;
        
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
            System.Uri resourceLocater = new System.Uri("/AcusticDetector;component/viewers/viewradar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Viewers\ViewRadar.xaml"
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
            this.BorderG1 = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.mainCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.backgroundPath = ((System.Windows.Shapes.Path)(target));
            return;
            case 4:
            this.fillPath = ((System.Windows.Shapes.Path)(target));
            return;
            case 5:
            this.fillPathRT = ((System.Windows.Media.RotateTransform)(target));
            return;
            case 6:
            this.needleLine = ((System.Windows.Shapes.Line)(target));
            return;
            case 7:
            this.needleLine1 = ((System.Windows.Shapes.Line)(target));
            return;
            case 8:
            this.needleLine2 = ((System.Windows.Shapes.Line)(target));
            return;
            case 9:
            this.needleLine3 = ((System.Windows.Shapes.Line)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

