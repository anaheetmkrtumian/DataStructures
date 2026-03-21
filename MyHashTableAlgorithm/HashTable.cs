using System;

namespace MyHashTableLib
{
    public class HashTable
    {
        private string[] table;
        private int size;

        public HashTable(int tableSize)
        {
            size = tableSize;
            table = new string[size];
        }

        public int AdditiveHash(string key)
        {
            int hash = 0;
            foreach (char c in key)
            {
                unchecked
                {
                    hash += c;
                }
            }
            return hash;
        }

        public int FoldingHash(string key)
        {
            int hash = 0;
            int startIndex = 0;
            int currentFourBytes;

            do
            {
                currentFourBytes = GetNextBytes(startIndex, key);
                unchecked
                {
                    hash += currentFourBytes;
                }
                startIndex += 4;
            } while (currentFourBytes != 0);

            return hash;
        }

        private int GetNextBytes(int startIndex, string str)
        {
            int currentFourBytes = 0;
            currentFourBytes += GetByte(str, startIndex);
            currentFourBytes += GetByte(str, startIndex + 1) << 8;
            currentFourBytes += GetByte(str, startIndex + 2) << 16;
            currentFourBytes += GetByte(str, startIndex + 3) << 24;
            return currentFourBytes;
        }

        private int GetByte(string str, int index)
        {
            if (index < str.Length)
                return str[index];
            return 0;
        }

        public void InsertAdditive(string key)
        {
            int index = AdditiveHash(key) % size;
            while (table[index] != null)
                index = (index + 1) % size;
            table[index] = key;
        }

        public void InsertFolding(string key)
        {
            int index = FoldingHash(key) % size;
            while (table[index] != null)
                index = (index + 1) % size;
            table[index] = key;
        }

        public bool Search(string key)
        {
            int index = AdditiveHash(key) % size;
            int startIndex = index;

            while (table[index] != null)
            {
                if (table[index] == key)
                    return true;
                index = (index + 1) % size;
                if (index == startIndex) 
                    break;
            }

            return false;
        }

        public string[] GetTable()
        {
            return table;
        }
    }
}