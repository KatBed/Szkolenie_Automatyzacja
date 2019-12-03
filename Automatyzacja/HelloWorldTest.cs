using Xunit; //pojawia się przy instalacji xunit

namespace Automatyzacja
{
    public class HelloWorldTest //klasa musi byc publiczna
    {
        [Fact] //atrybut,alt+enter (using xunit)
        public void CanSayHello() //nic nie zwraca, nic nie przyjmuje na wejściu
        {
            //arrange stan początkowy
            var a = 1;
            var b = 2;
            //act test
            var result = Function(a, b);
            //assert czy to co dostalismy jest tym co chcieliśmy
            Assert.Equal(42, result);
        }
        private int Function(int a, int b)
        {
            return 42;
        }
    }
}
