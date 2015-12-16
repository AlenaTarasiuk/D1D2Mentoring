using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LinqSamples
{
    [Serializable]
    public class Class1
    {
        [Title ("Production assembly 4")]
        public void Linq1()
        {
 
        }
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class Category : Attribute
{
    private string category;

    public Category(string category)
    {
        this.category = category;
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class Title : Attribute
{
    private string title;

    public Title(string title)
    {
        this.title = title;
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class Title : Attribute
{
    private string title;

    public Title(string title)
    {
        this.title = title;
    }
}