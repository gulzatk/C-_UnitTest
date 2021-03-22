using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LinkedListCycle;

namespace LinkedListCycleTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LinkedListTest_NullReturnsFalse()
        {
            // Arrange
            MyLinkedList l = new MyLinkedList();

            // Act
            bool result = l.HasCycle(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LinkedListTest_SingleElementNoCycleReturnsFalse()
        {
            // Arrange
            MyLinkedList l = new MyLinkedList();
            MyListNode head = new MyListNode(1);

            // Act
            bool result = l.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LinkedListTest_SingleElementYesCycleReturnsTrue()
        {
            // Arrange
            MyLinkedList l = new MyLinkedList();
            MyListNode head = new MyListNode(1);
            head.next = head;

            // Act
            bool result = l.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LinkedListTest_TwoElementNoCycleReturnsFalse()
        {
            // Arrange
            MyLinkedList l = new MyLinkedList();
            MyListNode head = new MyListNode(1);
            MyListNode value2 = new MyListNode(2);
            head.next = value2;

            // Act
            bool result = l.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LinkedListTest_TwoElementYesCycleReturnsTrue()
        {
            // Arrange
            MyLinkedList l = new MyLinkedList();
            MyListNode head = new MyListNode(1);
            MyListNode value2 = new MyListNode(2);
            head.next = value2;
            value2.next = head;

            // Act
            bool result = l.HasCycle(head);

            // Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void LinkedListTest_MultipleElementNoCycleReturnsFalse()
        {
            // Arrange
            MyLinkedList l = new MyLinkedList();
            MyListNode head = new MyListNode(1);
            MyListNode value2 = new MyListNode(2);
            MyListNode value3 = new MyListNode(3);
            MyListNode value4 = new MyListNode(4);
            head.next = value2;
            value2.next = value3;
            value3.next = value4;

            // Act
            bool result = l.HasCycle(head);

            // Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void LinkedListTest_LastElementsNextIsFirstReturnsTrue()
        {
            // Arrange
            MyLinkedList l = new MyLinkedList();
            MyListNode head = new MyListNode(1);
            MyListNode value2 = new MyListNode(2);
            MyListNode value3 = new MyListNode(3);
            MyListNode value4 = new MyListNode(4);
            head.next = value2;
            value2.next = value3;
            value3.next = value4;
            value4.next = head;

            // Act
            bool result = l.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LinkedListTest_LastElementsNextIsMiddleReturnsTrue()
        {
            // Arrange
            MyLinkedList l = new MyLinkedList();
            MyListNode head = new MyListNode(1);
            MyListNode value2 = new MyListNode(2);
            MyListNode value3 = new MyListNode(3);
            MyListNode value4 = new MyListNode(4);
            head.next = value2;
            value2.next = value3;
            value3.next = value4;
            value4.next = value3;

            // Act
            bool result = l.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
