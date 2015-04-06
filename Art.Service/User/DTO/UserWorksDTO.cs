using System;

namespace Art.Service.User.DTO
{
    /// <summary>
    /// ʵ����UserWorksDTO ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:41:13
    /// </summary>
    public class UserWorksDTO
    {
        /// <summary>
        /// ����ID
        /// </summary>
        public int WorksId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// ����Ʒ����(������ArtType)
        /// </summary>
        public int WorksType { get; set; }

        /// <summary>
        /// ����Ʒ��������
        /// </summary>
        public string WorksTypeName { get; set; }

        /// <summary>
        /// �û�ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// �û�����
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ����ƷͼƬ��ַ
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// �۸�
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WorksName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WorksDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? WorkSizeLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? WorkSizeWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? WorkSizeHeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? WorkSizeType { get; set; }

        /// <summary>
        /// ɾ����ʶ
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public long HotCount { get; set; }
    }

    /// <summary>
    /// ��ѯ������UserWorksQueryDTO ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:41:13
    /// </summary>
    public class UserWorksQueryDTO
    {
        /// <summary>
        /// ״̬
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// �Ƿ�ɾ����Ĭ��Ϊfalse
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// �û�ID
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string OrderBy { get; set; }
    }
}