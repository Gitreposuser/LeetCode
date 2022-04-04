public class Task2
{
	public Task2()
	{
        ListNode l1 = new ListNode(9, null);
        //l1 = new ListNode(9, l1);
        //l1 = new ListNode(9, l1);

        ListNode l2 = new ListNode(9, null);
        //l2 = new ListNode(9, l2);
        //l2 = new ListNode(9, l2);
        //l2 = new ListNode(9, l2);
        //l2 = new ListNode(9, l2);

        ShowNodes(l1);
        ShowNodes(l2);

        ListNode result = AddTwoNumbers(l1, l2);

        ShowNodes(result);
    }
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode result = null;
        byte onePlus = 0;
        byte node1;
        byte node2;
        byte sumDigits = 0;

        while ((l1 != null) || (l2 != null))
        {
            if (l1 == null)
                node1 = 0;
            else
            {
                node1 = (byte)l1.val;
                l1 = l1.next;
            }

            if (l2 == null)
                node2 = 0;
            else
            {
                node2 = (byte)l2.val;
                l2 = l2.next;
            }

            sumDigits = (byte)(node1 + node2 + onePlus);

            if (sumDigits > 9)
            {
                sumDigits = (byte)(sumDigits % 10);
                onePlus = 1;
            }
            else
            {
                sumDigits = sumDigits;
                onePlus = 0;
            }

            result = new ListNode(sumDigits, result);
        }

        if (onePlus == 1)
            result = new ListNode(1, result);

        // Reverse list
        ListNode reversed = null;
        while (result != null)
        {
            reversed = new ListNode(result.val, reversed);
            result = result.next;
        }

        return reversed;
    }
    public static void ShowNodes(ListNode node)
    {
        Console.WriteLine(" *** list node ***");
        while (node != null)
        {
            Console.WriteLine(" val = " + node.val);
            node = node.next;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}