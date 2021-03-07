namespace algos.Fb.LinkedLists
{
    public class MergeSortedLists
    {
        ListNode Merge(ListNode l1, ListNode l2)
        {
            var prehead = new ListNode(-1);
            var prev = prehead;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }

                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }

                prev = prev.next;
            }

            prev.next = l1 == null ? l2 : l1;
            prev.next = l2 == null ? l1 : l2;

            return prehead.next;
        }
    }
}