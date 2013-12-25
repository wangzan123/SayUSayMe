using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SayUSayMe.Model
{


    /// <summary>
    /// News:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable] public partial class News
    {
        public News ()
        {
        }

        #region Model

        private int _newsid;
        private int? _userid;
        private int? _classsort;
        private string _newssubject;
        private string _newscontent;
        private DateTime? _adddate = DateTime.Now;
        private string _newsphoto = "0";

        /// <summary>
        /// 新闻编号
        /// </summary>
        public int NewsID
        {
            set { _newsid = value; }
            get { return _newsid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? userID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? classSort
        {
            set { _classsort = value; }
            get { return _classsort; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NewsSubject
        {
            set { _newssubject = value; }
            get { return _newssubject; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NewsContent
        {
            set { _newscontent = value; }
            get { return _newscontent; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? addDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NewsPhoto
        {
            set { _newsphoto = value; }
            get { return _newsphoto; }
        }

        #endregion Model

    }
}
