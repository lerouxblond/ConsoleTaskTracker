using ConsoleTaskTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.Infrastructure
{
    public class MockUserInterface : IUserInterface
    {
        private readonly Queue<string> _inputs = new();
        public List<string> Output = [];

        public void AddInput(string input)
        {
            //Console.WriteLine($"AddInput - MOCK INPUT DEBUG: {input}");
            _inputs.Enqueue(input);
        }

        public void WriteLine(string message)
        {
            //Console.WriteLine($"WriteLine - MOCK OUTPUT DEBUG: {message}");
            Output.Add(message);
        }
        public void Write(string message)
        {
            //Console.WriteLine($"Write - MOCK OUTPUT DEBUG: {message}");
            Output.Add(message);
        }

        public string? ReadLine() => _inputs.Count > 0 ? _inputs.Dequeue() : string.Empty;
        public void Clear() => Output.Add("[Clear]");
    }
}
