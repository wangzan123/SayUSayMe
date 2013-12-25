using System;


namespace SayUSayMe.DAL
{
    /// <summary>
    ///EnumEntity 的摘要说明
    /// </summary>
    public static class EnumEntity
    {
        static EnumEntity ()
        {
        }

        //处理申请的的枚举类
        public enum ApplyState
        {
            waitForDeal = 0, //等待处理
            applySuccess = 1, //同意申请
            applyFailed = -1 //拒绝申请
        }

        //文章的转态枚举
        public enum ArticleState
        {
            articleCheckedState = 1, //已经处理
            articleDeleteState = -1, //已被删除
            articleNormalState = 0 //等待处理状态，默认的状态
        }

        //回复文章类型枚举
        public enum ReplyType
        {
            ReplyToArticle = 0, //回复主题贴
            ReplyToReply = 1, //回复回复贴
            QuoteToReply = 2 //引用回复贴
        }

        //用户状态枚举
        public enum UserState
        {
            normalState = 1, //用户正常状态
            deleteState = 0, //用户禁言状态
            stopState = -1 //用户停用状态

        }
    }

}