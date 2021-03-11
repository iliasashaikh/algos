/*
    You are a product manager and currently leading a team to develop a new product. 
    Unfortunately, the latest version of your product fails the quality check. 
    Since each version is developed based on the previous version, all the versions after a bad version are also bad.

    Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.

    You are given an API bool isBadVersion(version) which returns whether version is bad. 
    Implement a function to find the first bad version. You should minimize the number of calls to the API.

    Example 1:

    Input: n = 5, bad = 4
    Output: 4
    Explanation:
    call isBadVersion(3) -> false
    call isBadVersion(5) -> true
    call isBadVersion(4) -> true
    Then 4 is the first bad version.
    Example 2:

    Input: n = 1, bad = 1
    Output: 1
 

    Constraints:


    1 <= bad <= n <= 231 - 1 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Fb.Search
{
    public class BadVersion
    {
        // 0 1 2 3 4
        // G G G B B

        // l=0, h=4 -> m = 2
        // l=3, h=4 -> m = 3
        // l=3, h=3 -> m = 3
        
        // 0
        // B

        int mid = 0;
        public int FirstBadVersionR(int n)
        {
            throw new NotImplementedException();
        }
    }
}
