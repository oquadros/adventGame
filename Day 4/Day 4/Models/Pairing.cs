using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day_4.Models;

namespace Day_4
{
    internal class Pairing
    {
        public Individual FirstIndividual { get; }
        public Individual SecondIndividual { get; }

        public Pairing(string pairing)
        {
            FirstIndividual = new Individual(pairing.Split(',')[0]);
            SecondIndividual = new Individual(pairing.Split(',')[1]);

        }

        public bool AnyFullyContained => IndividualContained(FirstIndividual, SecondIndividual) || IndividualContained(SecondIndividual, FirstIndividual);

        public bool AnyOverlap => IndividaulOverlap(FirstIndividual, SecondIndividual) || IndividaulOverlap(SecondIndividual, FirstIndividual);

        private static bool IndividualContained(Individual individualOne, Individual individualTwo) => individualOne.UpperAssignedTask <= individualTwo.UpperAssignedTask && individualOne.LowerAssignedTask >= individualTwo.LowerAssignedTask;

        private static bool IndividaulOverlap(Individual individualOne, Individual individualTwo) => individualOne.UpperAssignedTask >= individualTwo.LowerAssignedTask && individualOne.LowerAssignedTask <= individualTwo.LowerAssignedTask; 
    }
}
