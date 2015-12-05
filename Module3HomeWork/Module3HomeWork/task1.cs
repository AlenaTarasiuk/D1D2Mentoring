using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HomeWork
{
    class task1
    {
        public void ShowInfoAuthor()
        {
            Type type = typeof(TestClass);
            object[] attrs = type.GetCustomAttributes(false);
            foreach (UserValueAttribute attr in attrs)
            {
                Console.WriteLine("name : " + attr.Name + "\nemail : " + attr.Email);
            }
        }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited = true)]
        public sealed class UserValueAttribute : Attribute
        {
            public string Name { get; set; }
            public string Email { get; set; }

            public UserValueAttribute()
            {}

            public UserValueAttribute(string name, string email)
            {
                Name = name;
                Email = email;
            }
        }

        [UserValue(Name = "Alena", Email = "Alena_Tarasiuk@epam.com")]
        public class TestClass
        {
           public TestClass()
           {}
        }
    }
}
