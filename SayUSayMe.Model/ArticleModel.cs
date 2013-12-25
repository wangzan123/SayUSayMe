using System;
namespace SayUSayMe.Model
{
	/// <summary>
	/// ArticleModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ArticleModel
	{
		public ArticleModel()
		{}
		#region Model
		private int _articleid;
		private int? _userid;
		private int? _classid;
		private int? _classsort;
		private string _articlesubject;
		private string _articlecontent;
		private DateTime? _adddate= DateTime.Now;
		private int? _articlegrade=0;
		private int? _clicksum=0;
		private int? _replysum=0;
		private int? _state=0;
		/// <summary>
		/// 
		/// </summary>
		public int articleID
		{
			set{ _articleid=value;}
			get{return _articleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? classID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? classSort
		{
			set{ _classsort=value;}
			get{return _classsort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string articleSubject
		{
			set{ _articlesubject=value;}
			get{return _articlesubject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string articleContent
		{
			set{ _articlecontent=value;}
			get{return _articlecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? articleGrade
		{
			set{ _articlegrade=value;}
			get{return _articlegrade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? clickSum
		{
			set{ _clicksum=value;}
			get{return _clicksum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? replySum
		{
			set{ _replysum=value;}
			get{return _replysum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

