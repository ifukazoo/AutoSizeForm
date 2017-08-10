using NUnit.Framework;
using System.Threading;

namespace AutoSizeFormTest
{
    [TestFixture]
    public class AutoSizeFormTest
    {
        [SetUp]
        public void setUp()
        {

        }

        [TearDown]
        public void tearDown()
        {

        }

        [Test]
        public void ShowTest()
        {
            var t = new Thread(() =>
            {
                AutoSizeForm.AutoSizeForm.Show(new string[] {
                    "道徳は便宜の異名である",
                    });
                AutoSizeForm.AutoSizeForm.Show(new string[] {
                    "左側通行と似たようなものである",
                    "道徳は便宜の異名である",
                    });
                AutoSizeForm.AutoSizeForm.Show(new string[] {
                    "道徳は便宜の異名である",
                    "左側通行と似たようなものである",
                    });
                AutoSizeForm.AutoSizeForm.Show(new string[] {
                    "道徳は便宜の異名である",
                    "人生は一箱のマッチに似ている．重大に扱うのは莫迦々々しい．",
                    "左側通行と似たようなものである",
                    });
                AutoSizeForm.AutoSizeForm.Show(new string[] {
                    "人生は一箱のマッチに似ている．重大に扱うのは莫迦々々しい．",
                    "道徳は便宜の異名である",
                    "左側通行と似たようなものである",
                    });
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
    }
}
