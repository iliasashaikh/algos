using NUnit.Framework;
using NUnitLite;
using System;
using System.Reflection;

public class Runner
{
    public static int Main(string[] args)
    {
        return new AutoRun(Assembly.GetCallingAssembly())
                .Execute(new String[] { "--prefilter=algos.Fb.BinaryTreeLevelLists" });
        // return new AutoRun(Assembly.GetCallingAssembly()).Execute(new String[] { "--labels=All" });
        // return new AutoRun(Assembly.GetCallingAssembly()).Execute(null);
    }
}
