using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Fb.Graphs
{
    public class RightSideView
    {

        /*
        [] -> null

        [1,2,3] 
            
         
         */


        public IList<int> GetRightSideView(TreeNode root)
        {

            if (root == null)
                return null;

            // row by row traversal
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            var result = new List<int>();

            while(q.Count > 0)
            {
                var rowQ = new Queue<TreeNode>();
                int rightMost = 0;

                while(q.Count > 0) 
                {
                    var n = q.Dequeue(); //3 
                    
                    if (n.left != null)
                        rowQ.Enqueue(n.left); //[]

                    if (n.right != null)
                        rowQ.Enqueue(n.right); // []

                    rightMost = n.val; // 3

                    q = rowQ; //[2,3]
                }

                result.Add(rightMost); //[1,3]
            }

            return result;
        }
    }
}
