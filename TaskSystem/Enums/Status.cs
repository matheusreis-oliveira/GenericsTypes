using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum Status
    {
        [Description("Pending")]
        Pending = 0,
        [Description("InProgress")]
        InProgress = 1,
        [Description("Finished")]
        Finished = 2
    }
}
