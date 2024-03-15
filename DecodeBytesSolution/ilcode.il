.assembly extern mscorlib {}
.assembly MyApp {}
.module MyApp.exe

.class public Program extends [mscorlib]System.Object
{
.method public static void MyEntryPoint(string[] args) cil managed
{
   .entrypoint
   .locals init([0] int32 Result)
    ldc.i4 0x34
    ldc.i4 0x32
    add
    stloc.0
    ldloc.0
    call void [mscorlib]System.Console::WriteLine(int32)
    ret
  }
}