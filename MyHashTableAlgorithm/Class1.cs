using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] keys = { "apple", "banana", "orange", "grape", "melon" };

        Console.WriteLine("=== Additive Hash ===");
        foreach (var key in keys)
        {
            Console.WriteLine($"Key: {key}, Hash: {AdditiveHash(key)}");
        }

        Console.WriteLine("\n=== Folding Hash ===");
        foreach (var key in keys)
        {
            Console.WriteLine($"Key: {key}, Hash: {FoldingHash(key)}");
        }

        // Simple hash table example
        Console.WriteLine("\n=== Simple Hash Table ===");
        int tableSize = 10;
        string[] hashTable = new string[tableSize];

        foreach (var key in keys)
        {
            int index = AdditiveHash(key) % tableSize;
            // Simple linear probing if collision
            while (hashTable[index] != null)
            {
                index = (index + 1) % tableSize;
            }
            hashTable[index] = key;
        }

        // Print hash table
        for (int i = 0; i < tableSize; i++)
        {
            Console.WriteLine($"Index {i}: {hashTable[i]}");
        }
    }

    private static int AdditiveHash(string input)
    {
        int currentHashValue = 0;
        foreach (char c in input)
        {
            unchecked
            {
                currentHashValue += c;
            }
        }
        return currentHashValue;
    }

    private static int FoldingHash(string input)
    {
        int hashValue = 0;
        int startIndex = 0;
        int currentFourBytes;

        do
        {
            currentFourBytes = GetNextBytes(startIndex, input);
            unchecked
            {
                hashValue += currentFourBytes;
            }
            startIndex += 4;
        } while (currentFourBytes != 0);

        return hashValue;
    }

    private static int GetNextBytes(int startIndex, string str)
    {
        int currentFourBytes = 0;
        currentFourBytes += GetByte(str, startIndex);
        currentFourBytes += GetByte(str, startIndex + 1) << 8;
        currentFourBytes += GetByte(str, startIndex + 2) << 16;
        currentFourBytes += GetByte(str, startIndex + 3) << 24;
        return currentFourBytes;
    }

    private static int GetByte(string str, int index)
    {
        if (index < str.Length)
            return str[index];
        return 0;
    }
}
