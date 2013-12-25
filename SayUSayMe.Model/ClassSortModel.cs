using System;
namespace SayUSayMe.Model
{
	/// <summary>
	/// ClassSortModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ClassSortModel
	{
		public ClassSortModel()
		{}
		#region Model
		private int _sortid;
		private int? _classid;
		private string _sortname;
		/// <summary>
		/// 
		/// </summary>
		public int sortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
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
		public string sortName
		{
			set{ _sortname=value;}
			get{return _sortname;}
		}
		#endregion Model

	}
}

