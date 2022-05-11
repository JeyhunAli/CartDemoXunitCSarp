using Xunit;

namespace OpenCartDemo

//retry attribute testing
{
    public class UnitTest1
    {
        [RetryFact(MaxRetries = 2)]
        public void Test1()
        {
            int a = 2;
            int b = 2;
            Assert.Equal(a, b);
        }

        [RetryFact(MaxRetries = 2)]
        public void Test2()
        {
            int a = 2;
            int b = 2;
            Assert.Equal(a, b);
        }

    }


}
