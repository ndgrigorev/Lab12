using ClassLibraryLab10;
using À‡·12_1;

namespace TestProjectLab12_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyList<Animals> expected = new MyList<Animals>();
            Animals animal = new Animals(0, "name", "", 1);
            expected.AddToBegin(animal);

            MyList<Animals> actual = new MyList<Animals>();
            actual.AddToEnd(animal);

            Assert.AreEqual(expected.beg.Data, actual.beg.Data);
        }

        [TestMethod]
        public void TestMethod2()
        {
            MyList<Animals> expected = new MyList<Animals>(5);
            
            MyList<Animals> actual = new MyList<Animals>();
            actual = expected.Clone();

            Assert.AreEqual(expected.end.Data, actual.end.Data);
            Assert.AreEqual(expected.beg.Data, actual.beg.Data);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Animals animal = new Animals();
            Animals[] animals = new Animals[4];
            for (int i = 0; i < 4; i++)
            {
                animal.RandomInit();
                animals[i] = animal;
            }
            MyList<Animals> expected = new MyList<Animals>(animals);

            MyList<Animals> actual = new MyList<Animals>();
            for (int i = 0;i < 4; i++)
            {
                actual.AddToEnd(animals[i]);
            }

            Assert.AreEqual(expected.end.Data, actual.end.Data);
            Assert.AreEqual(expected.beg.Data, actual.beg.Data);
        }

        [TestMethod]
        public void TestMethod4()
        {
            MyList<Animals> expected = new MyList<Animals>();

            MyList<Animals> actual = new MyList<Animals>(1);
            actual.RemoveItem(actual.beg.Data);

            Assert.AreEqual(expected.beg, actual.beg);
        }

        [TestMethod]
        public void TestMethod5()
        {
            MyList<Animals> expected = new MyList<Animals>(5);

            MyList<Animals> actual = new MyList<Animals>();
            actual = expected.Clone();
            Animals animal = new Animals();
            animal.RandomInit();
            actual.AddToBegin(animal);
            actual.RemoveItem(actual.beg.Data);

            Assert.AreEqual(expected.beg.Data, actual.beg.Data);
        }

        [TestMethod]
        public void TestMethod6()
        {
            MyList<Animals> expected = new MyList<Animals>(5);

            MyList<Animals> actual = new MyList<Animals>();
            actual = expected.Clone();
            Animals animal = new Animals(0, "test", "", 99);
            actual.AddToEnd(animal);
            actual.RemoveItem(actual.end.Data);

            Assert.AreEqual(expected.end.Data, actual.end.Data);
        }

        [TestMethod]
        public void TestMethod7()
        {
            MyList<Animals> expected = new MyList<Animals>(5);

            MyList<Animals> actual = new MyList<Animals>();
            actual = expected.Clone();
            actual.AddToList(1, actual.beg.Data);
            actual.RemoveItem(actual.beg.Next.Data);

            Assert.AreEqual(expected.beg.Next.Data, actual.beg.Next.Data);
            Assert.AreEqual(expected.beg.Data, actual.beg.Data);
            Assert.AreEqual(expected.end.Data, actual.end.Data);
        }

        [TestMethod]
        public void TestMethod8()
        {
            MyList<Animals> expected = new MyList<Animals>(5);

            MyList<Animals> actual = new MyList<Animals>();
            actual = expected.Clone();
            actual.AddToList(1, actual.end.Data);
            actual.RemoveItem(actual.end.Data);

            Assert.AreEqual(expected.beg.Data, actual.beg.Data);
            Assert.AreEqual(expected.end.Data, actual.end.Data);
        }

        [TestMethod]
        public void TestMethod9()
        {
            MyList<Animals> expected = new MyList<Animals>();

            MyList<Animals> actual = new MyList<Animals>(4);
            actual.Delete();

            Assert.AreEqual(expected.beg, actual.end);
        }
    }
}