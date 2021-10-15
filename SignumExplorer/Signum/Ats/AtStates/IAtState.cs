using SignumExplorer.Signum;
using System;

namespace SignumExplorer.Models
{
    public interface IAtState
    {
        public ulong AtId { get; }
        public int PrevHeight { get; }
        public int NextHeight { get; }
        public int SleepBetween { get; }
        public long PrevBalance { get; }
        public bool FreezeWhenSameBalance { get; }
        public long MinActivateAmount { get; }
        public int Height { get; }
        public bool? Latest { get; }
        public string? AtIdRS => ReedSolomon.encode(AtId);
        public string StateString { get; }


    }
}
