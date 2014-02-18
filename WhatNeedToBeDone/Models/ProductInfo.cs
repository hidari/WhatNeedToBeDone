using System;
using System.Reflection;

namespace Hidari0415.WhatNeedToBeDone.Models
{
	public class ProductInfo
	{
		private static readonly Assembly assembly = Assembly.GetExecutingAssembly();
		private string _Title;
		private string _Description;
		private string _Company;
		private string _Product;
		private string _Copyright;
		private string _Trademark;
		private Version _Version;

		public string Title
		{
			get { return this._Title ?? (this._Title = 
				((AssemblyTitleAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute))).Title); }
		}

		public string Description
		{
			get
			{
				return this._Description ?? (this._Description =
					((AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyDescriptionAttribute))).Description);
			}
		}

		public string Company
		{
			get
			{
				return this._Company ?? (this._Company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute))).Company);
			}
		}

		public string Product
		{
			get
			{
				return this._Product ?? (this._Product = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyProductAttribute))).Product);
			}
		}

		public string Copyright
		{
			get
			{
				return this._Copyright ?? (this._Copyright = ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCopyrightAttribute))).Copyright);
			}
		}

		public string Trademark
		{
			get
			{
				return this._Trademark ?? (this._Trademark = ((AssemblyTrademarkAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTrademarkAttribute))).Trademark);
			}
		}

		public Version Version
		{
			get
			{
				return this._Version ?? (this._Version = assembly.GetName().Version);
			}
		}

		public string VersionString
		{
			get
			{
				return this.Version.ToString(3);
			}
		}
	}
}
