using System;
namespace SayUSayMe.Model
{
	/// <summary>
	/// ArticleClassModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ArticleClassModel
	{
		public ArticleClassModel()
		{}
		#region Model
		private int _classid;
		private int? _catalogid;
		private string _classname;
		private string _classdescription;
		private string _classimg;
		private int? _articlesum=0;
		private string _warning;
		private int? _popedom;
		private int? _classstate=1;
		/// <summary>
		/// 
		/// </summary>
		public int classID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? catalogID
		{
			set{ _catalogid=value;}
			get{return _catalogid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string className
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classDescription
		{
			set{ _classdescription=value;}
			get{return _classdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classImg
		{
			set{ _classimg=value;}
			get{return _classimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? articleSum
		{
			set{ _articlesum=value;}
			get{return _articlesum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string warning
		{
			set{ _warning=value;}
			get{return _warning;}
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
		public int? classState
		{
			set{ _classstate=value;}
			get{return _classstate;}
		}
		#endregion Model

	}
}

