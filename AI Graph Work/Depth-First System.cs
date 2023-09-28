using System;
using System.Collections.Generic;

class Grapho
{
    private Dictionary<int, LinkedList<int>> graphsAdjacentes;

    public Grapho()
    {
        graphsAdjacentes = new Dictionary<int, LinkedList<int>>();
    }

    public void AddNode(int node)
    {
        if (!graphsAdjacentes.ContainsKey(node))
        {
            graphsAdjacentes[node] = new LinkedList<int>();
        }
    }

    public void AddRelacao(int nodeInicial, int nodeFinal)
    {
        if (!graphsAdjacentes.ContainsKey(nodeInicial) || !graphsAdjacentes.ContainsKey(nodeFinal))
        {
            throw new ArgumentException("Nodes nao encontrados no Grapho");
        }

        graphsAdjacentes[nodeInicial].AddLast(nodeFinal);
    }

    public void DFS(int nodeInicial)
    {
        bool[] visitados = new bool[graphsAdjacentes.Count];
        DFSCheck(nodeInicial, visitados);

        for (int i = 0; i < visitados.Length; i++)
        {
            if (!visitados[i])
            {
                BFSCheck(i, visitados);
            }
        }
    }

    public void DFSCheck(int nodeInicial, bool[] visitados)
    {
        visitados[nodeInicial] = true;
        Console.WriteLine("Visitando Node: " + nodeInicial);

        foreach (int vizinho in graphsAdjacentes[nodeInicial])
        {
            if (!visitados[vizinho] == true)
            {
                DFSCheck(vizinho, visitados);
            }
        }
    }
}

class Program
{
    static void Main(string[] agrs)
    {
        Grapho grapho = new Grapho();

        grapho.AddNode(0);
        grapho.AddNode(1);
        grapho.AddNode(2);
        grapho.AddNode(3);
        grapho.AddNode(4);
        grapho.AddNode(5);
        grapho.AddNode(6);
        grapho.AddNode(7);
        grapho.AddNode(8);
        grapho.AddNode(9);
        grapho.AddNode(10);
        grapho.AddNode(11);

        grapho.AddRelacao(0, 1);
        grapho.AddRelacao(0, 2);
        grapho.AddRelacao(0, 3);
        grapho.AddRelacao(1, 4);
        grapho.AddRelacao(1, 5);
        grapho.AddRelacao(1, 8);
        grapho.AddRelacao(2, 6);
        grapho.AddRelacao(2, 7);
        grapho.AddRelacao(2, 8);
        grapho.AddRelacao(4, 9);
        grapho.AddRelacao(6, 10);
        grapho.AddRelacao(6, 11);
        grapho.AddRelacao(11, 7);
        grapho.AddRelacao(11, 8);

        Console.WriteLine("DFS começa pelo Node V0: ");
        grapho.DFS(0);
    }
}