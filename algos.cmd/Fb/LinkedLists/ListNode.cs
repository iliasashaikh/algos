using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Fb.LinkedLists
{
    public class ListNode
    {
        public ListNode(int value = 0, ListNode next = null)
        {
            this.val = value;
            this.next = next;
        }

        public int val { get; set; }
        public ListNode next { get; set; }
    }
}
