using Microsoft.EntityFrameworkCore;

namespace Authentication_Authorization_InASP.NET
{
    public class AutoAuthenDbcontext :DbContext
    {
        public AutoAuthenDbcontext(DbContextOptions<AutoAuthenDbcontext> options) 
            : base(options)
        {
                
        }
    }
}
