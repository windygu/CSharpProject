
namespace Roo.Data
{
    /// <summary>
    ///  "UserInfo" 标示目标表名
    ///  "Guid" 代表主键， 可以通过逗号分隔来指定多个主键
    /// </summary>
    [DataObject("TestModel", "ID")]
    public class TestModel
    {
        public TestModel()
        {
            this.ID = "001";
            this.Name = "卢杰杰";
            this.Age = 18;
        }
        [DataField("NVARCHAR(50)", true)]
        public string ID = string.Empty;

        [DataField("NVARCHAR(50)")]
        public string Name = string.Empty;

        [DataField("INT")]
        public int Age =0;
    }
}
