﻿#pragma checksum "C:\Users\Dorjee\Documents\GitHub\HelloTomorrow-DSI\G5DSI\Play.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AA875A356EB89A5F98A1C31316DAA9E5CA80D8B75F9F6A4A264F5877EAC25425"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace G5DSI
{
    partial class Play : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Play.xaml line 13
                {
                    this.progressBar = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                    ((global::Windows.UI.Xaml.Controls.ProgressBar)this.progressBar).ValueChanged += this.ProgressBar_ValueChanged;
                }
                break;
            case 3: // Play.xaml line 46
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.Shop_Click;
                }
                break;
            case 4: // Play.xaml line 47
                {
                    this.ElegirCancionButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ElegirCancionButton).Click += this.ElegirCancionButton_Click;
                }
                break;
            case 5: // Play.xaml line 43
                {
                    this.valor6 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Play.xaml line 39
                {
                    this.valor5 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Play.xaml line 35
                {
                    this.valor4 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // Play.xaml line 29
                {
                    this.valor3 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // Play.xaml line 24
                {
                    this.valor2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // Play.xaml line 19
                {
                    this.valor1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

