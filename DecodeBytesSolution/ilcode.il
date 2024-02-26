.assembly extern mscorlib {}
.assembly OOPIL {}
.module OOPIL.exe

.class Calculator extends [mscorlib]System.Object 
{
.method public void .ctor() 
 {
 ret
 }

.method public float32 Sum(float32,float32) 
 {
ldarg.1
ldarg.2
add
ret
 }
}

.class public Program extends [mscorlib]System.Object
{
.method public static void Main(string[] args)
{
.entrypoint
newobj instance void Calculator::.ctor()
ldc.r4 4.5
ldc.r4 45.67
call instance float32 Calculator::Sum(float32,float32)
call void [mscorlib]System.Console::WriteLine(float32)
call string [mscorlib]System.Console::ReadLine()
pop
ret
}

}

