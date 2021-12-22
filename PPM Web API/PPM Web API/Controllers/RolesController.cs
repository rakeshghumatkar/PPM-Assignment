using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PPM_Web_API.Controllers
{
    public class RolesController : ApiController
    {

        public IEnumerable<Role> Get()
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Roles.ToList();
            }
        }


        public Role Get(int id)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Roles.FirstOrDefault(x => x.RoleId == id);
            }
        }


        public Role Post([FromBody] Role role)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Roles.Add(role);
                db.SaveChanges();
                return role;
            }
        }

        public Role Put(int id, [FromBody] Role role)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var existingRole = db.Roles.Where(s => s.RoleId == id).FirstOrDefault<Role>();
                if (existingRole != null)
                {
                    existingRole.RoleName = role.RoleName;
                    
                    db.SaveChanges();
                }

                return existingRole;
            }
        }

        [HttpDelete]
        public Role Delete(int id)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                Role p = db.Roles.FirstOrDefault(x => x.RoleId == id);
                db.Roles.Remove(p);
                db.SaveChanges();
                return p;
            }
        }
    }
}
