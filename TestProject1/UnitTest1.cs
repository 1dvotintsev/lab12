using lab12._1;
using CustomLibrary;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class MyListTests
        {
            [TestMethod]
            public void Test1()
            {
                int initialOverallCount = Id.overallCount;
                var id1 = new Id();
                Assert.AreEqual(initialOverallCount + 1, Id.overallCount);
            }

            [TestMethod]
            public void Test2()
            {
                var id1 = new Id();
                var id2 = new Id();
                Assert.AreNotEqual(id1.number, id2.number);
            }

            [TestMethod]
            public void Test3()
            {
                var testData = new Emoji(); 
                var node = new Node<Emoji>(testData);
                Assert.AreEqual(testData, node.Data);
            }

            [TestMethod]
            public void Test4()
            {
                var list = new MyList<Emoji>();
                var testData = new Emoji();
                list.AddToBegin(testData);
                Assert.AreEqual(1, list.Count);
                Assert.AreEqual(testData, list.beg.Data);
            }

            [TestMethod]
            public void Test5()
            {
                var list = new MyList<Emoji>();
                var testData = new Emoji(); 
                list.AddToBegin(testData);
                Assert.AreEqual(1, list.Count);
                list.Delete(list.beg);
                Assert.AreEqual(0, list.Count);
            }
            [TestMethod]
            public void Test6()
            {
                var list = new MyList<Emoji>();
                Assert.IsTrue(MyList<Emoji>.lists.Contains(list));
            }

            [TestMethod]
            public void Test7()
            {
                var list = new MyList<Emoji>(); 
                var testData1 = new Emoji();
                var testData2 = new Emoji(); 
                list.AddToEnd(testData1);
                list.AddToEnd(testData2);
                Assert.AreEqual(2, list.Count);
                list.Delete(list.end);
                Assert.AreEqual(1, list.Count);
                Assert.AreEqual(testData1, list.end.Data);
            }
            

            [TestMethod]
            [ExpectedException(typeof(Exception), "������ �� ���������������")]
            public void Test8()
            {
                var list = new MyList<Emoji>();
                list.Delete(list.beg);
            }

            [TestMethod]
            public void Test9()
            {
                int size = 5;
                var list = new MyList<Emoji>(size); 

                Assert.AreEqual(size, list.Count);
            }

            [TestMethod]
            [ExpectedException(typeof(Exception), "����������� ������")]
            public void Test10()
            {
                var list = new MyList<Emoji>(-1); 
            }

            [TestMethod]
            public void Test11()
            {
                var item1 = new Emoji(); 
                var item2 = new Emoji(); 
                var item3 = new Emoji(); 
                var collection = new Emoji[] { item1, item2, item3 };

                var list = new MyList<Emoji>(collection);
                
            }

            [TestMethod]
            public void Test12()
            {
                var originalList = new MyList<Emoji>(); 
                var item1 = new Emoji(); 
                var item2 = new Emoji(); 
                originalList.AddToEnd(item1);
                originalList.AddToEnd(item2);

                var clone = originalList.Clone();

                Assert.AreEqual(originalList.Count, clone.Count);

                // ���������, ��� ������ ������� � ����� ������������ � ������������ ������
                var originalCurrent = originalList.beg;
                var cloneCurrent = clone.beg;
                while (originalCurrent != null && cloneCurrent != null)
                {
                    Assert.AreEqual(originalCurrent.Data, cloneCurrent.Data);
                    originalCurrent = originalCurrent.Next;
                    cloneCurrent = cloneCurrent.Next;
                }
            }


            [TestMethod]
            [ExpectedException(typeof(Exception), "������ �� ���������������")]
            public void Test13()
            {
                var emptyList = new MyList<Emoji>();
                emptyList.Clone();
            }

            [TestMethod]
            public void Test14()
            {
                var list = new MyList<Emoji>(); // �������� �� ��� ��� ������
                var item1 = new Emoji(); // �������� �� ��� ��� ������
                var item2 = new Emoji(); // �������� �� ��� ��� ������
                list.AddToEnd(item1);
                list.AddToEnd(item2);

                list.Delete(list.beg);

                Assert.AreEqual(1, list.Count);
                Assert.AreEqual(item2, list.beg.Data);
            }

            [TestMethod]
            public void Text15()
            {
                var list = new MyList<Emoji>(); // �������� �� ��� ��� ������
                var item1 = new Emoji(); // �������� �� ��� ��� ������
                var item2 = new Emoji(); // �������� �� ��� ��� ������
                list.AddToEnd(item1);
                list.AddToEnd(item2);

                list.Delete(list.end);

                Assert.AreEqual(1, list.Count);
                Assert.AreEqual(item1, list.beg.Data);
            }

            [TestMethod]
            public void Test16()
            {
                var list = new MyList<Emoji>(); 
                var item1 = new Emoji();  
                var item2 = new Emoji(); 
                var item3 = new Emoji();
                list.AddToEnd(item1);
                list.AddToEnd(item2);
                list.AddToEnd(item3);

                list.Delete(list.beg.Next);

                Assert.AreEqual(2, list.Count);
                Assert.AreEqual(item1, list.beg.Data);
                Assert.AreEqual(item3, list.beg.Next.Data);
            }

            [TestMethod]
            [ExpectedException(typeof(Exception), "������ �� ���������������")]
            public void Test17()
            {
                var emptyList = new MyList<Emoji>(); 
                emptyList.Delete(null);
            }

            [TestMethod]
            public void Test18()
            {
                var list = new MyList<Emoji>();
                var emoji1 = new Emoji();
                emoji1.Name = "emoji1";
                var emoji2 = new Emoji();
                emoji1.Name = "emoji2";
                list.AddToEnd(emoji1);
                list.AddToEnd(emoji2);

                list.DeleteByName("emoji1");

                Assert.AreEqual(1, list.Count);
            }

            [TestMethod]
            [ExpectedException(typeof(Exception), "������ �� ���������������")]
            public void Test19()
            {
                var emptyList = new MyList<Emoji>();
                emptyList.DeleteByName("someName");
            }

            [TestMethod]
            public void Test20()
            {
                var list = new MyList<Emoji>();
                var emoji1 = new Emoji();
                emoji1.Name = "emoji1";
                list.AddToEnd(emoji1);

                list.DeleteByName("emoji1");

                Assert.AreEqual(0, list.Count);
            }

            [TestMethod]
            public void Test21()
            {
                var list = new MyList<Emoji>();
                var originalCount = list.Count;
                var numberOfItemsToAdd = 3;

                list.AddRandomItemsToBegin(numberOfItemsToAdd);

                Assert.AreEqual(originalCount + numberOfItemsToAdd, list.Count);
                var current = list.beg;
                for (int i = 0; i < numberOfItemsToAdd; i++)
                {
                    Assert.IsNotNull(current);
                    Assert.IsNotNull(current.Data);
                    current = current.Next;
                }
            }

            [TestMethod]
            [ExpectedException(typeof(Exception), "���������� �������������� ���������� ���������")]
            public void Test22()
            {
                var list = new MyList<Emoji>();
                list.AddRandomItemsToBegin(-1);
            }

            [TestMethod]
            public void Test23()
            {
                MyList<Emoji>.lists.Clear();
                MyList<Emoji>.CreateEmptyMyList();
                Assert.IsNotNull(MyList<Emoji>.lists[0]);
                Assert.AreEqual(0, MyList<Emoji>.lists[0].Count);
            }

            [TestMethod]
            public void Test24()
            {
                MyList<Emoji>.lists.Clear();
                var numberOfItems = 5;
                MyList<Emoji>.InitMyList(numberOfItems);
                Assert.IsNotNull(MyList<Emoji>.lists[0]);
                Assert.AreEqual(numberOfItems, MyList<Emoji>.lists[0].Count);
            }
        }
        [TestClass]
        public class NodeTests
        {
            [TestMethod]
            public void Test1()
            {
                var node = new Node<Emoji>(); 
                Assert.AreEqual(default(Emoji), node.Data);
                Assert.IsNull(node.Prev);
                Assert.IsNull(node.Next);
            }

            [TestMethod]
            public void Test2()
            {
                var node = new Node<Emoji>(); 
                Assert.AreEqual("��� ������", node.ToString());

                var data = new Emoji(); 
                node.Data = data;
                Assert.AreEqual(data.ToString(), node.ToString());
            }

            [TestMethod]
            public void Test3()
            {
                var node = new Node<Emoji>();
                Assert.AreEqual(0, node.GetHashCode());

                var data = new Emoji(); 
                node.Data = data;
                Assert.AreEqual(data.GetHashCode(), node.GetHashCode());
            }


            [TestMethod]
            public void Test4()
            {
                var node1 = new Node<Emoji>(); 
                var node2 = new Node<Emoji>(); 

                var data = new Emoji(); 
                node1.Data = data;
                node2.Data = data;
                Assert.IsTrue(node1.Equals(node2));

                var prevNode = new Node<Emoji>(); 
                node1.Prev = prevNode;
                node2.Prev = prevNode;
                Assert.IsTrue(node1.Equals(node2));

                var nextNode = new Node<Emoji>(); 
                node1.Next = nextNode;
                node2.Next = nextNode;
                Assert.IsTrue(node1.Equals(node2));
            }

            [TestMethod]
            public void Test5()
            {
                var node1 = new Node<Emoji>(); 
                var node2 = new Node<Emoji>(); 
                Assert.IsFalse(node1.Equals(null));
                Assert.IsFalse(node1.Equals(new object()));

                var data1 = new Emoji(); 
                var data2 = new Emoji(); 
                node1.Data = data1;
                node2.Data = data2;
                Assert.IsFalse(node1.Equals(node2));

                var prevNode1 = new Node<Emoji>(); 
                var prevNode2 = new Node<Emoji>(); 
                node1.Prev = prevNode1;
                node2.Prev = prevNode2;
                Assert.IsFalse(node1.Equals(node2));

                var nextNode1 = new Node<Emoji>(); 
                var nextNode2 = new Node<Emoji>(); 
                node1.Next = nextNode1;
                node2.Next = nextNode2;
                Assert.IsFalse(node1.Equals(node2));
            }

        }
    }
}