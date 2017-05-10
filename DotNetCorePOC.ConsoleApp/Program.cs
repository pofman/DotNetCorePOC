using System;
using System.Collections;
using System.Collections.Generic;
using DotNetCorePOC.ConsoleApp.Model;

namespace DotNetCorePOC.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User
            {
                Name = "User without override"
            };

            var user2 = new User
            {
                Name = "User without override"
            };

            var user3 = new UserOnlyEqualsOverriten
            {
                Name = "User with equals only overriden"
            };

            var user4 = new UserOnlyEqualsOverriten
            {
                Name = "User with equals only overriden"
            };

            var user5 = new UserEqualsAndHashCodeOverriten
            {
                Name = "User with equals and hash code overriden"
            };

            var user6 = new UserEqualsAndHashCodeOverriten
            {
                Name = "User with equals and hash code overriden"
            };

            var list = new HashSet<BaseUser>();

            list.AddUser(user1);
            list.AddUser(user2);
            list.AddUser(user3);
            list.AddUser(user4);
            list.AddUser(user5);
            list.AddUser(user6);

            Console.WriteLine("----------------Results----------------");

            foreach(var user in list)
            {
                Console.WriteLine(user.Name);
            }

            Console.WriteLine("----------------Appling visitor----------------");
            var usersWithVisitor = new HashSet<BaseUser>();
            var usersAdder = new UserAdder(usersWithVisitor);

            usersAdder.AddUser(user1);
            usersAdder.AddUser(user2);
            usersAdder.AddUser(user3);
            usersAdder.AddUser(user4);
            usersAdder.AddUser(user5);
            usersAdder.AddUser(user6);
            
            Console.WriteLine("----------------Results----------------");

            foreach(var user in list)
            {
                Console.WriteLine(user.Name);
            }
        }
    }

    public static class UserHashSetExtensionMethod 
    {
        public static void AddUser(this HashSet<BaseUser> hashSet, BaseUser user)
        {
            if (user is User)
                Console.WriteLine("adding user of type: User");
            else if (user is UserOnlyEqualsOverriten)
                Console.WriteLine("adding user of type: UserOnlyEqualsOverriten");
            else if (user is UserEqualsAndHashCodeOverriten)
                Console.WriteLine("adding user of type: UserEqualsAndHashCodeOverriten");
            
            if(hashSet.Add(user))
                Console.WriteLine("User successfuly added");
            else
                Console.WriteLine("User already exists");
        }
    }

    public class UserAdder : IUserVisitor
    {
        public HashSet<BaseUser> Users { get; private set; }

        public UserAdder(HashSet<BaseUser> users)
        {
            Users = users;
        }

        public void AddUser(BaseUser user)
        {
            user.Accept(this);
            if(Users.Add(user))
                Console.WriteLine("User successfuly added");
            else
                Console.WriteLine("User already exists");
        }

        void IUserVisitor.Visit(User user)
        {
            Console.WriteLine("adding user of type: User");
        }

        void IUserVisitor.Visit(UserOnlyEqualsOverriten user)
        {
            Console.WriteLine("adding user of type: UserOnlyEqualsOverriten");
        }

        void IUserVisitor.Visit(UserEqualsAndHashCodeOverriten user)
        {
            Console.WriteLine("adding user of type: UserEqualsAndHashCodeOverriten");
        }
    }
}
