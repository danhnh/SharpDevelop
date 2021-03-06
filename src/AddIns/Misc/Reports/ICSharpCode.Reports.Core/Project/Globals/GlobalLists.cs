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
using System.Collections;


/// <summary>
/// Use this code to have the same functionnames as SLQReportingServer
/// See <see cref="http://www.fyireporting.com/"></see>
/// </summary>
namespace ICSharpCode.Reports.Core.Globals
{
	/// <summary>
	/// Description of GlobalLists.
	/// </summary>
	public static class GlobalLists
	{
		
		public enum FunctionTypes {
			Globals,
			User,
			Fields,
			Parameters
		}
		
		#region Global functions
		
		public static string[] GlobalFunctions ()
		{
			return (string[])GlobalList.Clone();
		}
		
		private static readonly string[] GlobalList = new string[]{
			"=Globals!PageNumber",
			"=Globals!TotalPages",
			"=Globals!ExecutionTime",
			"=Globals!ReportFolder",
			"=Globals!ReportName"};
		
		#endregion
		
		#region User Functions
		
		public static string[] UserFunctions ()
		{
			return (string[])UserList.Clone();
		}
		
		
		private static readonly string[] UserList = new string[] {
																	  "=User!UserID",
																	  "=User!Language"};
		
		#endregion
		
		#region DataTypes
		public static string[] DataTypeList ()
		{
			return (string[])MyDataTypeList.Clone();
		}
		
		
		private static readonly string[] MyDataTypeList = new string[] {
			"System.String",
			"System.DateTime",
			"System.TimeSpan",
			"System.Decimal",
			"System.Int"};
		#endregion
		
		#region Aggregates
		
		public static string[] AggregateFunctions ()
		{
			return (string[])AggrFunctionList.Clone();
		}
		
		private static  readonly string[] AggrFunctionList = new string[] {"Sum(number [, scope])",
																		"Aggregate(number [, scope])",
																		"Avg(number [, scope])",
																		"Min(expr [, scope])",
																		"Max(expr [, scope])",
																		"First(expr [, scope])",
																		"Last(expr [, scope])",
																		"Next(expr [, scope])",
																		"Previous(expr [, scope])",
																		"Level([scope])",
																		"Count(expr [, scope])",
																		"Countrows(expr [, scope])",
																		"Countdistinct(expr [, scope])",
																		"RowNumber()",
																		"Runningvalue(expr, sum [, scope])",
																		"Runningvalue(expr, avg [, scope])",
																		"Runningvalue(expr, count [, scope])",
																		"Runningvalue(expr, max [, scope])",
																		"Runningvalue(expr, min [, scope])",
																		"Runningvalue(expr, stdev [, scope])",
																		"Runningvalue(expr, stdevp [, scope])",
																		"Runningvalue(expr, var [, scope])",
																		"Runningvalue(expr, varp [, scope])",
																		"Stdev(expr [, scope])",
																		"Stdevp(expr [, scope])",
																		"Var(expr [, scope])",
																		"Varp(expr [, scope])"};
		
		#endregion
		
		
		#region Zoom
		
		public static string[] ZoomValues ()
		{
			return (string[])ZoomList.Clone();
		}
		
		private static readonly string[] ZoomList = new string[] {
									"Actual Size",
//									"Fit Page",
//									"Fit Width",
									"800%",
									"400%",
									"200%",
									"150%",
									"125%",
									"100%",
									"75%",
									"50%",
									"25%"};
		
		#endregion
		
		 
		#region Formats
      
		public static string[] Formats ()
		{
			return (string[])FormatList.Clone();
		}
        
        private static readonly string[] FormatList = new string[] { "",
            "#,##0",
            "#,##0.00",
            "0",
            "0.00",
            "",
            "dd/MM/yy",
            "dd/MM/yyyy",
            "MM/dd/yyyy",
            "dddd, MMMM dd, yyyy",
            "dddd, MMMM dd, yyyy HH:mm",
            "dddd, MMMM dd, yyyy HH:mm:ss",
            "MM/dd/yyyy HH:mm",
           
            "MM/dd/yyyy HH:mm:ss", "MMMM dd",
            "Ddd, dd MMM yyyy HH\':\'mm\'\"ss \'GMT\'",
            "yyyy-MM-dd HH:mm:ss",
            "yyyy-MM-dd HH:mm:ss GMT",
            "HH:mm",
            "HH:mm:ss",
            "hh:mm:ss",
            "yyyy-MM-dd HH:mm:ss", "html"};
 
       #endregion
       
       
        #region Gradienst
        public static string[] Gradients ()
		{
			return (string[])GradientList.Clone();
		}
        
        
        private static readonly string[] GradientList = new string[] {
        "None", "LeftRight", "TopBottom", "Center", "DiagonalLeft",
        "DiagonalRight", "HorizontalCenter", "VerticalCenter"};
        
        #endregion
        
	}
}
