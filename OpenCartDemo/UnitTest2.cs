using Xunit;

namespace OpenCartDemo
{
    public class UnitTest2
    {
        [Fact]
        [TestPriority(1)]
        public void Test_1()
        {
            int a = 2;
            int b = 2;
            Assert.Equal(a, b);
        }

        [Fact]
        [TestPriority(2)]
        public void Test_2()
        {
            int a = 2;
            int b = 2;
            Assert.Equal(a, b);
        }

        [Fact]
        [TestPriority(3)]
        public void Test_3()
        {
            int a = 2;
            int b = 2;
            Assert.Equal(a, b);
        }
    }


}