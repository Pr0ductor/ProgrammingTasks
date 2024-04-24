Last login: Fri Apr 12 10:21:40 on console
denis@MacBook-Air-8 ~ % nano Program.cs
denis@MacBook-Air-8 ~ % nano Tree.cs





















  UW PICO 5.09                     File: Tree.cs                      Modified  

            else
            {
                if (currentNode.Left == null)
                {
                    return currentNode.Right;
                }
                else if (currentNode.Right == null)
                {
                    return currentNode.Left;
                }
            
                currentNode.Value = FindMin();
                currentNode.Right = RemoveRecursive(currentNode.Right, currentN$
            }    
                    
            return currentNode;
        }       
    }            
}                   
                            [ Unknown Command: ^S ]                             
^G Get Help  ^O WriteOut  ^R Read File ^Y Prev Pg   ^K Cut Text  ^C Cur Pos   
^X Exit      ^J Justify   ^W Where is  ^V Next Pg   ^U UnCut Text^T To Spell  
