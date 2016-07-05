using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ͼ����ͼƬ��Ϣ�ӿ�
    /// </summary>
    public interface IImageBook
    {
        /// <summary>
        /// ��ȡͼƬ��Ϣ
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        IList<ImageBookInfo> GetImageBook(ImageBookType type);


        /// <summary>
        /// ��ȡ�ض�ͼƬ��Ϣ
        /// </summary>
        /// <param name="gbID"></param>
        /// <returns></returns>
        ImageBookInfo GetImageBookByID(int imageID);

        /// <summary>
        /// ���ͼƬ��Ϣ
        /// </summary>
        /// <param name="g"></param>
        void InsertImageBook(ImageBookInfo image);

        /// <summary>
        /// ����ͼƬ��Ϣ
        /// </summary>
        /// <param name="g"></param>
        int UpdateImageBook(ImageBookInfo image);

        /// <summary>
        /// ����ͼƬ��Ϣ
        /// </summary>
        /// <param name="g"></param>
        int UpdateImageBook(UpdateImageType type,int order,int imageID);

        /// <summary>
        /// ɾ��ͼƬ��Ϣ
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        int DeleteImageBookByID(int imageID);
    }
    
}
