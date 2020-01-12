using System;
using System.Linq;

namespace AdventOfCode.Core.Y2019
{
  enum OpCode
  {
    Add = 1,
    Mul = 2,
    Hlt = 99,
  }

  class Memory
  {
    private int[] initialState;
    public int[] state;
    public Memory(int[] state)
    {
      initialState = state;
      this.state = state;
    }

    internal void Reset()
    {
      state = (int[])initialState.Clone();
    }

    public int this[int addr]
    {
      get
      {
        return addr < state.Length ? state[addr] : 0;
      }
      set
      {
        state[addr] = value;
      }
    }
  }

  class IntCodeMachine
  {
    public Memory memory;
    public int ip;
    public IntCodeMachine(string memory)
    {
      this.memory = new Memory(memory.Split(",").Select(i => int.Parse(i)).ToArray());
    }

    public void Reset()
    {
      memory.Reset();
      ip = 0;
    }

    private OpCode GetOpcode(int addr) => (OpCode)memory[addr];


    public void Run()
    {
      while (true)
      {
        var opCode = GetOpcode(ip);
        var prevIp = ip;

        int GetAddress(int i) => memory[prevIp + i];
        int GetValue(int i) => memory[GetAddress(i)];

        switch (opCode)
        {
          case OpCode.Add:
            memory[GetAddress(3)] = GetValue(1) + GetValue(2);
            ip += 4;
            break;
          case OpCode.Mul:
            memory[GetAddress(3)] = GetValue(1) * GetValue(2);
            ip += 4;
            break;
          case OpCode.Hlt:
            break;
          default:
            throw new ArgumentException();
        }
        if (ip == prevIp)
        {
          break;
        }
      }
    }
  }

}