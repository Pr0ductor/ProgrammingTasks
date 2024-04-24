Last login: Fri Apr 12 10:21:40 on console
denis@MacBook-Air-8 ~ % nano Program.cs






















  UW PICO 5.09                    File: Program.cs                    Modified  

        tree.AddElement(3);
        tree.Remove(1);

        var i = tree.DFS();
        foreach(var x in i)
            Console.WriteLine(x);
        
        Console.WriteLine("-------------");
        
        var l = tree.BFS();
        foreach (var m in l)
            Console.WriteLine(m);

        Console.WriteLine("----------------");
        
        Console.WriteLine(tree.Find(4));
        Console.WriteLine(tree.FindMin());
    }   
}

^G Get Help  ^O WriteOut  ^R Read File ^Y Prev Pg   ^K Cut Text  ^C Cur Pos   
^X Exit      ^J Justify   ^W Where is  ^V Next Pg   ^U UnCut Text^T To Spell  
