﻿#pragma checksum "C:\Users\Dorjee\Desktop\G5DSI\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "25F4CC0208FB464632BEC5D23B7486549EDEBD68C24F90CD55545A693FE984F6"
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
    partial class MainPage : 
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
            case 2: // MainPage.xaml line 16
                {
                    this.imi = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 3: // MainPage.xaml line 19
                {
                    this.myTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.myTextBlock).SelectionChanged += this.TextBlock_SelectionChanged;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.myTextBlock).PointerEntered += this.myTextBlock_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.myTextBlock).PointerExited += this.myTextBlock_PointerExited;
                }
                break;
            case 4: // MainPage.xaml line 38
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.Play_Click;
                }
                break;
            case 5: // MainPage.xaml line 39
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Settings_Click;
                }
                break;
            case 6: // MainPage.xaml line 40
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.Exit_Click;
                }
                break;
            case 7: // MainPage.xaml line 22
                {
                    this.fadeOutAnimation = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 8: // MainPage.xaml line 29
                {
                    this.fadeInAnimation = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
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

