using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting_with_C_sharp
{
    /// <summary>
    /// Heapsort works by first divide the unsorted list into a binary tree (Heapify) 
    /// where the root is the largest value
    /// 
    /// After the tree is created, the root value is swapped with the value in the far right leaf of the tree
    /// When the swap is performed, the binary tree is destroyed and needs to be rebuilt by the siftdown function
    /// </summary>

    class HeapSort
    {
        public static List<int> Sort(List<int> a)
        {
            BuildMaxHeap(a);
            int end = a.Count - 1;
            while (end > 0)
            {
                int temp = a[end];
                a[end]   = a[0];
                a[0]     = temp;
                end--;
                SiftDown(a, 0, end);
            }
            DisplayHeap(a, 1, 0);
            return a;
        }
        /// <summary>
        /// When the root is swapped the tree is destroyed (The root value is in the wrong position) and needs to be reconstructed
        /// </summary>
        /// <param name="a"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private static void SiftDown(List<int> a, int start, int end)
        {
            int root = start;

            while (LeftChild(root) <= end)
            {
                int child = LeftChild(root);
                int swap  = root;

                if (a[swap] < a[child])
                {
                    swap = child;
                }
                if (child + 1 < end && a[swap] < a[child + 1])
                {
                    swap = child + 1;
                }
                if (swap == root)
                {
                    return;
                }
                else
                {
                    int temp = a[root];
                    a[root]  = a[swap];
                    a[swap]  = temp;
                    root     = swap;
                }
            }
        }

        private static int LeftChild(int root)
        {
            return root * 2 + 1;
        }
        /// <summary>
        /// Builds a heap (binarytree) with the biggest value as the root
        /// The tree is represented by the index of an array
        /// A node with index NIndex will have children at NIndex * 2 + 1 and NIndex * 2 + 2
        /// For instance the root node (NIndex = 0) will have children at 0 * 2 + 1 = 1 and 0 * 2 + 2 = 2
        /// The node at index 1 has children at 3 and 4 
        /// </summary>
        /// <param name="a">List to be heapified</param>
        private static void BuildMaxHeap(List<int> a)
        {
            int halfCountA = (int) Math.Floor((decimal) ((a.Count - 1) / 2));
            for (int i = halfCountA; i >= 0 ; i--)
            {
                MaxHeapify(a, i);
            }
        }
        /// <summary>
        /// Builds a node by selecting the currently largest value in the list
        /// It picks the left and right child of the currently largest node and 
        /// pushes the child up if it is larger
        /// </summary>
        /// <param name="a">Unsorted list</param>
        /// <param name="i">Index of the current value of interest</param>
        private static void MaxHeapify(List<int> a, int i)
        {
            int left    = 2 * i + 1;
            int right   = 2 * i + 2;
            int largest = i;

            if (left < a.Count && a[left] > a[largest])
            {
                largest = left;
            }

            if (right < a.Count && a[right] > a[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                int temp = a[largest];
                a[largest] = a[i];
                a[i] = temp;
                MaxHeapify(a, largest);
            }
        }

        private static void DisplayHeap(List<int> heap, int depth, int root)
        {
            string depthString = new string('-', depth);
            if (root < heap.Count)
            {
                Console.WriteLine($"{depthString}{heap[root]}");
                depth++;
                DisplayHeap(heap, depth, root * 2 + 1);
                DisplayHeap(heap, depth, root * 2 + 2);
            }
        }
    }
}
