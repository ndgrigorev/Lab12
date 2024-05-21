using ClassLibraryLab10;
using Lab12_3;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Animals animal = new Animals();
            Animals[] expected = new Animals[] { animal };
            MyTree<Animals> tree = new MyTree<Animals>(expected);
            Animals[] actual = tree.TreeToArray();
            Assert.AreEqual(expected[0], actual[0]);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Animals animal = new Animals();
            Animals[] animals = new Animals[10];
            for (int i = 0; i < 10; i++)
            {
                animal.RandomInit();
                animals[i] = animal;
            }
            MyTree<Animals> tree1 = new MyTree<Animals>(animals);
            tree1.TransformToFindTree();

            MyTree<Animals> tree2 = new MyTree<Animals>(animals);
            tree2.TransformToFindTree();
            Animals[] actual = tree1.TreeToArray();
            Animals[] expected = tree2.TreeToArray();
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}