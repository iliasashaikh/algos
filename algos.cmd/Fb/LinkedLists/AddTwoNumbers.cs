using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb.LinkedLists
{


    public class AddTwoNumbers
    {
        public ListNode Add(ListNode l1, ListNode l2)
        {
            //edge cases- TODO

            var p = l1;
            var q = l2;

            ListNode prev = null;
            ListNode headOfResult = null;

            int carry = 0;

            while (p != null || q != null)
            {
                var pVal = p == null ? 0 : p.val;
                var qVal = q == null ? 0 : q.val;

                var sum = (pVal + qVal + carry) % 10;
                carry = (pVal + qVal + carry) / 10;

                var current = new ListNode(sum);

                if (prev != null)
                    prev.next = current;
                else
                    headOfResult = current;

                prev = current;
                p = p?.next;
                q = q?.next;
            }

            if (carry != 0)
                prev.next = new ListNode(carry);

            return headOfResult;

        }
    }
}
