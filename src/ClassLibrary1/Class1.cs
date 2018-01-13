using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public int Double(int x) => x * 2;

        public IObservable<int> DelayDouble(IObservable<int> source)
        {
            return source
                //.SelectMany(async i =>
                //{
                //    await Task.Delay(TimeSpan.FromMilliseconds(i));
                //    return i;
                //})
                .Select(i => i * 2);
        }

    }
}
