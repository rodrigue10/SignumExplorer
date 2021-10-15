using SignumExplorer.Signum;
using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class AtState : IAtState
    {
        public string StateString       
        {
            get
            {

                if (State != null)
                {
                    byte[] bytes = new byte[8];

                    Array.Copy(State, bytes, 8);

                    return BitConverter.ToString(State.Decompress()).Replace("-", "");

                }
                else { return string.Empty; }
            }
        }

        ulong IAtState.AtId => (ulong)AtId;
    }
}
