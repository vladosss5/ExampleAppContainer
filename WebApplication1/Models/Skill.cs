using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Skill
{
    public int IdSkill { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<PersonSkill> PersonSkills { get; set; } = new List<PersonSkill>();
}
