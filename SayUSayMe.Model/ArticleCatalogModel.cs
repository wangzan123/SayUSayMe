using System;
namespace SayUSayMe.Model
{
	/// <summary>
	/// ArticleCatalogModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ArticleCatalogModel
	{
		public ArticleCatalogModel()
		{}
		#region Model
		private int _catalogid;
		private string _catalogname;
		private string _catalogdescription;
		private string _indexurl;
		private int? _popedom;
		private int? _catalogstate=1;
		/// <summary>
		/// 
		/// </summary>
		public int catalogID
		{
			set{ _catalogid=value;}
			get{return _catalogid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string catalogName
		{
			set{ _catalogname=value;}
			get{return _catalogname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string catalogDescription
		{
			set{ _catalogdescription=value;}
			get{return _catalogdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string indexUrl
		{
			set{ _indexurl=value;}
			get{return _indexurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? popedom
		{
			set{ _popedom=value;}
			get{return _popedom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? catalogState
		{
			set{ _catalogstate=value;}
			get{return _catalogstate;}
		}
		#endregion Model

	}
}

