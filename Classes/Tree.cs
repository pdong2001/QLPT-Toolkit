using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class Tree<K, V>
    {
        List<Node<K, V>> root;
        int rank = 1;
        Node<K, V> currentNode = null;
        public Node<K, V> PreNode
        {
            get => currentNode != null ? currentNode.PreNode : null;
        }
        public Node<K, V> NextNode
        {
            get => currentNode != null ? currentNode.NextNode : null;
        }
        public Node<K, V> CurrentNode
        {
            get => currentNode;
        }
        public int Rank { get => rank; set => rank = value; }
        public void RefreshRank()
        {
            for (int i = 0; i < root.Count; i++)
            {
                int temp = root[i].GetRank();
                if (temp > Rank)
                {
                    Rank = temp;
                }
            }
        }

        public Node<K, V> this[K Key]
        {
            get
            {
                Node<K, V> rs = null;
                for (int i = 0; i < root.Count; i++)
                {
                    if (root[i].Key.Equals(Key))
                    {
                        rs = root[i];
                        break;
                    }
                }
                currentNode = rs;
                return rs;
            }
            set
            {
                for (int i = 0; i < root.Count; i++)
                {
                    if (root[i].Key.Equals(Key))
                    {
                        root[i] = value;
                        break;
                    }
                }
            }
        }
        public Tree()
        {
            root = new List<Node<K, V>>();
        }
        public void AddNode(K[] rootKeys, K Key, V Value)
        {
            Node<K, V> temp = null;
            if (root.Count == 0 || rootKeys == null)
            {
                temp = new Node<K, V>(Key, Value);
                if (root.Count > 0)
                {
                    temp.PreNode = root[root.Count - 1];
                    root[root.Count - 1].NextNode = temp;
                }
                root.Add(temp);
                currentNode = temp;
            }
            else
            {
                temp = this[rootKeys[0]];
                currentNode = temp;
                if (rootKeys.Length > Rank)
                {
                    throw new IndexOutOfRangeException();
                }
                for (int i = 1; i < rootKeys.Length; i++)
                {
                    temp = temp[rootKeys[i]];
                    if (temp == null)
                    {
                        throw new Exception("Không tìm thấy key phù hợp!");
                    }
                }
                try
                {
                    temp.AddChild(new Node<K, V>(Key, Value));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public void RemoveNode(K[] rootKeys)
        {
            Node<K, V> temp = this[rootKeys[0]];
            if (rootKeys.Length > Rank)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = 1; i < rootKeys.Length; i++)
            {
                temp = temp[rootKeys[i]];
                if (temp == null)
                {
                    throw new Exception("Không tìm thấy key phù hợp!");
                }
            }
            if (rootKeys.Length == Rank)
            {
                Rank++;
            }
        }
        public Node<K, V> FindNode(int MaxRank, Compare comparer)
        {
            Node<K, V> RS;
            RS = FindNode(root[0], 1, MaxRank, comparer);
            return RS;
        }

        public List<Node<K, V>> GetAllChild(int Rank)
        {
            return GetAllChild(root, Rank, 1);
        }
        private List<Node<K, V>> GetAllChild(List<Node<K, V>> root, int Rank, int curRank)
        {
            List<Node<K, V>> RS = root;
            bool Flag = true;
            for (int i = 0; i < root.Count; i++)
            {
                if (root[i].Child.Count > 0)
                {
                    if (Flag)
                    {
                        RS = new List<Node<K, V>>();
                        Flag = false;
                    }
                    RS.AddRange(root[i].Child);
                }
            }
            if (Rank > curRank)
            {
                return GetAllChild(RS, Rank, ++curRank);
            }
            else
            {
                return RS;
            }
        }
        //public Node<K, V> FindNode(K Key)
        //{

        //}
        public Node<K, V> FindNode(Compare comparer)
        {
            return FindNode(root, Rank, 1, comparer);
        }
        private Node<K, V> FindNode(List<Node<K, V>> root, int Rank, int curRank, Compare comparer)
        {
            List<Node<K, V>> RS = root;
            bool Flag = true;
            for (int i = 0; i < root.Count; i++)
            {
                if (root[i].Child.Count > 0)
                {
                    if (Flag)
                    {
                        RS = new List<Node<K, V>>();
                        Flag = false;
                    }
                    RS.AddRange(root[i].Child);
                }
                if (comparer(root[i].Key))
                {
                    return root[i];
                }
            }
            if (Rank > curRank)
            {
                return FindNode(RS, Rank, ++curRank, comparer);
            }
            else
            {
                return null;
            }
        }
        private Node<K, V> FindNode(Node<K, V> root, int Rank, int MaxRank, Compare comparer)
        {
            if (comparer(root.Key))
            {
                return root;
            }
            else if (root.NextNode != null)
            {
                return FindNode(root.NextNode, Rank, MaxRank, comparer);
            }
            else if (root.Child != null && root.Child.Count > 0 && Rank < MaxRank)
            {
                return FindNode(root.Child[0], ++Rank, MaxRank, comparer);
            }
            else if (root.Root != null)
            {
                if (root.Root.PreNode != null)
                {
                    if (root.Root.PreNode.Child != null && root.Root.PreNode.Child.Count > 0)
                        return FindNode(root.Root.PreNode.Child[0], --Rank, MaxRank, comparer);
                }
                else if (root.Root.Root.PreNode != null)
                {
                    return FindNode(root.Root.Root.PreNode, Rank - 2, MaxRank, comparer);
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        public delegate bool Compare(K Key);
    }
    public class Node<TKey, TValue>
    {
        List<Node<TKey, TValue>> child;
        Node<TKey, TValue> preNode;
        Node<TKey, TValue> nextNode;
        Node<TKey, TValue> root;
        Node<TKey, TValue> currentNode;
        private int rank;
        TKey key;
        TValue value;
        public bool IsRoot
        {
            get => Child != null && Child.Count > 0;
        }
        public List<Node<TKey, TValue>> Child { get => child; set => child = value; }
        public Node<TKey, TValue> PreNode { get => preNode; set => preNode = value; }
        public Node<TKey, TValue> NextNode { get => nextNode; set => nextNode = value; }
        public TKey Key { get => key; set => key = value; }
        public TValue Value { get => value; set => this.value = value; }
        public int Rank
        {
            get => rank;
            set
            {
                if (Root != null && Root.Rank <= Rank)
                {
                    Root.Rank++;
                }
            }
        }
        public Node<TKey, TValue> Root { get => root; set => root = value; }
        public Node<TKey, TValue> CurrentNode { get => currentNode; set => currentNode = value; }

        public Node<TKey, TValue> this[TKey Key]
        {
            get
            {
                Node<TKey, TValue> rs = null;
                for (int i = 0; i < child.Count; i++)
                {
                    if (child[i].Key.Equals(Key))
                    {
                        rs = child[i];
                        break;
                    }
                }
                currentNode = rs == null ? currentNode : rs;
                return rs;
            }
            set
            {
                for (int i = 0; i < child.Count; i++)
                {
                    if (child[i].Key.Equals(Key))
                    {
                        child[i] = value;
                        break;
                    }
                }
            }
        }
        public Node()
        {
            PreNode = null;
            NextNode = null;
            Child = new List<Node<TKey, TValue>>();
            rank = 0;
        }
        public Node(Node<TKey, TValue> node)
        {
            this.Child = node.Child;
            this.PreNode = node.PreNode;
            this.NextNode = node.NextNode;
            this.Key = node.Key;
            this.Value = node.Value;
            this.rank = node.Rank;
        }
        public Node(TKey Key, TValue Value)
        {
            this.Key = Key;
            this.Value = Value;
            rank = 1;
            Child = new List<Node<TKey, TValue>>();
        }
        public void AddChild(Node<TKey, TValue> node)
        {
            node.NextNode = null;
            node.PreNode = null;
            if (Child == null || Child.Count == 0)
            {
                Child = new List<Node<TKey, TValue>>();
            }
            else
            {
                node.PreNode = child[child.Count - 1];
                child[child.Count - 1].NextNode = node;
                for (int i = 0; i < Child.Count; i++)
                {
                    if (Child[i].Key.Equals(node.Key))
                    {
                        throw new Exception("Không thể nhập vào 1 key đã tồn tại.");
                    }
                }
            }
            if (node.Rank == this.Rank)
            {
                this.rank = node.Rank + 1;
            }
            node.Root = this;
            currentNode = node;
            Child.Add(node);
        }
        public void AddChild(TKey Key, TValue Value)
        {
            AddChild(new Node<TKey, TValue>(Key, Value));
        }
        public void RemoveChild(TKey Key)
        {
            int Rank = 0;
            for (int i = 0; i < child.Count; i++)
            {
                if (child[i].Rank >= Rank)
                {
                    if (!child[i].Key.Equals(Key))
                    {
                        Rank = child[i].Rank;
                    }
                    else
                    {
                        if (child[i] == currentNode)
                        {
                            currentNode = null;
                        }
                        child.RemoveAt(i);
                    }
                }
            }
            this.Rank = Rank;
        }
        public override string ToString()
        {
            return $"{key}:{value}";
        }
        private int GetRank(List<Node<TKey, TValue>> root, int Rank)
        {
            List<Node<TKey, TValue>> RS = root;
            bool Flag = true;
            for (int i = 0; i < root.Count; i++)
            {
                if (root[i].Child.Count > 0)
                {
                    if (Flag)
                    {
                        RS = new List<Node<TKey, TValue>>();
                        Flag = false;
                    }
                    RS.AddRange(root[i].Child);
                }
            }
            if (Flag)
            {
                return Rank;
            }
            else
            {
                return GetRank(RS, Rank + 1);
            }
        }
        public int GetRank()
        {
            Rank = GetRank(child, 1) + 1;
            return Rank;
        }
        public Node<TKey, TValue> FindNode(Compare comparer)
        {
            return FindNode(Child, Rank, 1, comparer);
        }
        private Node<TKey, TValue> FindNode(List<Node<TKey, TValue>> root, int Rank, int curRank, Compare comparer)
        {
            List<Node<TKey, TValue>> RS = root;
            bool Flag = true;
            for (int i = 0; i < root.Count; i++)
            {
                if (root[i].Child.Count > 0)
                {
                    if (Flag)
                    {
                        RS = new List<Node<TKey, TValue>>();
                        Flag = false;
                    }
                    RS.AddRange(root[i].Child);
                }
                if (comparer(root[i].Key))
                {
                    return root[i];
                }
            }
            if (Rank > curRank)
            {
                return FindNode(RS, Rank, ++curRank, comparer);
            }
            else
            {
                return null;
            }
        }
        public delegate bool Compare(TKey Key);
    }
}
