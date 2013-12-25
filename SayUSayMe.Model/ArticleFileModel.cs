using System;
namespace SayUSayMe.Model
{
	/// <summary>
	/// ArticleFileModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ArticleFileModel
	{
		public ArticleFileModel()
		{}
		#region Model
		private int _fileid;
		private string _filesavename;
		private string _fileurl;
		private string _filedescription;
		private int? _cid;
		private int? _aid;
		/// <summary>
		/// 
		/// </summary>
		public int fileID
		{
			set{ _fileid=value;}
			get{return _fileid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fileSaveName
		{
			set{ _filesavename=value;}
			get{return _filesavename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fileUrl
		{
			set{ _fileurl=value;}
			get{return _fileurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fileDescription
		{
			set{ _filedescription=value;}
			get{return _filedescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AID
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		#endregion Model

	}
}

