using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethodsLib
{
    internal class TreeSort
    {
        public class Node
        {
            public int key;
            public Node left, right;

            public Node(int item)
            {
                key = item;
                left = right = null;
            }
        }

        // Root of BST
        public Node root;

        // Constructor
        public TreeSort()
        {
            root = null;
        }

        // This method mainly
        // calls insertRec()
        void insert(int key)
        {
            root = insertRec(root, key);
        }

        /* A recursive function to
          insert a new key in BST */
        Node insertRec(Node root, int key)
        {

            /* If the tree is empty,
                return a new node */
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            /* Otherwise, recur
                down the tree */
            if (key < root.key)
                root.left = insertRec(root.left, key);
            else if (key > root.key)
                root.right = insertRec(root.right, key);

            /* return the root */
            return root;
        }

        // A function to do
        // inorder traversal of BST
        public void inorderRec(Node root)
        {
            if (root != null)
            {
                inorderRec(root.left);
                inorderRec(root.right);
            }
        }
        public void treeins(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                insert(arr[i]);
            }
            
        }
    }

}



