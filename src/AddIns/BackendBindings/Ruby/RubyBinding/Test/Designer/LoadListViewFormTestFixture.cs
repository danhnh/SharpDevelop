﻿// Copyright (c) 2014 AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using ICSharpCode.RubyBinding;
using NUnit.Framework;
using RubyBinding.Tests.Utils;

namespace RubyBinding.Tests.Designer
{
	[TestFixture]
	public class LoadListViewFormTestFixture : LoadFormTestFixtureBase
	{
		public override string RubyCode {
			get {
				return
					"class MainForm < System::Windows::Forms::Form\r\n" +
					"    def InitializeComponent()\r\n" +
					"        @listView1 = System::Windows::Forms::ListView.new()\r\n" +
					"        listViewItem1 = System::Windows::Forms::ListViewItem.new()\r\n" +
					"        listViewItem2 = System::Windows::Forms::ListViewItem.new()\r\n" +
					"        self.SuspendLayout()\r\n" +
					"        # \r\n" +
					"        # listView1\r\n" +
					"        # \r\n" +
					"        @listView1.Items.AddRange(System::Array[System::Windows::Forms::ListViewItem].new(\r\n" +
					"            [listViewItem1,\r\n" +
					"            listViewItem2]))\r\n" +
					"        @listView1.Location = System::Drawing::Point.new(0, 0)\r\n" +
					"        @listView1.Name = \"listView1\"\r\n" +
					"        @listView1.Size = System::Drawing::Size.new(204, 104)\r\n" +
					"        @listView1.TabIndex = 0\r\n" +
					"        listViewItem1.ToolTipText = \"tooltip1\"\r\n" +
					"        listViewItem2.ToolTipText = \"tooltip2\"\r\n" +
					"        # \r\n" +
					"        # MainForm\r\n" +
					"        # \r\n" +
					"        self.ClientSize = System::Drawing::Size.new(200, 300)\r\n" +
					"        self.Controls.Add(@listView1)\r\n" +
					"        self.Name = \"MainForm\"\r\n" +
					"        self.ResumeLayout(false)\r\n" +
					"        self.PerformLayout()\r\n" +
					"    end\r\n" +
					"end";
			}
		}
		
		public ListView ListView {
			get { return Form.Controls[0] as ListView; }
		}
		
		public ListViewItem ListViewItem1 {
			get { return ListView.Items[0]; }
		}
		
		public ListViewItem ListViewItem2 {
			get { return ListView.Items[1]; }
		}
		
		[Test]
		public void ListViewAddedToForm()
		{
			Assert.IsNotNull(ListView);
		}
		
		[Test]
		public void ListViewHasTwoItems()
		{
			Assert.AreEqual(2, ListView.Items.Count);
		}
		
		[Test]
		public void ListViewItem1TooltipText()
		{
			Assert.AreEqual("tooltip1", ListViewItem1.ToolTipText);
		}
	}
}
