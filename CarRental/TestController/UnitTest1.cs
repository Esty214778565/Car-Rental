using CarRental.Controllers;
using CarRental.Entity;
using CarRental.servises;
using Microsoft.AspNetCore.Mvc;

namespace TestController
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var t = 98;

            //get
            var res = new UserServise().getUsers();
            Assert.Equal(1, res.Count());
        }
        //getbyid
        [Fact]
        public void Test2()
        {
            var t = 4;
            var res = new UserServise().GetUserById(t);
            Assert.NotEqual(null, res);

        }
        [Fact]
        //put
        public void Test3()
        {
            User user = new User(1, "111", "aaa", "bbb", "kkk", "hhh", 97, "098");
            int id=1;
            var res=new UserServise().Update(id, user);
            Console.WriteLine(res);
            Assert.IsNotType<NotFoundResult>(res);
        }
        [Fact]
        public void Test4()
        {
            User user = new User(1,"111","aaa","bbb","kkk","hhh",97,"098");
            User user2 = new User(1,"56","aaa","bbb","kkk","hhh",97,"098");

            var t = new UserServise().Add(user);
            Assert.True(t);
        }
        [Fact]
        public void Test5()
        {
            int id = 1;
            var t=new UserController().Delete(id);
            Assert.IsType<NotFoundResult>(t);
        }




    }
}