using System;
using BinaryTrees;
using BinaryTrees.InOrderTraversal;
using BinaryTrees.DFS;
using BinaryTrees.BFS;
using CreateShortestBinaryTree;
using CommonAncestor;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void FindsNoCommonAncestorWhenThereIsntOne()
        {
            var tree = BuildBunchOfIntNodes();
            var n1 = new TreeNode<int>(20);
            var n2 = new TreeNode<int>(26); // doesn't exist

            Assert.Null(CommonAncestor.FindCommonAncestor<int>.FindFirstCommonAncestor(tree, n1, n2));
        }

        [Fact]
        public void FindsCommonAncestor()
        {
            var tree = BuildBunchOfIntNodes();
            var n1 = new TreeNode<int>(20);
            var n2 = new TreeNode<int>(25); // doesn't exist

            var commonAncestor = CommonAncestor.FindCommonAncestor<int>.FindFirstCommonAncestor(tree, n1, n2);
            Assert.NotNull(commonAncestor);
            Assert.Equal(15, commonAncestor.Value);
        }

        [Fact]
        public void ShortestTreeIsCreated()
        {
            /* For this array, we expect a tree like :
                            8
                    4                  14
                2       6            12      16
            0               8
            i.e. of height 3. */
            //int[] sortedArray = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 16 };
            //var shortie = ShortestBinaryTree<int>.Go(sortedArray);

        }

        [Fact]
        public void TreeDepthIsCalculatedCorrectly()
        {
            /* For this array, we expect a tree like :
                            8
                    4                  14
                2       6            12      16
            0               8
            i.e. of height 3. */
            int[] sortedArray = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 16 };
            var shortie = ShortestBinaryTree<int>.Go(sortedArray);
            int depth = TreeDepth<int>.Go(shortie);
            Assert.Equal(3, depth);
        }

        [Fact]
        public void InOrderTraversal1()
        {
            var iot = new InOrderTraversal<int>();
            var tree = BuildBunchOfIntNodes();
            Assert.False(iot.Contains(tree, 1));
            Assert.False(iot.Contains(null, 1));
            Assert.True(iot.Contains(tree, 10));
            Assert.True(iot.Contains(tree, 25));
            Assert.False(iot.Contains(tree, 125));
        }

        [Fact]
        public void DFS1()
        {
            var dfs = new DFS<int>();
            var tree = BuildBunchOfIntNodes();
            Assert.False(dfs.Contains(tree, 1));
            Assert.False(dfs.Contains(null, 1));
            Assert.True(dfs.Contains(tree, 10));
            Assert.True(dfs.Contains(tree, 45));
            Assert.True(dfs.Contains(tree, 25));
            Assert.False(dfs.Contains(tree, 125));
        }

        [Fact]
        public void BFS1()
        {
            var bfs = new BFS<int>();
            var tree = BuildBunchOfIntNodes();
            Assert.False(bfs.Contains(tree, 1));
            Assert.False(bfs.Contains(null, 1));
            Assert.True(bfs.Contains(tree, 10));
            Assert.True(bfs.Contains(tree, 25));
            Assert.True(bfs.Contains(tree, 45));
            Assert.False(bfs.Contains(tree, 125));
        }
        /*
        Returns
                10
        15              50
    20      25      35      45
         */
        private TreeNode<int> BuildBunchOfIntNodes()
        {
            var root = new TreeNode<int>(10);
            var left = root.AddLeft(15);
            left.AddLeft(20);
            left.AddRight(25);
            var right = root.AddRight(50);
            right.AddLeft(35);
            right.AddRight(45);

            return root;
        }
    }
}
