using System;
namespace SayUSayMe.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class WebUsersDetailsModel
	{
		public WebUsersDetailsModel()
		{}
		#region Model
		private int _detailsid;
		private int? _userid;
		private string _usersex;
		private string _usermajor;
		private string _useraddress;
		private string _usermaxim;
		private string _usermoblie;
		/// <summary>
		/// 
		/// </summary>
		public int detailsID
		{
			set{ _detailsid=value;}
			get{return _detailsid;}
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
		public string userSex
		{
			set{ _usersex=value;}
			get{return _usersex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userMajor
		{
			set{ _usermajor=value;}
			get{return _usermajor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userAddress
		{
			set{ _useraddress=value;}
			get{return _useraddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userMaxim
		{
			set{ _usermaxim=value;}
			get{return _usermaxim;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userMoblie
		{
			set{ _usermoblie=value;}
			get{return _usermoblie;}
		}
		#endregion Model

	}
}

