public class Task1
{
	public Task1()
	{
        // First list
        ListNode list111 = new ListNode(1, null);
        ListNode list11 = new ListNode(3, list111);
        ListNode list1 = new ListNode(4, list11);
        ListNode curNode1 = new ListNode(2, list1);

        // Second list
        ListNode list22 = new ListNode(9, null);
        ListNode list2 = new ListNode(9, list22);
        ListNode curNode2 = new ListNode(9, list2);

        ShowNodes(curNode1);
        ShowNodes(curNode2);

        ListNode result = AddTwoNumbers(curNode1, curNode2);

        ShowNodes(result);
    }
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode result = new ListNode();

        ListNode buff1 = l1,
                 buff2 = l2,
                 curNode = result,
                 prevNode = result,
                 emptyNode = new ListNode(0, null);

        int sum;
        bool inMemmory = false;

        do
        {
            // 1st stage get sum of two nodes
            if (buff1 == null)
            {
                buff1 = emptyNode;
                sum = buff2.val;
            }
            if (buff2 == null)
            {
                buff2 = emptyNode;
                sum = buff1.val;
            }
            else
                sum = buff1.val + buff2.val;

            // 2nd stage when already in memmory
            if (inMemmory)
            {
                inMemmory = false;
                ++sum;
            }

            // 3nd stage check overflow and write
            // to resulting list
            if (sum > 9)
            {
                inMemmory = true;
                sum -= 10;
            }

            // Set value to current node
            curNode.val = sum;

            // Create new node and set as next
            ListNode tempNode = new ListNode();
            curNode.next = tempNode;

            // Set last node
            prevNode = curNode;

            // Change current node to next
            curNode = tempNode;

            // 4rd stage take next numbers from nodes
            buff1 = buff1.next;
            buff2 = buff2.next;
        }
        while ((buff1 != null) ||
               (buff2 != null));

        if (inMemmory)
            curNode.val = 1;
        else
            prevNode.next = null;

        return result;
    }
    void ShowNodes(ListNode node)
    {
        Console.Write(" node: " + node.val);
        node = node.next;

        while (node != null)
        {
            Console.Write($", {node.val}");
            node = node.next;
        }
        Console.WriteLine("");
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int ival = 0, ListNode inext = null)
        {
            val = ival;
            next = inext;
        }
    }
}