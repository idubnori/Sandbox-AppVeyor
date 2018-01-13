using System;
using System.Reactive.Subjects;
using Microsoft.Reactive.Testing;
using Xunit;

namespace ClassLibrary1.Tests
{
    public class UnitTest1 : ReactiveTest
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(9, 18)]
        [InlineData(-5, -10)]
        public void DoubleTest_Simple1(int x, int expected)
        {
            var actual = new Class1().Double(x);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DelayDouble_Simple1()
        {
            var testScheduler = new TestScheduler();
            var results = testScheduler.CreateObserver<int>();

            var testSource = testScheduler.CreateColdObservable(
                OnNext(0, 10),
                OnCompleted<int>(0)
            );
            new Class1().DelayDouble(testSource).Subscribe(results);

            testScheduler.Start();
            testScheduler.AdvanceBy(100);

            //results.Messages.AssertEqual(
            //    OnNext(10, 20),
            //    OnCompleted<int>(10)
            //    );

            Assert.Equal(2, results.Messages.Count);
        }
    }
}
