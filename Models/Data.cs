using System;
using System.Collections.Generic;

namespace Kosarlabda.Models;

public partial class Data
{
    public int In { get; set; }

    public int Out { get; set; }

    public int Try { get; set; }

    public int Goal { get; set; }

    public int Fault { get; set; }

    public DateTime CreatedTime { get; set; }

    public int UpdatedTime { get; set; }

    public Guid PlayerId { get; set; }

    public int Id { get; set; }
}
