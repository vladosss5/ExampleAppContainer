using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Person
{
    public int IdPerson { get; set; }

    public string Name { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public virtual ICollection<PersonSkill> PersonSkills { get; set; } = new List<PersonSkill>();
}
