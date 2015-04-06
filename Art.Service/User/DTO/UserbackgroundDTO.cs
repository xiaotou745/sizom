namespace Art.Service.User.DTO
{
    /// <summary>
    /// ʵ����UserbackgroundDTO ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 22:19:55
    /// </summary>
    public class UserbackgroundDTO
    {
        /// <summary>
        /// ����ID
        /// </summary>
        public int BackgroundId { get; set; }

        /// <summary>
        /// �û�ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// �Ƿ�ɾ��(0δɾ����
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public int BgOrder { get; set; }
    }

    /// <summary>
    /// ��ѯ������UserbackgroundQueryDTO ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 22:19:55
    /// </summary>
    public class UserbackgroundQueryDTO
    {
    }
}