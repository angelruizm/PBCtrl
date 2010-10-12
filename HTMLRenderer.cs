// Copyright © 2010 Phil Booth
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PB
{
	/// <summary>
	/// An HTML+CSS document renderer.
	/// </summary>
	[Category("PB Controls"), Description("An HTML/CSS renderer.")]
	public partial class HTMLRenderer : UserControl
	{
		public HTMLRenderer()
		{
			InitializeComponent();
		}

		#region Properties
		[Description("Indicates whether the HTMLRenderer will receive drop events.")]
		public override bool AllowDrop
		{
			get { return browser.AllowWebBrowserDrop; }
			set { browser.AllowWebBrowserDrop = value; }
		}

		[Description("Indicates whether the HTMLRenderer can navigate to other pages after initially loading.")]
		public bool AllowNavigation
		{
			get { return browser.AllowNavigation; }
			set { browser.AllowNavigation = value; }
		}

		[Description("The shortcut menu to display when the use right-clicks the control.")]
		public override ContextMenuStrip ContextMenuStrip
		{
			get { return browser.ContextMenuStrip; }
			set { browser.ContextMenuStrip = value; }
		}

		[Description("Indicates whether the HTMLRenderer should use the default context menu.")]
		public bool UseDefaultContextMenu
		{
			get { return browser.IsWebBrowserContextMenuEnabled; }
			set { browser.IsWebBrowserContextMenuEnabled = value; }
		}

		[Description("Indicates whether the HTMLRenderer should display notifications of script errors.")]
		public bool SuppressErrors
		{
			get { return browser.ScriptErrorsSuppressed; }
			set { browser.ScriptErrorsSuppressed = value; }
		}

		[Description("Indicates whether the HTMLRenderer should have scrollbars.")]
		public bool EnableScrollBars
		{
			get { return browser.ScrollBarsEnabled; }
			set { browser.ScrollBarsEnabled = value; }
		}

		[Description("Indicates whether the HTMLRenderer accelerator keys are enabled.")]
		public bool EnableAcceleratorKeys
		{
			get { return browser.WebBrowserShortcutsEnabled; }
			set { browser.WebBrowserShortcutsEnabled = value; }
		}
		#endregion

		#region Rendering
		public void RenderURL(string url)
		{
			browser.Navigate(url);
		}

		public void RenderFile(string path)
		{
			browser.Navigate(m_filePrefix + path);
		}

		public void RenderMarkup(string markup)
		{
			browser.DocumentText = markup;
		}
		#endregion

		#region Communication
		public void CallFunction(string name, object[] arguments)
		{
			browser.Document.InvokeScript(name, arguments);
		}

		public void AddCallback(Object callback)
		{
			browser.ObjectForScripting = callback;
		}
		#endregion

		private readonly static string m_filePrefix = "file:///";
	}
}
