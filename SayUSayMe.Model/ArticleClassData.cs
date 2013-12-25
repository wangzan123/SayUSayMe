using System;



namespace SayUSayMe.Model
{
    /// <summary>
    ///ArticleClassData
    ///文章分类实体类
    /// </summary>
    public class ArticleClassData
    {
        public ArticleClassData ()
        {
        }

        public string ID;
        public string Name;

        public ArticleClassData (string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }

}