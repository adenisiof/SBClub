﻿#pragma checksum "..\..\lancarPontos.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27D4DCBC7D1FE92978D1522DBB2382D8461B8A05"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using SBClub;
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


namespace SBClub {
    
    
    /// <summary>
    /// lancarPontos
    /// </summary>
    public partial class lancarPontos : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\lancarPontos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid lblNome;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\lancarPontos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgLogo;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\lancarPontos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgLogo_Copy;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\lancarPontos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ckbCpf;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\lancarPontos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ckbId;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\lancarPontos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNumeroLP;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\lancarPontos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLancarLP;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\lancarPontos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNome;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\lancarPontos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbFormaPagamento;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\lancarPontos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtValorGasto;
        
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
            System.Uri resourceLocater = new System.Uri("/SBClub;component/lancarpontos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\lancarPontos.xaml"
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
            this.lblNome = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.imgLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.imgLogo_Copy = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.ckbCpf = ((System.Windows.Controls.CheckBox)(target));
            
            #line 20 "..\..\lancarPontos.xaml"
            this.ckbCpf.Checked += new System.Windows.RoutedEventHandler(this.ckbCpf_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ckbId = ((System.Windows.Controls.CheckBox)(target));
            
            #line 21 "..\..\lancarPontos.xaml"
            this.ckbId.Checked += new System.Windows.RoutedEventHandler(this.ckbId_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtNumeroLP = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\lancarPontos.xaml"
            this.txtNumeroLP.GotFocus += new System.Windows.RoutedEventHandler(this.txtNumeroLP_GotFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 28 "..\..\lancarPontos.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAutenticar_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnLancarLP = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\lancarPontos.xaml"
            this.btnLancarLP.Click += new System.Windows.RoutedEventHandler(this.btnLancarLP_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtNome = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.cmbFormaPagamento = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.txtValorGasto = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\lancarPontos.xaml"
            this.txtValorGasto.GotFocus += new System.Windows.RoutedEventHandler(this.ValorGasto_Focus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

