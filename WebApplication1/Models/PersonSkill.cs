using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class PersonSkill
{
    public int IdList { get; set; }

    public int IdSkill { get; set; }

    public int IdPerson { get; set; }

    public short Level { get; set; }

    public virtual Person IdPersonNavigation { get; set; } = null!;

    public virtual Skill IdSkillNavigation { get; set; } = null!;
}
