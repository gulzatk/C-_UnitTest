using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListCycle
{
    // Definition for singly-linked list.
    public class MyListNode
    {
        public int val;
        public MyListNode next;
        public MyListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    public class MyLinkedList
    {
        public bool HasCycle(MyListNode head)
        {

            HashSet<MyListNode> checkList = new HashSet<MyListNode>();

            while (head != null)
            {
                if (!checkList.Contains(head))
                {
                    checkList.Add(head);
                    head = head.next;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
