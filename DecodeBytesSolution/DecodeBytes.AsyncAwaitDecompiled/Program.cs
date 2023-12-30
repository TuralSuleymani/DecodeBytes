// Decompiled with JetBrains decompiler
// Type: DecodeBytes.AsyncAwaitDemo.Program
// Assembly: DecodeBytes.AsyncAwaitDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A054FFA2-8758-4E77-A1C2-EB7713B64C7C
// Assembly location: C:\Projects\DecodeBytes\DecodeBytesSolution\DecodeBytes.AsyncAwaitDemo\bin\Debug\net8.0\DecodeBytes.AsyncAwaitDemo.dll
// Local variable names from c:\projects\decodebytes\decodebytessolution\decodebytes.asyncawaitdemo\bin\debug\net8.0\decodebytes.asyncawaitdemo.pdb
// Compiler-generated code is shown

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DecodeBytes.AsyncAwaitDemo
{

    internal class Program
    {
        private static void Calculate(Decimal firstNumber, Decimal secondNumber)
        {
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
            interpolatedStringHandler.AppendLiteral("Operation started in Thread ");
            interpolatedStringHandler.AppendFormatted<int>(Environment.CurrentManagedThreadId);
            Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
            interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
            interpolatedStringHandler.AppendLiteral("The result is ");
            interpolatedStringHandler.AppendFormatted<Decimal>(Program.Sum(firstNumber, secondNumber));
            Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
            interpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
            interpolatedStringHandler.AppendLiteral("Operation finished in Thread ");
            interpolatedStringHandler.AppendFormatted<int>(Environment.CurrentManagedThreadId);
            Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
        }

        private static Decimal Sum(Decimal firstNumber, Decimal secondNumber)
        {
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
            interpolatedStringHandler.AppendLiteral("Sum is running in Thread ");
            interpolatedStringHandler.AppendFormatted<int>(Environment.CurrentManagedThreadId);
            Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
            return Decimal.Add(firstNumber, secondNumber);
        }



        [AsyncStateMachine(typeof(CalculateV3StateMachine))]
        [DebuggerStepThrough]
        public static Task CalculateV3(Decimal firstNumber, Decimal secondNumber)
        {
            CalculateV3StateMachine stateMachine = new CalculateV3StateMachine();
            stateMachine.t__builder = AsyncTaskMethodBuilder.Create();
            stateMachine.firstNumber = firstNumber;
            stateMachine.secondNumber = secondNumber;
            stateMachine.state = -1;
            stateMachine.t__builder.Start<CalculateV3StateMachine>(ref stateMachine);
            return stateMachine.t__builder.Task;
        }

        [AsyncStateMachine(typeof(SumAsyncStateMachine))]
        [DebuggerStepThrough]
        public static Task<Decimal> SumAsync(Decimal firstNumber, Decimal secondNumber)
        {
            SumAsyncStateMachine stateMachine = new SumAsyncStateMachine();
            stateMachine.t__builder = AsyncTaskMethodBuilder<Decimal>.Create();
            stateMachine.firstNumber = firstNumber;
            stateMachine.secondNumber = secondNumber;
            stateMachine.state = -1;
            stateMachine.t__builder.Start<SumAsyncStateMachine>(ref stateMachine);
            return stateMachine.t__builder.Task;
        }

        [AsyncStateMachine(typeof(MainStateMachine))]
        [DebuggerStepThrough]
        public static Task Main(string[] args)
        {
            MainStateMachine stateMachine = new MainStateMachine();
            stateMachine.t__builder = AsyncTaskMethodBuilder.Create();
            stateMachine.args = args;
            stateMachine.state = -1;
            stateMachine.t__builder.Start<MainStateMachine>(ref stateMachine);
            return stateMachine.t__builder.Task;
        }

        [AsyncStateMachine(typeof(GetContentAsyncstateMachine))]
        [DebuggerStepThrough]
        private static Task<string> GetContentAsync(string requestUri)
        {
            GetContentAsyncstateMachine stateMachine = new GetContentAsyncstateMachine();
            stateMachine.t__builder = AsyncTaskMethodBuilder<string>.Create();
            stateMachine.requestUri = requestUri;
            stateMachine.state = -1;
            stateMachine.t__builder.Start<GetContentAsyncstateMachine>(ref stateMachine);
            return stateMachine.t__builder.Task;
        }

    }

    [CompilerGenerated]
    public sealed class CalculateV3StateMachine :
    IAsyncStateMachine
    {
        public int state;
        public AsyncTaskMethodBuilder t__builder;
        public Decimal firstNumber;
        public Decimal secondNumber;
        private Decimal s__1;

        private TaskAwaiter<Decimal> u__1;


        void IAsyncStateMachine.MoveNext()
        {
            int num1 = this.state;//-1
            try
            {
                DefaultInterpolatedStringHandler interpolatedStringHandler;
                TaskAwaiter<Decimal> awaiter;
                int num2;
                if (num1 != 0)
                {
                    interpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
                    interpolatedStringHandler.AppendLiteral("Operation started in Thread ");
                    interpolatedStringHandler.AppendFormatted<int>(Environment.CurrentManagedThreadId);
                    Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
                    awaiter = Program.SumAsync(this.firstNumber, this.secondNumber).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        this.state = num2 = 0;
                        this.u__1 = awaiter;
                        CalculateV3StateMachine stateMachine = this;
                        this.t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Decimal>, CalculateV3StateMachine>(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = this.u__1;
                    this.u__1 = new TaskAwaiter<Decimal>();
                    this.state = num2 = -1;
                }
                this.s__1 = awaiter.GetResult();
                Console.WriteLine(string.Format("The result is {0}", (object)this.s__1));
                interpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
                interpolatedStringHandler.AppendLiteral("Operation finished in Thread ");
                interpolatedStringHandler.AppendFormatted<int>(Environment.CurrentManagedThreadId);
                Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
            }
            catch (Exception ex)
            {
                this.state = -2;
                this.t__builder.SetException(ex);
                return;
            }
            this.state = -2;
            this.t__builder.SetResult();
        }

        [DebuggerHidden]
        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }
    }

    [CompilerGenerated]
    public sealed class GetContentAsyncstateMachine :
    /*[Nullable(0)]*/
    IAsyncStateMachine
    {
        public int state;

        public AsyncTaskMethodBuilder<string> t__builder;

        public string requestUri;

        private string s__1;

        private TaskAwaiter<string> u__1;

        void IAsyncStateMachine.MoveNext()
        {
            int num1 = this.state;
            string s1;
            try
            {
                TaskAwaiter<string> awaiter;
                int num2;
                if (num1 != 0)
                {
                    awaiter = new HttpClient().GetStringAsync(this.requestUri).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        this.state = num2 = 0;
                        this.u__1 = awaiter;
                        GetContentAsyncstateMachine stateMachine = this;
                        this.t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, GetContentAsyncstateMachine>(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = this.u__1;
                    this.u__1 = new TaskAwaiter<string>();
                    this.state = num2 = -1;
                }
                this.s__1 = awaiter.GetResult();
                s1 = this.s__1;
            }
            catch (Exception ex)
            {
                this.state = -2;
                this.t__builder.SetException(ex);
                return;
            }
            this.state = -2;
            this.t__builder.SetResult(s1);
        }

        [DebuggerHidden]
        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }
    }

    [CompilerGenerated]
    public sealed class MainStateMachine :
    /*[Nullable(0)]*/
    IAsyncStateMachine
    {
        public int state;
        public AsyncTaskMethodBuilder t__builder;
        public string[] args;
        private TaskAwaiter u__1;

        void IAsyncStateMachine.MoveNext()
        {
            int num1 = this.state;
            try
            {
                TaskAwaiter awaiter;
                int num2;
                if (num1 != 0)
                {
                    awaiter = Program.CalculateV3(45M, 67M).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        this.state = num2 = 0;
                        this.u__1 = awaiter;
                        MainStateMachine stateMachine = this;
                        this.t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, MainStateMachine>(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = this.u__1;
                    this.u__1 = new TaskAwaiter();
                    this.state = num2 = -1;
                }
                awaiter.GetResult();
            }
            catch (Exception ex)
            {
                this.state = -2;
                this.t__builder.SetException(ex);
                return;
            }
            this.state = -2;
            this.t__builder.SetResult();
        }

        [DebuggerHidden]
        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }
    }

    [CompilerGenerated]
    public sealed class SumAsyncStateMachine :
    /*[Nullable(0)]*/
    IAsyncStateMachine
    {
        public int state;
        public AsyncTaskMethodBuilder<Decimal> t__builder;
        public Decimal firstNumber;
        public Decimal secondNumber;
        private TaskAwaiter u__1;


        void IAsyncStateMachine.MoveNext()
        {
            int num1 = this.state;
            Decimal result;
            try
            {
                TaskAwaiter awaiter;
                int num2;
                if (num1 != 0)
                {
                    awaiter = Task.Delay(TimeSpan.FromMilliseconds(10.0)).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        this.state = num2 = 0;
                        this.u__1 = awaiter;
                        SumAsyncStateMachine stateMachine = this;
                        this.t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, SumAsyncStateMachine>(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = this.u__1;
                    this.u__1 = new TaskAwaiter();
                    this.state = num2 = -1;
                }
                awaiter.GetResult();
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
                interpolatedStringHandler.AppendLiteral("Sum is running in Thread ");
                interpolatedStringHandler.AppendFormatted<int>(Environment.CurrentManagedThreadId);
                Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
                result = Decimal.Add(this.firstNumber, this.secondNumber);
            }
            catch (Exception ex)
            {
                this.state = -2;
                this.t__builder.SetException(ex);
                return;
            }
            this.state = -2;
            this.t__builder.SetResult(result);
        }

        [DebuggerHidden]
        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }
    }
}