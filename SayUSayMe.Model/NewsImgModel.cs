using System;
namespace SayUSayMe.Model
{
	/// <summary>
	/// NewsImgModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NewsImgModel
	{
		public NewsImgModel()
		{}
		#region Model
		private int _imgid;
		private string _imgurl;
		private string _imgdescription;
		private DateTime? _adddatetime;
		/// <summary>
		/// 
		/// </summary>
		public int imgID
		{
			set{ _imgid=value;}
			get{return _imgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgDescription
		{
			set{ _imgdescription=value;}
			get{return _imgdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addDateTime
		{
			set{ _adddatetime=value;}
			get{return _adddatetime;}
		}
		#endregion Model

	}
}

