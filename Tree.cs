using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paisho
{
    public class Treenode<T>
    {
        private T value;
        private bool hasParent;
        private List<Treenode<T>> children;

        public Treenode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }
            this.value = value;
            this.children = new List<Treenode<T>>();

        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }

        public void AddChild(Treenode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentException("Cannot insert null value!");
            }
            if (child.hasParent)
            {
                throw new ArgumentException("The node already has a parent!");
            }
            child.hasParent = true;
            this.children.Add(child);
        }

        public Treenode<T> GetChild(int index)
        {
            return this.children[index];
        }
    }
    public class Tree<T>
    {
        private Treenode<T> root;
        
        public Tree (T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }
            this.root = new Treenode<T>(value);
        }

        public Tree (T value, params Tree<T>[] children):this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        public Treenode<T> Root
        {
            get
            {
                return this.root;
            }
        }
    }

}
