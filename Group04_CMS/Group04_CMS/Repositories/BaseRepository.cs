using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group04_CMS.DAL;

namespace Group04_CMS.Repositories
{
    public class BaseRepository
    {
        private ApplicationDbContext _db = null;

        public ApplicationDbContext DbContext
        {
            get { return _db = _db ?? new ApplicationDbContext(); }
        }
    }
}