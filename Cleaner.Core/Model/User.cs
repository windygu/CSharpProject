using Roo.Data;

namespace Cleaner.Core
{
    [DataObject("User", "UserID")]
    public class User
    {
        [DataField("NVARCHAR(50)", Description = "用户编号")]
        public string UserID { get; set; }

        [DataField("NVARCHAR(50)", Description = "用户名称")]
        public string UserName { get; set; }

        [DataField("NVARCHAR(50)", Description = "联系电话")]
        public string PhoneNo { get; set; }

        [DataField("NVARCHAR(50)", Description = "地址")]
        public string Address { get; set; }

        [DataField("DOUBLE", Description = "金额")]
        public double Money { get; set; }

        [DataField("NVARCHAR(50)", Description = "性别")]
        public string Sex { get; set; }

        [DataField("INT", Description = "积分")]
        public int Score { get; set; }

        [DataField("INT", Description = "折扣")]
        public int ZheKou { get; set; }

        [DataField("NVARCHAR(50)", Description = "备注")]
        public string BeiZhu { get; set; }
    }
}
