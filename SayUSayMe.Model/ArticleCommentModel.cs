using System;
namespace SayUSayMe.Model
{
	/// <summary>
	/// ArticleCommentModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ArticleCommentModel
	{
		public ArticleCommentModel()
		{}
		#region Model
		private int _commentid;
		private int _articleid;
		private int? _userid;
		private string _speakcontent;
		private DateTime? _adddate= DateTime.Now;
		private bool _worked= false;
		private int? _replytype;
		private string _usereplycontent;
		/// <summary>
		/// 
		/// </summary>
		public int commentID
		{
			set{ _commentid=value;}
			get{return _commentid;}
		}
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
		public string speakContent
		{
			set{ _speakcontent=value;}
			get{return _speakcontent;}
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
		public bool worked
		{
			set{ _worked=value;}
			get{return _worked;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? replyType
		{
			set{ _replytype=value;}
			get{return _replytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string useReplyContent
		{
			set{ _usereplycontent=value;}
			get{return _usereplycontent;}
		}
		#endregion Model

	}
}

