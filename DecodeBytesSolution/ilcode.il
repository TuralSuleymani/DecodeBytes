.assembly extern mscorlib {}
.assembly firstILProject {}
.module firstILProject.exe

.class public Program extends [mscorlib]System.Object
{
 .method public static void MyMain(string[] args) cil managed 
  {
	.entrypoint
	ldstr "Hello from IL code"
	call void [mscorlib]System.Console::WriteLine(string)
	call string [mscorlib]System.Console::ReadLine()
	pop
	ret
  }

}