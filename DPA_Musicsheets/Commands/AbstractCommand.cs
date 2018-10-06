using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Models;

namespace DPA_Musicsheets.Command
{
    public abstract class AbstractCommand
    {
        public Piece Piece { get; set; }

        public string LilypondText { get; set; }

        public abstract void Execute();
    }
}