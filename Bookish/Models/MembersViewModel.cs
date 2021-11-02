using System;
using System.Collections.Generic;
using System.Threading.Channels;
using Bookish.Models.Database;

namespace Bookish.Models
{
    public class MembersViewModel
    {
        public IEnumerable<Member> Members { get; set; }
    }
}