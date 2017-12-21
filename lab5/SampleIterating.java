class SampleIterating { 
 
 public static void main(String[] args) {   long start, finish;   TreeNode<String> treeRoot;   start = System.currentTimeMillis();   treeRoot = SampleData.getSet1();   for (TreeNode<String> node : treeRoot) {    String indent = createIndent(node.getLevel());    System.out.println(indent + node.data);   }   finish = System.currentTimeMillis() - start;   System.out.println("\nОбхід першого дерева виконувався: " + finish + " мілісекунд");      start = System.currentTimeMillis();   treeRoot = SampleData.getSet2();   for (TreeNode<String> node : treeRoot) {    String indent = createIndent(node.getLevel());    System.out.println(indent + node.data);   }   finish = System.currentTimeMillis() - start;   System.out.println("\nОбхід другого дерева виконувався: " + finish + " мілісекунд"); 
    System.out.println("\nДерево для першого виразу:");   treeRoot = SampleData.getSet3();   for (TreeNode<String> node : treeRoot) {    String indent = createIndent(node.getLevel());    System.out.println(indent + node.data);   } 
 
  System.out.println("\nДерево для другого виразу:");   treeRoot = SampleData.getSet4();   for (TreeNode<String> node : treeRoot) {    String indent = createIndent(node.getLevel());    System.out.println(indent + node.data);   }  } 
 
 private static String createIndent(int depth) {   StringBuilder sb = new StringBuilder();   for (int i = 0; i < depth; i++) {    sb.append(' ');   }   return sb.toString();  }   
 
}