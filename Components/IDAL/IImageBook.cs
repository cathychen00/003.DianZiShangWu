using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 图书广告图片信息接口
    /// </summary>
    public interface IImageBook
    {
        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        IList<ImageBookInfo> GetImageBook(ImageBookType type);


        /// <summary>
        /// 获取特定图片信息
        /// </summary>
        /// <param name="gbID"></param>
        /// <returns></returns>
        ImageBookInfo GetImageBookByID(int imageID);

        /// <summary>
        /// 添加图片信息
        /// </summary>
        /// <param name="g"></param>
        void InsertImageBook(ImageBookInfo image);

        /// <summary>
        /// 更新图片信息
        /// </summary>
        /// <param name="g"></param>
        int UpdateImageBook(ImageBookInfo image);

        /// <summary>
        /// 更新图片信息
        /// </summary>
        /// <param name="g"></param>
        int UpdateImageBook(UpdateImageType type,int order,int imageID);

        /// <summary>
        /// 删除图片信息
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        int DeleteImageBookByID(int imageID);
    }
    
}
