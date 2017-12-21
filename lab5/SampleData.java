class SampleData { 
 
 public static TreeNode<String> getSet1() {   TreeNode<String> root = new TreeNode<String>("a");   {    TreeNode<String> b = root.addChild("b");    {     TreeNode<String> c = b.addChild("c");     TreeNode<String> d = b.addChild("d");    }    TreeNode<String> e = root.addChild("e");    {     TreeNode<String> f = e.addChild("f");     {      TreeNode<String> g = f.addChild("g");      TreeNode<String> h = f.addChild("h");     }    }   }   return root;  } 
 
 public static TreeNode<String> getSet2() {   TreeNode<String> root = new TreeNode<String>("a");   {    TreeNode<String> b = root.addChild("b");    {     TreeNode<String> c = b.addChild("c");     TreeNode<String> d = b.addChild("d");     TreeNode<String> e = b.addChild("e");    }    TreeNode<String> f = root.addChild("f");    {     TreeNode<String> g = f.addChild("g");     TreeNode<String> h = f.addChild("h"); 
   }   } 
 
  return root;  }    public static TreeNode<String> getSet3() {   TreeNode<String> root = new TreeNode<String>("-");   {    TreeNode<String> op1 = root.addChild("*");    {     TreeNode<String> a = op1.addChild("a");     TreeNode<String> b = op1.addChild("b");    }    TreeNode<String> op2 = root.addChild("/");    {     TreeNode<String> c = op2.addChild("c");     TreeNode<String> d = op2.addChild("d");    }   }   return root;  } 
 
 public static TreeNode<String> getSet4() {   TreeNode<String> root = new TreeNode<String>("/");   {    TreeNode<String> op1 = root.addChild("e"); 
 
   TreeNode<String> op2 = root.addChild("-");    {     TreeNode<String> c = op2.addChild("c");     TreeNode<String> d = op2.addChild("d");    }   }   return root;  } 
 
} 