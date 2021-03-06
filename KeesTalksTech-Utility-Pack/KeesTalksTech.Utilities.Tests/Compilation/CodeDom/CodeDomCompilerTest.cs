﻿namespace KeesTalksTech.Utilities.Compilation.CodeDom
{
	using KeesTalksTech.Utilities.Compilation;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;

	[TestClass]
	public class CodeDomCompilerTest
	{
		[TestMethod]
		[TestCategory("UnitTest")]
        public void CodeDomCompilation_HelloWorld_Assembly()
		{
			var compiler = new CodeDomCompiler();

			var instruction = new CompilerInstructions();
			instruction.AssemblyLocations.Add(typeof(IProducer).Assembly.Location);
			instruction.AssemblyLocations.Add(typeof(object).Assembly.Location);
			instruction.ClassName = "_" + Guid.NewGuid().ToString("N");
			instruction.Code = @"using System;
public class " + instruction.ClassName + ": " + typeof(IProducer).FullName + @"
{
	public object Run() 
	{
		return ""Hello world!"";
	}
}";
			string result = compiler.RunProducer(instruction) as string;

			Assert.AreEqual("Hello world!", result);
		}
	}
}