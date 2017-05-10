using System;

namespace DotNetCorePOC.ConsoleApp.Model
{
    public abstract class BaseUser 
    {
        public string Name { get; set; }

        public abstract void Accept(IUserVisitor visitor);
    }

    public class User : BaseUser
    {
        public override void Accept(IUserVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class UserOnlyEqualsOverriten : BaseUser
    {
        public override void Accept(IUserVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override bool Equals (object obj)
        {
            return Name.Equals(((User)obj).Name);
        }
    }

    public class UserEqualsAndHashCodeOverriten : BaseUser
    {
        public override void Accept(IUserVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override bool Equals (object obj)
        {
            return Name.Equals(((BaseUser)obj).Name);
        }
        
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    public interface IUserVisitor
    {
        void Visit(User user);
        void Visit(UserOnlyEqualsOverriten user);
        void Visit(UserEqualsAndHashCodeOverriten user);
    }
}