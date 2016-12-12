using System.Collections.Generic;

namespace LINQapi.Analyzer
{
    public class ExpressionTreeNodeComparer : IComparer<ExpressionTreeNode>
    {
        public int Compare(ExpressionTreeNode x, ExpressionTreeNode y)
        {
            if (x.ParentId == null)
            {
                if (y.ParentId == null)
                {
                    if (x.Id == y.Id)
                        return 0;
                    else if (x.Id > y.Id)
                        return 1;
                    else
                        return -1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y.ParentId == null)
                {
                    return 1;
                }
                else
                {
                    int retval = x.ParentId.GetValueOrDefault().CompareTo(y.ParentId.GetValueOrDefault());

                    if (retval != 0)
                    {
                        return retval;
                    }
                    else
                    {
                        if (x.Id == y.Id)
                            return 0;
                        else if (x.Id > y.Id)
                            return 1;
                        else
                            return -1;
                    }
                }
            }
        }
    }
}