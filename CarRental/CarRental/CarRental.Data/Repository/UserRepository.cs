using CarRental.Core.Entities;
using CarRental.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Repository
{
    public class UserRepository:IRepository<UserEntity>
    {
        readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<UserEntity> GetAllData()
        {
            return _dataContext.Users.ToList();
        }

        public UserEntity GetById(int id)
        {
           return _dataContext.Users.ToList().Find(u=>u.Id == id);
        }

        public bool Add(UserEntity user)
        {
            try
            {
                _dataContext.Users.Add(user);
                _dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(UserEntity user)
        {
          int i=  _dataContext.Users.ToList().FindIndex(u=>u.Id== user.Id);
            if (i<0)
                return false;

            if (user.Tz != "")
                _dataContext.Users.ToList()[i].Tz = user.Tz;
            if(user.Password!="")
                _dataContext.Users.ToList()[i].Password = user.Password;
            if(user.Email!="")
                _dataContext.Users.ToList()[i].Email = user.Email;
            if(user.Adress!="")
                _dataContext.Users.ToList()[i].Adress = user.Adress;
            if(user.Phone!="")
                _dataContext.Users.ToList()[i].Phone = user.Phone;
            if(user.Name!="")
                _dataContext.Users.ToList()[i].Name = user.Name;
            if(user.Zip_code>0)
                _dataContext.Users.ToList()[i].Zip_code = user.Zip_code;
            try
            {
                _dataContext.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool Delete(int id)
        {
            try
            {
              UserEntity u = _dataContext.Users.ToList().Find(c => c.Id==id);
               
                _dataContext.Users.Remove(u);
              _dataContext.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }


        public int GetIndexById(int id)
        {
            return _dataContext.Users.ToList().FindIndex(c => c.Id == id);
        }



    }
}
