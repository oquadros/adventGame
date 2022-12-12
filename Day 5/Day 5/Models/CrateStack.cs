using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5.Models
{
    internal class CrateStack
    {
        public int Id { get; }
        public Stack<Crate> CratesInStack { get; }

        public CrateStack(int id, string[] cratesInStack )
        {
            Id = id;
            CratesInStack = CreateCrateStack(cratesInStack);
        }

        public Crate GetTopCrate() => CratesInStack.Peek();

        public Crate RemoveTopCrate() => CratesInStack.Pop();

        public void AddCrateToStack(Crate crate) => CratesInStack.Push( crate );

        private static Stack<Crate> CreateCrateStack(string[] crateList)
        {
            var stack = new Stack<Crate>();
            foreach (var crate in crateList)
            {
                if (string.IsNullOrEmpty(crate))
                    continue;
                stack.Push( new Crate(crate));
            }
            return stack;
        }

    }
}
