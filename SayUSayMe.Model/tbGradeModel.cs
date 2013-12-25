using System;
namespace SayUSayMe.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class tbGradeModel
	{
		public tbGradeModel()
		{}
		#region Model
		private int _gradeid;
		private int? _level1;
		private int? _level2;
		private int? _level3;
		private int? _level4;
		private int _gradescore;
		/// <summary>
		/// 
		/// </summary>
		public int gradeID
		{
			set{ _gradeid=value;}
			get{return _gradeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? level1
		{
			set{ _level1=value;}
			get{return _level1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? level2
		{
			set{ _level2=value;}
			get{return _level2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? level3
		{
			set{ _level3=value;}
			get{return _level3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? level4
		{
			set{ _level4=value;}
			get{return _level4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int gradeScore
		{
			set{ _gradescore=value;}
			get{return _gradescore;}
		}
		#endregion Model

	}
}

