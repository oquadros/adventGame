using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day_5.Models;

namespace Day_5.Helpers
{
    static class Helpers
    {
        public static IEnumerable<string> SplitIntoChunks(string line, int chunkLength)
        {
            for (int i = 0; i < line.Length; i += chunkLength)
                yield return line.Substring(i, Math.Min(chunkLength, line.Length - i)).Trim().Trim('[').Trim(']');
        }
        public static string[][] ConvertRowsToColumns(string[][] rowList)
        {
            List<string[]> columnsList = new List<string[]>();
            for (int i = 0; i < rowList[0].Length; i++)
            {
                string[] column = new string[rowList.Length];
                for (var row = 0; row < rowList.Length; row++)
                {
                    column[row] = rowList[row][i];
                }
                columnsList.Add(column);
            }

            return columnsList.ToArray();
        }

        public static string[][] ParseStackRows(string[] inputData)
        {
            int indexOfSplit = Array.IndexOf(inputData, string.Empty);

            int currentIndex = 0;
            int chunkLength = 4;
            List<string[]> rowList = new();
            while (currentIndex < indexOfSplit - 1)
            {
                string line = inputData[currentIndex];
                rowList.Add(Helpers.SplitIntoChunks(line, chunkLength).ToArray());
                currentIndex++;
            }
            rowList.Reverse();
            return rowList.ToArray();
        }

        public static void CrateMover9000Move(string[] inputData, List<CrateStack> crateStacks, int indexOfSplit)
        {
            for (var line = indexOfSplit + 1; line < inputData.Length; line++)
            {
                (int boxesToMove, int fromStacker, int toStacker) = ParseMoveParameters(inputData[line]);

                for (var i = 0; i < boxesToMove; i++)
                {
                    crateStacks.First(c => c.Id == toStacker)
                               .AddCrateToStack(crateStacks.First(cs => cs.Id == fromStacker)
                                                           .RemoveTopCrate());
                }

            }
        }

        public static void CrateMover9001Move(string[] inputData, List<CrateStack> crateStacks, int indexOfSplit)
        {
            for (var line = indexOfSplit + 1; line < inputData.Length; line++)
            {
                (int boxesToMove, int fromStacker, int toStacker) moveCommand = Helpers.ParseMoveParameters(inputData[line]);

                Stack<Crate> transferStack = new();

                for (var i = 0; i < moveCommand.boxesToMove; i++)
                {
                    transferStack.Push(crateStacks.First(cs => cs.Id == moveCommand.fromStacker).RemoveTopCrate());
                }

                for (var i = 0; i < moveCommand.boxesToMove; i++)
                {
                    crateStacks.First(c => c.Id == moveCommand.toStacker).AddCrateToStack(transferStack.Pop());
                }

            }
        }

        public static (int move, int from, int to) ParseMoveParameters(string moveCommand)
        {
            string[] splitMoveCommand = moveCommand.Split(' ');
            int numberToMove = ParseValue<int>(splitMoveCommand[Array.IndexOf(splitMoveCommand, "move") + 1]);
            int fromStack = ParseValue<int>(splitMoveCommand[Array.IndexOf(splitMoveCommand, "from") + 1]);
            int toStack = ParseValue<int>(splitMoveCommand[Array.IndexOf(splitMoveCommand, "to") + 1]);

            return (numberToMove, fromStack, toStack);

        }
        private static T ParseValue<T>(string key)
        {
            return (T)Convert.ChangeType(key, typeof(T));
        }
    }
}
