using System.ComponentModel;

namespace Domain.Categories
{
    public enum CategoryNeed
    {
        [Description("Essencial")]
        Essential = 1,

        [Description("Necessário")]
        Necessary = 2,

        [Description("Util")]
        Util = 3,
        
        [Description("Desnecessário")]
        Unnecessary = 4,        
    }
}