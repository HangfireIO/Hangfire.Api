using Hangfire.Common;
// ReSharper disable All

namespace Samples
{
    class JobExamples
    {
        #region Supported Methods
        public interface IMyInterface
        {
            void Instance();
        }

        public class MyClass : IMyInterface
        {
            public static void Static() { /* ... */ }
            public void Instance() { /* ... */ }
            public void WithArguments(string arg1, int arg2) { /* ... */ }
        }

        public void CreateJobs()
        {
            var job1 = Job.FromExpression(() => MyClass.Static());

            var obj = new MyClass();
            var job2 = Job.FromExpression(() => obj.Instance());

            var job3 = Job.FromExpression<MyClass>(x => x.Instance());
            var job4 = Job.FromExpression<MyClass>(x => x.WithArguments("hello", 42));
            var job5 = Job.FromExpression<IMyInterface>(x => x.Instance());
        }
        #endregion

        #region Unsupported Methods
        // NotSupportedException – method is private
        private void PrivateMethod() { }

        // NotSupportedException – method contains parameter passed by reference.
        public void MethodWithRefParameter(ref int arg) { }

        // NotSupportedException – method contains output parameter.
        public void MethodWithOutParameter(out int arg) { arg = 1; }

        // NotSupportedException – method contains an open generic parameter.
        public void MethodWithGenericParameter<T>(T arg) { }
        #endregion
    }
}
