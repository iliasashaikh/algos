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
            int value = 0;

            while (p!=null || q!=null)
            {
                if (p == null)
                    value = q.val;
                else if (q == null)
                    value = p.val;
                else
                {
                    value = ((p.val + q.val) % 10) + carry;
                    carry = (p.val + q.val) / 10;
                }

                var current = new ListNode(value);

                if (prev != null)
                    prev.next = current;
                else
                    headOfResult = current;

                prev = current;
            }

            return headOfResult;
            
        }
    }
}
