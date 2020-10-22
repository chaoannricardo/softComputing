using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGALibrary
{
    public enum PermutationCrossoverOperator { PartialMappedX, OrderX, PositionBasedX, OrderBasedX, CycleX }  //SubtourExchangeX 
    public enum PermutationMutationOperator { Inversion, Insertion, Displacement, ReciprocalExchange }
    public class PermutationGA : GeneticAlgorithm<int>
    {
        [Category("GA Setting"), Description("True：以基因個數為基的突變率(Gene Based Mutation)。\nFalse：以染色體個數為基的突變率(Population Based Mutation)。")]
        public bool GeneBasedMutation  //PopulationBasedMutation
        {
            get
            {
                return geneBasedMutation;
            }
            set
            {
                if (value == false) geneBasedMutation = value;                
            }
        }
        [Category("Permutation GA Setting")]
        public PermutationCrossoverOperator CrossoverOperator
        { get; set; } = PermutationCrossoverOperator.PartialMappedX;
        [Category("Permutation GA Setting")]
        public PermutationMutationOperator MutationOperator
        { get; set; } = PermutationMutationOperator.Inversion;

        int[] partialMap;
        public PermutationGA(int numberOfGenes, OptimizationType type, ObjectiveFunction<int> obj)
            : base(numberOfGenes, type, obj)
        {
            partialMap = new int[numberOfGenes];
        }

        public override void InitializePopulationChromosomes()
        {
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < numberOfGenes; j++)
                {
                    chromosomes[i][j] = j;
                }
                ShuffleIntegerArray(chromosomes[i], numberOfGenes);  //打散
            }
        }

        protected override void GenerateAPairOfCrossoveredChildren(int father, int mother, int child1, int child2)
        {
            switch (CrossoverOperator)
            {
                case PermutationCrossoverOperator.PartialMappedX:
                    PMX(father, mother, child1, child2);
                    break;
                case PermutationCrossoverOperator.OrderX:
                    OX(father, mother, child1, child2);
                    break;
                case PermutationCrossoverOperator.PositionBasedX:
                    PBX(father, mother, child1, child2);
                    break;
                case PermutationCrossoverOperator.OrderBasedX:
                    OBX(father, mother, child1, child2);
                    break;
                case PermutationCrossoverOperator.CycleX:
                    CX(father, mother, child1, child2);
                    break;
                    //case PermutationCrossoverOperator.SubtourExchangeX:
                    //    SEX(father, mother, child1, child2);
                    //    break;
            }
        }

        void PMX(int father, int mother, int child1, int child2)
        {
            int pos1 = rnd.Next(numberOfGenes);
            int pos2;
            do
            {
                pos2 = rnd.Next(numberOfGenes);
            }
            while (pos1 == pos2);
            //swap pos1, pos2 if pos1 > pos2
            if (pos1 > pos2)
            {
                int temp = pos1;
                pos1 = pos2;
                pos2 = temp;
            }

            for (int i = 0; i < numberOfGenes; i++)
            {
                partialMap[i] = -1;
            }

            for (int i = pos1; i < pos2; i++)
            {
                if (chromosomes[father][i] == chromosomes[mother][i]) continue;
                if (partialMap[chromosomes[father][i]] == -1 && partialMap[chromosomes[mother][i]] == -1)
                {
                    partialMap[chromosomes[father][i]] = chromosomes[mother][i];
                    partialMap[chromosomes[mother][i]] = chromosomes[father][i];
                }
                else if (partialMap[chromosomes[father][i]] == -1)
                {
                    partialMap[chromosomes[father][i]] = partialMap[chromosomes[mother][i]];
                    partialMap[partialMap[chromosomes[mother][i]]] = chromosomes[father][i];
                    partialMap[chromosomes[mother][i]] = -2;
                }
                else if (partialMap[chromosomes[mother][i]] == -1)
                {
                    partialMap[chromosomes[mother][i]] = partialMap[chromosomes[father][i]];
                    partialMap[partialMap[chromosomes[father][i]]] = chromosomes[mother][i];
                    partialMap[chromosomes[father][i]] = -2;
                }
                else
                {
                    partialMap[partialMap[chromosomes[mother][i]]] = partialMap[chromosomes[father][i]];
                    partialMap[partialMap[chromosomes[father][i]]] = partialMap[chromosomes[mother][i]];
                    partialMap[chromosomes[father][i]] = -3;
                    partialMap[chromosomes[mother][i]] = -3;
                }
            }

            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i >= pos1 && i < pos2)
                {
                    chromosomes[child1][i] = chromosomes[mother][i];
                    chromosomes[child2][i] = chromosomes[father][i];
                }
                else
                {
                    if (partialMap[chromosomes[father][i]] < 0)
                        chromosomes[child1][i] = chromosomes[father][i];
                    else chromosomes[child1][i] = partialMap[chromosomes[father][i]];
                    if (partialMap[chromosomes[mother][i]] < 0)
                        chromosomes[child2][i] = chromosomes[mother][i];
                    else chromosomes[child2][i] = partialMap[chromosomes[mother][i]];
                }
            }
        }

        List<int> selectFather = new List<int>();
        List<int> selectMother = new List<int>();
        List<int> temp = new List<int>();

        void OX(int father, int mother, int child1, int child2)
        {
            selectFather.Clear();
            selectMother.Clear();

            int pos1 = rnd.Next(numberOfGenes);
            int pos2;
            do
            {
                pos2 = rnd.Next(numberOfGenes);
            }
            while (pos1 == pos2);
            //swap pos1, pos2 if pos1 > pos2
            if (pos1 > pos2)
            {
                int temp = pos1;
                pos1 = pos2;
                pos2 = temp;
            }

            for (int i = 0; i < numberOfGenes; i++)
            {
                chromosomes[child1][i] = -1;
                chromosomes[child2][i] = -1;
            }

            #region
            //int[] subtourFather = new int[pos2 - pos1];
            //for (int i = 0; i < pos2 - pos1; i++)
            //{
            //    subtourFather[i] = chromosomes[father][pos1 + i];
            //}
            //int[] subtourMother = new int[pos2 - pos1];
            //for (int i = 0; i < pos2 - pos1; i++)
            //{
            //    subtourMother[i] = chromosomes[mother][pos1 + i];
            //} 
            #endregion
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i >= pos1 && i < pos2)
                {
                    chromosomes[child1][i] = chromosomes[father][i];
                    chromosomes[child2][i] = chromosomes[mother][i];
                    selectFather.Add(chromosomes[father][i]);
                    selectMother.Add(chromosomes[mother][i]);
                }
                //else if (i < pos1 || i >= pos2)
            }
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (chromosomes[child1][i] == -1)
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (selectFather.Contains(chromosomes[mother][j])) continue;
                        chromosomes[child1][i] = chromosomes[mother][j];
                        selectFather.Add(chromosomes[mother][j]);
                        break;
                    }
                }

                if (chromosomes[child2][i] == -1)
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (selectMother.Contains(chromosomes[father][j])) continue;
                        chromosomes[child2][i] = chromosomes[father][j];
                        selectMother.Add(chromosomes[father][j]);
                        break;
                    }
                }
            }
        }

        void PBX(int father, int mother, int child1, int child2)
        {
            selectFather.Clear();
            selectMother.Clear();
            temp.Clear();

            int numberOfCrossoveredGenes;
            do
            {
                numberOfCrossoveredGenes = rnd.Next(numberOfGenes);
            }
            while (numberOfCrossoveredGenes == 0);

            int[] pos = new int[numberOfCrossoveredGenes];
            for (int i = 0; i < numberOfCrossoveredGenes; i++)
            {
                if (i == 0)  //第一個位置
                {
                    pos[i] = rnd.Next(numberOfGenes);
                    temp.Add(pos[i]);
                }
                //突變位置不能相同
                else
                {
                    do
                    {
                        pos[i] = rnd.Next(numberOfGenes);
                    }
                    while (temp.Contains(pos[i]));
                    temp.Add(pos[i]);
                }
            }

            Array.Sort(pos);

            for (int i = 0; i < numberOfGenes; i++)
            {
                chromosomes[child1][i] = -1;
                chromosomes[child2][i] = -1;
            }

            for (int i = 0; i < numberOfCrossoveredGenes; i++)
            {
                chromosomes[child1][pos[i]] = chromosomes[father][pos[i]];
                chromosomes[child2][pos[i]] = chromosomes[mother][pos[i]];
                selectFather.Add(chromosomes[father][pos[i]]);
                selectMother.Add(chromosomes[mother][pos[i]]);
            }
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (chromosomes[child1][i] == -1)
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (selectFather.Contains(chromosomes[mother][j])) continue;
                        chromosomes[child1][i] = chromosomes[mother][j];
                        selectFather.Add(chromosomes[mother][j]);
                        break;
                    }
                }

                if (chromosomes[child2][i] == -1)
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (selectMother.Contains(chromosomes[father][j])) continue;
                        chromosomes[child2][i] = chromosomes[father][j];
                        selectMother.Add(chromosomes[father][j]);
                        break;
                    }
                }
            }
        }

        void OBX(int father, int mother, int child1, int child2)
        {
            selectFather.Clear();
            selectMother.Clear();

            int numberOfCrossoveredGenes;
            do
            {
                numberOfCrossoveredGenes = rnd.Next(numberOfGenes);
            }
            while (numberOfCrossoveredGenes == 0);

            int[] geneValues = new int[numberOfCrossoveredGenes];
            for (int i = 0; i < numberOfCrossoveredGenes; i++)
            {
                if (i == 0)  //第一個突變基因值
                {
                    geneValues[i] = rnd.Next(numberOfGenes);
                    selectFather.Add(geneValues[i]);
                    selectMother.Add(geneValues[i]);
                }
                //選到的基因值不能重複
                else
                {
                    do
                    {
                        geneValues[i] = rnd.Next(numberOfGenes);
                    }
                    while (selectFather.Contains(geneValues[i]));
                    selectFather.Add(geneValues[i]);
                    selectMother.Add(geneValues[i]);
                }
            }

            int[] posFather = new int[numberOfCrossoveredGenes];
            int[] posMother = new int[numberOfCrossoveredGenes];
            for (int i = 0; i < numberOfCrossoveredGenes; i++)
            {
                for (int j = 0; j < numberOfGenes; j++)
                {
                    if (selectFather.Contains(chromosomes[father][j]))
                    {
                        posFather[i] = j;
                        selectFather.Remove(chromosomes[father][j]);
                        break;
                    }

                }
                for (int j = 0; j < numberOfGenes; j++)
                {
                    if (selectMother.Contains(chromosomes[mother][j]))
                    {
                        posMother[i] = j;
                        selectMother.Remove(chromosomes[mother][j]);
                        break;
                    }
                }
            }

            Array.Sort(posFather);  //可有可無
            Array.Sort(posMother);

            for (int i = 0; i < numberOfGenes; i++)
            {
                chromosomes[child1][i] = -1;
                chromosomes[child2][i] = -1;
            }

            for (int i = 0; i < numberOfCrossoveredGenes; i++)
            {
                chromosomes[child1][posMother[i]] = chromosomes[father][posFather[i]];
                chromosomes[child2][posFather[i]] = chromosomes[mother][posMother[i]];
            }
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (chromosomes[child1][i] == -1)
                {
                    chromosomes[child1][i] = chromosomes[mother][i];
                }

                if (chromosomes[child2][i] == -1)
                {
                    chromosomes[child2][i] = chromosomes[father][i];
                }
            }
            #region
            //for (int i = 0; i < numberOfGenes; i++)
            //{
            //    if (chromosomes[child1][i] == -1)
            //    {
            //        for (int j = 0; j < numberOfGenes; j++)
            //        {
            //            if (selectFather.Contains(chromosomes[mother][j])) continue;
            //            chromosomes[child1][i] = chromosomes[mother][j];
            //            selectFather.Add(chromosomes[mother][j]);
            //            break;
            //        }
            //    }

            //    if (chromosomes[child2][i] == -1)
            //    {
            //        for (int j = 0; j < numberOfGenes; j++)
            //        {
            //            if (selectMother.Contains(chromosomes[father][j])) continue;
            //            chromosomes[child2][i] = chromosomes[father][j];
            //            selectMother.Add(chromosomes[father][j]);
            //            break;
            //        }
            //    }
            //}
            #endregion
        }

        List<int> cyclePos = new List<int>();

        void CX(int father, int mother, int child1, int child2)
        {
            temp.Clear();
            cyclePos.Clear();

            int pos = rnd.Next(numberOfGenes);
            int geneValue = chromosomes[father][pos];
            temp.Add(chromosomes[mother][pos]);
            cyclePos.Add(pos);
            int numberOfMutatedGenes = 1;
            //find the circle
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (temp.Contains(chromosomes[father][i]))
                {
                    temp.Add(chromosomes[mother][i]);
                    cyclePos.Add(i);
                    numberOfMutatedGenes++;
                    if (chromosomes[mother][i] != geneValue)
                    {
                        temp.Remove(chromosomes[father][i]);
                        i = -1;  //重頭開始找
                    }
                    else if (chromosomes[mother][i] == geneValue)
                    {
                        temp.Remove(chromosomes[father][i]);
                        break;
                    }
                }
            }

            for (int i = 0; i < numberOfGenes; i++)
            {
                chromosomes[child1][i] = -1;
                chromosomes[child2][i] = -1;
            }

            for (int i = 0; i < numberOfMutatedGenes; i++)
            {
                chromosomes[child1][cyclePos[i]] = chromosomes[father][cyclePos[i]];
                chromosomes[child2][cyclePos[i]] = chromosomes[mother][cyclePos[i]];
            }
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (chromosomes[child1][i] == -1)
                {
                    chromosomes[child1][i] = chromosomes[mother][i];
                }

                if (chromosomes[child2][i] == -1)
                {
                    chromosomes[child2][i] = chromosomes[father][i];
                }
            }
        }

        void SEX(int father, int mother, int child1, int child2)
        {
            selectFather.Clear();
            selectMother.Clear();
            int subtourLength;
            do
            {
                subtourLength = rnd.Next(numberOfGenes);
            }
            while (subtourLength <= 1);

            int[] posFather = new int[subtourLength];
            int[] posMother = new int[subtourLength];
            for (int i = 0; i < subtourLength; i++)
            {
                if (i == 0)  //第一個
                {
                    do
                    {
                        posFather[i] = rnd.Next(numberOfGenes);
                    }
                    while (numberOfGenes - posFather[i] < subtourLength);
                    selectFather.Add(chromosomes[father][posFather[i]]);
                }
                else
                {
                    posFather[i] = posFather[i - 1] + 1;
                    selectFather.Add(chromosomes[father][posFather[i]]);
                }
            }
            //check contents exactly match  
            //error
            //for (int i = 0; i < numberOfGenes; i++)
            //{
            //    if (selectFather.Contains(chromosomes[mother][i]))
            //    {
            //        for (int j = 0; j < subtourLength; j++)
            //        {
            //            if(selectFather.Contains(chromosomes[mother][i + j]))
            //            selectMother.Add(chromosomes[mother][i + j]);
            //            posMother[j] = i + j;                       
            //        }                                
            //    }
            //}
            for (int i = 0; i < numberOfGenes; i++)
            {
                chromosomes[child1][i] = -1;
                chromosomes[child2][i] = -1;
            }

            for (int i = 0; i < subtourLength; i++)
            {
                chromosomes[child1][posFather[i]] = chromosomes[mother][posMother[i]];
                chromosomes[child2][posMother[i]] = chromosomes[mother][posFather[i]];
            }
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (chromosomes[child1][i] == -1)
                {
                    chromosomes[child1][i] = chromosomes[father][i];
                }

                if (chromosomes[child2][i] == -1)
                {
                    chromosomes[child2][i] = chromosomes[mother][i];
                }
            }
        }

        protected override void GenerateAMutatedChildren(int parent, int child)
        {
            switch (MutationOperator)
            {
                case PermutationMutationOperator.Inversion:
                    Inversion(parent, child);
                    break;
                case PermutationMutationOperator.Insertion:
                    Insertion(parent, child);
                    break;
                case PermutationMutationOperator.Displacement:
                    Displacement(parent, child);
                    break;
                case PermutationMutationOperator.ReciprocalExchange:
                    ReciprocalExchange(parent, child);
                    break;
            }
        }

        void Inversion(int parent, int child)
        {
            int pos1 = rnd.Next(numberOfGenes);
            int pos2;
            do
            {
                pos2 = rnd.Next(numberOfGenes);
            }
            while (pos1 == pos2);
            //swap pos1, pos2 if pos1 > pos2
            if (pos1 > pos2)
            {
                int temp = pos1;
                pos1 = pos2;
                pos2 = temp;
            }

            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i >= pos1 && i < pos2)
                {
                    chromosomes[child][i] = chromosomes[parent][pos2 - i - 1 + pos1];
                }
                else chromosomes[child][i] = chromosomes[parent][i];
            }
        }

        void Insertion(int parent, int child)
        {
            int genePos = rnd.Next(numberOfGenes);
            int insertPos;
            do
            {
                insertPos = rnd.Next(numberOfGenes);
            }
            while (genePos == insertPos);

            for (int i = 0; i < numberOfGenes; i++)
            {
                if (insertPos > genePos)
                {
                    if (i >= genePos && i < insertPos) chromosomes[child][i] = chromosomes[parent][i + 1];
                    else if (i == insertPos) chromosomes[child][i] = chromosomes[parent][genePos];
                    else chromosomes[child][i] = chromosomes[parent][i];
                }
                else if (genePos > insertPos)
                {
                    if (i == insertPos) chromosomes[child][i] = chromosomes[parent][genePos];
                    else if (i > insertPos && i <= genePos) chromosomes[child][i] = chromosomes[parent][i - 1];
                    else chromosomes[child][i] = chromosomes[parent][i];
                }
            }
        }

        void Displacement(int parent, int child)
        {
            int pos1 = rnd.Next(numberOfGenes);
            int pos2;
            do
            {
                pos2 = rnd.Next(numberOfGenes);
            }
            while (pos1 == pos2);
            //swap pos1, pos2 if pos1 > pos2
            if (pos1 > pos2)
            {
                int temp = pos1;
                pos1 = pos2;
                pos2 = temp;
            }
            int insertPos;
            do
            {
                insertPos = rnd.Next(numberOfGenes - (pos2 - pos1) + 1);
            }
            while (insertPos == pos1);

            int[] subtour = new int[pos2 - pos1];
            for (int i = 0; i < pos2 - pos1; i++)
            {
                subtour[i] = chromosomes[parent][pos1 + i];
            }

            for (int i = 0; i < numberOfGenes; i++)
            {
                if (insertPos > pos1)
                {
                    if (i >= pos1 && i < insertPos)
                    {
                        chromosomes[child][i] = chromosomes[parent][i + (pos2 - pos1)];
                    }
                    else if (i >= insertPos && i < insertPos + pos2 - pos1)
                    {
                        chromosomes[child][i] = subtour[i - insertPos];
                    }
                    else if (i < pos1 || i >= insertPos + pos2 - pos1)
                    {
                        chromosomes[child][i] = chromosomes[parent][i];
                    }
                    #region 
                    //if (insertPos == pos2)
                    //{
                    //    if (i >= pos1 && i < pos2)
                    //    {
                    //        chromosomes[child][i] = chromosomes[parent][i + (pos2 - pos1)];
                    //    }
                    //    else if (i >= insertPos && i < insertPos + pos2 - pos1)
                    //    {
                    //        chromosomes[child][i] = chromosomes[parent][i - (pos2 - pos1)];
                    //    }
                    //    else if(i < pos1 || i > insertPos + pos2 - pos1)
                    //    {
                    //        chromosomes[child][i] = chromosomes[parent][i];
                    //    }
                    //}
                    //else if (insertPos > pos2)
                    //{
                    //    if (i >= pos1 && i < insertPos)
                    //    {
                    //        chromosomes[child][i] = chromosomes[parent][i + (pos2 - pos1)];
                    //    }
                    //    else if (i >= insertPos && i < insertPos + pos2 - pos1)
                    //    {
                    //        chromosomes[child][i] = chromosomes[parent][i - (pos2 - pos1) - (insertPos - pos2)];
                    //    }
                    //    else if (i < pos1 || i > insertPos + pos2 - pos1)
                    //    {
                    //        chromosomes[child][i] = chromosomes[parent][i];
                    //    }
                    //}
                    //else if (insertPos > pos1 && insertPos < pos2)
                    //{
                    //    if (i >= pos1 && i < insertPos)
                    //    {
                    //        chromosomes[child][i] = chromosomes[parent][i + (pos2 - pos1)];
                    //    }
                    //    else if (i >= insertPos && i < insertPos + pos2 - pos1)
                    //    {
                    //        chromosomes[child][i] = chromosomes[parent][i - (pos2 - pos1) + (pos2 - insertPos)];
                    //    }
                    //    else if (i < pos1 || i > insertPos + pos2 - pos1)
                    //    {
                    //        chromosomes[child][i] = chromosomes[parent][i];
                    //    }
                    //}
                    #endregion
                }
                else if (pos1 > insertPos)
                {
                    if (i >= insertPos + pos2 - pos1 && i < pos2)
                    {
                        chromosomes[child][i] = chromosomes[parent][i - (pos2 - pos1)];
                    }
                    else if (i >= insertPos && i < insertPos + pos2 - pos1)
                    {
                        chromosomes[child][i] = subtour[i - insertPos];
                    }
                    else if (i < insertPos || i >= pos2)
                    {
                        chromosomes[child][i] = chromosomes[parent][i];
                    }
                }
            }
        }

        void ReciprocalExchange(int parent, int child)
        {
            int pos1 = rnd.Next(numberOfGenes);
            int pos2;
            do
            {
                pos2 = rnd.Next(numberOfGenes);
            }
            while (pos1 == pos2);

            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i == pos1) chromosomes[child][i] = chromosomes[parent][pos2];
                else if (i == pos2) chromosomes[child][i] = chromosomes[parent][pos1];
                else chromosomes[child][i] = chromosomes[parent][i];
            }
        }
        #region
        protected override void GenerateAMutatedChildren(int parent, int child, List<int> geneLocation)
        {
            switch (MutationOperator)
            {
                case PermutationMutationOperator.Inversion:
                    Inversion(parent, child);
                    break;
                case PermutationMutationOperator.Insertion:
                    Insertion(parent, child);
                    break;
                case PermutationMutationOperator.Displacement:
                    Displacement(parent, child);
                    break;
                case PermutationMutationOperator.ReciprocalExchange:
                    ReciprocalExchange(parent, child);
                    break;
            }
        }
        #endregion
    }
}
