using CarRental.Entity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarRental.servises
{
    public class UserServise
    {
        
        public List<User> getUsers()
        {
            if(DataContextManager.DataContext.Users ==null)
                DataContextManager.DataContext.Users = new List<User>();
            return DataContextManager.DataContext.Users;
        }

        public User GetUserById(int id)
        {
            return DataContextManager.DataContext.Users.Find(user => user.Id == id);
        }

        public bool Update(int id, User user)
        {
            User ua = DataContextManager.DataContext.Users.Find(u => u.Id == id);
            if (ua == null)
                return false;
            DataContextManager.DataContext.Users.Remove(ua);
            DataContextManager.DataContext.Users.Add(user);
            return true;
        }
        public bool Add(User user)
        {

            if (this.GetUserById(user.Id) != null)
                return false;
            if (!this.IsValidIdNumber(user.Tz))
                return false;
            DataContextManager.DataContext.Users.Add(user);
            return true;
        }
        public bool DeleteUser(int id)
        {
            User user = DataContextManager.DataContext.Users.Find(i => i.Id == id);
            if (user == null)
                return false;
            DataContextManager.DataContext.Users.Remove(user);
            return true;
        }
       

        public bool IsValidIdNumber(string idNumber)
        {
            if (idNumber.Length != 9 || !IsAllDigits(idNumber))
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = int.Parse(idNumber[i].ToString());
                if (i % 2 == 0)
                {
                    sum += digit;
                }
                else
                {
                    sum += digit < 5 ? digit * 2 : digit * 2 - 9;
                }
            }

            return sum % 10 == 0;
        }

        static bool IsAllDigits(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }
    }


}

