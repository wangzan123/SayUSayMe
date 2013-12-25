using System;
namespace SayUSayMe.Model
{
	/// <summary>
	/// ApplyDataModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ApplyDataModel
	{
		public ApplyDataModel()
		{}
		#region Model
		private int _applyid;
		private string _applytitle;
		private string _applytext;
		private int? _applystate;
		private string _applyfailedtext;
		private int? _applyoriginid;
		private int? _userid;
		private DateTime? _adddate= DateTime.Now;
		private int? _applypopedom;
		private string _applypopedomtype;
		/// <summary>
		/// 
		/// </summary>
		public int applyID
		{
			set{ _applyid=value;}
			get{return _applyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string applyTitle
		{
			set{ _applytitle=value;}
			get{return _applytitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string applyText
		{
			set{ _applytext=value;}
			get{return _applytext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? applyState
		{
			set{ _applystate=value;}
			get{return _applystate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string applyFailedText
		{
			set{ _applyfailedtext=value;}
			get{return _applyfailedtext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? applyOriginID
		{
			set{ _applyoriginid=value;}
			get{return _applyoriginid;}
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
		public DateTime? addDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? applyPopedom
		{
			set{ _applypopedom=value;}
			get{return _applypopedom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string applyPopedomType
		{
			set{ _applypopedomtype=value;}
			get{return _applypopedomtype;}
		}
		#endregion Model

	}
}

