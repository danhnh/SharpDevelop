﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision$</version>
// </file>

using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.WixBinding;
using NUnit.Framework;
using System;
using System.IO;
using System.Xml;

namespace WixBinding.Tests.Document
{
	/// <summary>
	/// Tests whether the dialog xml element with the specified id is correctly 
	/// located in the wix xml.
	/// </summary>
	[TestFixture]
	public class GetDialogElementRegionTests
	{
		[Test]
		public void DialogSpansTwoLines()
		{
			string xml = "<Wix xmlns='http://schemas.microsoft.com/wix/2006/wi'>\r\n" +
				"\t<Fragment>\r\n" +
				"\t\t<UI>\r\n" +
				"\t\t\t<Dialog Id='WelcomeDialog' Height='100' Width='200'>\r\n" +
				"\t\t\t</Dialog>\r\n" +
				"\t\t</UI>\r\n" +
				"\t</Fragment>\r\n" +
				"</Wix>";
			
			WixDocumentReader wixReader = new WixDocumentReader(xml);
			DomRegion region = wixReader.GetElementRegion("Dialog", "WelcomeDialog");
			DomRegion expectedRegion = new DomRegion(4, 4, 5, 12);
			Assert.AreEqual(expectedRegion, region);
		}
		
		[Test]
		public void DialogSpansOneLine()
		{
			string xml = "<Wix xmlns='http://schemas.microsoft.com/wix/2006/wi'>\r\n" +
				"\t<Fragment>\r\n" +
				"\t\t<UI>\r\n" +
				"<Dialog Id='WelcomeDialog'></Dialog>\r\n" +
				"\t\t</UI>\r\n" +
				"\t</Fragment>\r\n" +
				"</Wix>";
			
			WixDocumentReader wixReader = new WixDocumentReader(xml);
			DomRegion region = wixReader.GetElementRegion("Dialog", "WelcomeDialog");
			DomRegion expectedRegion = new DomRegion(4, 1, 4, 36);
			Assert.AreEqual(expectedRegion, region);
		}
		
		[Test]
		public void EmptyDialogElement()
		{
			string xml = "<Wix xmlns='http://schemas.microsoft.com/wix/2006/wi'>\r\n" +
				"\t<Fragment>\r\n" +
				"\t\t<UI>\r\n" +
				"<Dialog Id='WelcomeDialog'/>\r\n" +
				"\t\t</UI>\r\n" +
				"\t</Fragment>\r\n" +
				"</Wix>";
			
			WixDocumentReader wixReader = new WixDocumentReader(xml);
			DomRegion region = wixReader.GetElementRegion("Dialog", "WelcomeDialog");
			DomRegion expectedRegion = new DomRegion(4, 1, 4, 28);
			Assert.AreEqual(expectedRegion, region);
		}
	
		[Test]
		public void ElementStartsImmediatelyAfterDialogEndElement()
		{
			string xml = "<Wix xmlns='http://schemas.microsoft.com/wix/2006/wi'>\r\n" +
				"\t<Fragment>\r\n" +
				"\t\t<UI>\r\n" +
				"<Dialog Id='WelcomeDialog'></Dialog><Property/>\r\n" +
				"\t\t</UI>\r\n" +
				"\t</Fragment>\r\n" +
				"</Wix>";
			
			WixDocumentReader wixReader = new WixDocumentReader(xml);
			DomRegion region = wixReader.GetElementRegion("Dialog", "WelcomeDialog");
			DomRegion expectedRegion = new DomRegion(4, 1, 4, 36);
			Assert.AreEqual(expectedRegion, region);
		}
		
		[Test]
		public void TwoDialogs()
		{
			string xml = "<Wix xmlns='http://schemas.microsoft.com/wix/2006/wi'>\r\n" +
				"\t<Fragment>\r\n" +
				"\t\t<UI>\r\n" +
				"\t\t\t<Dialog Id='IgnoreThisDialog' Height='100' Width='200'>\r\n" +
				"\t\t\t</Dialog>\r\n" +
				"\t\t\t<Dialog Id='WelcomeDialog' Height='100' Width='200'>\r\n" +
				"\t\t\t</Dialog>\r\n" +
				"\t\t</UI>\r\n" +
				"\t</Fragment>\r\n" +
				"</Wix>";
			WixDocumentReader wixReader = new WixDocumentReader(xml);
			DomRegion region = wixReader.GetElementRegion("Dialog", "WelcomeDialog");
			DomRegion expectedRegion = new DomRegion(6, 4, 7, 12);
			Assert.AreEqual(expectedRegion, region);
		}
	}
}
