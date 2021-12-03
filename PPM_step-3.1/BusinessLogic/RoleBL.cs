using System;
using System.Collections.Generic;
using System.Linq;
using PPM_DAL;
using System.Text;
using System.Threading.Tasks;
using PPM_DAL_EF;

namespace BusinessLogic
{
    public class RoleBL : IRoleOperation
    {
        public List<RoleModel> RoleList = new List<RoleModel>();

        public RoleBL()
        { }

        public void AddRole(RoleModel role)
        {
            RoleList.Add(role);
        }
        public void DeleteRole(int roleId)
        {
           
            DeleteRoleFromDB_ADO(roleId);
        }
        public void DeleteRole(RoleModel role)
        {
            RoleList.Remove(role);
            DeleteRoleFromDB_ADO(role.roleId);
        }
        public void DeleteRoleFromDB_ADO(int rid)
        {
            RolesDA db = new RolesDA();
            db.DeleteRole(rid);
        }

        public List<RoleModel> GetRole()
        {
            RoleList.Sort();
            return RoleList;
        }

        public bool IsRoleExist(int rid)
        {
            for (int i = 0; i < RoleList.Count; i++)
            {
                if (rid == RoleList[i].roleId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Validation(RoleModel role)
        {
            if ((role.roleId == null) || (role.roleName == ""))
                return false;
            else if (RoleList.Contains(role))
                return false;
            else if (IsRoleExist(role.roleId))
                return false;
            else if (IsRoleExistInDB(role.roleId))
                return false;
            else
                return true;
        }

        public RoleModel GetRole(int rid)
        {
            RoleModel role = new RoleModel();
            for (int i = 0; i < RoleList.Count; i++)
            {
                if (rid == RoleList[i].roleId)
                {
                    role = RoleList[i];
                    return role;
                }
            }
            return role;
        }
       
        public void SaveIntoFile()
        {
            try
            {
                string filePath = "C:\\Users\\rakes\\source\\repos\\PPM_step-3.1\\RoleFile.xml";
                XMLFileData data = new XMLFileData();
                data.XmlSerialize(typeof(List<RoleModel>), RoleList, filePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void SaveIntoDB_ADO(RoleModel role)
        {
            RolesDA db = new RolesDA();
            db.SaveRole(role.roleId, role.roleName);
           
        }

        public void DeleteAllRecord()
        {
            RoleList.Clear();
        }

        public void GetRoleFromDB()
        {
            RolesDA db = new RolesDA();
            string query = "Select *from Roles;";
            db.GetRole(query);
        }

        public void GetRoleFromDB(int roleId)
        {

            RolesDA db = new RolesDA();
            string query = "Select *from Roles where roleId = " + roleId+";";
            db.GetRole(query);
        }

        public bool IsRoleExistInDB(int roleId)
        {
            CommonOperation db = new CommonOperation();
            string query = "Select *from Roles where roleId = " + roleId + ";";
            bool flag = false;
            db.IsExist(query, ref flag);
            return flag;
        }

        public void UpdateRole(int rid , string rName)
        {
            CommonOperation db = new CommonOperation();
            string query = "Update Roles set roleName = '"+rName+ "',modifiedDate= CURRENT_TIMESTAMP where roleId = " + rid+" ";
            db.ExcuteQuery(query);
        }


        public void SaveRoleUsingEF(RoleModel role)
        {
            PPMEntities db = new PPMEntities();
            Role r = new Role();
            r.roleId = role.roleId;
            r.roleName = role.roleName;
            r.createDate = DateTime.Now;
            r.modifiedDate = DateTime.Now;
            db.Roles.Add(r);
            db.SaveChanges();
        }




    }
}
