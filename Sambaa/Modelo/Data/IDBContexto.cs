using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Modelo.Data
{
    public class IDBContexto : DbContext, IHttpContextAccessor
    {
        public HttpContext HttpContext { get; set; }
        public IDBContexto(DbContextOptions options) : base(options) { }
    }
}
