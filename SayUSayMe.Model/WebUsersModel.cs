using System;
namespace SayUSayMe.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class WebUsersModel
	{
		public WebUsersModel()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _userpassword;
		private string _pwproblem;
		private string _pwanswer;
		private int? _userpurse=10;
		private string _usershowname;
		private DateTime? _adddate= DateTime.Now;
		private string _headphoto;
		private string _userstate= "1";
		private int? _userscore=0;
		private int? _popedom;
		private int? _articlesum=0;
		private string _popedomtype;
		/// <summary>
		/// 
		/// </summary>
		public int userID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userPassword
		{
			set{ _userpassword=value;}
			get{return _userpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PwProblem
		{
			set{ _pwproblem=value;}
			get{return _pwproblem;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PwAnswer
		{
			set{ _pwanswer=value;}
			get{return _pwanswer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userPurse
		{
			set{ _userpurse=value;}
			get{return _userpurse;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userShowName
		{
			set{ _usershowname=value;}
			get{return _usershowname;}
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
		public string headPhoto
		{
			set{ _headphoto=value;}
			get{return _headphoto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userState
		{
			set{ _userstate=value;}
			get{return _userstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userScore
		{
			set{ _userscore=value;}
			get{return _userscore;}
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
		public int? articleSum
		{
			set{ _articlesum=value;}
			get{return _articlesum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string popedomType
		{
			set{ _popedomtype=value;}
			get{return _popedomtype;}
		}
		#endregion Model

	}
}

