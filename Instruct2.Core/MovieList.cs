using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Instruct2.Core
{
    public class MovieList
    {
        public MovieList()
        {
            Movies = new List<string>();
        }

        public List<string> Movies { get; set; }
    }
}
