namespace FreeGaming.Data.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum GenreType
    {
        Action = 1,
        [Display(Name = "Action Adventure")]
        ActionAdventure = 2,
        Adventure = 3,
        [Display(Name = "Role Playing")]
        RolePlaying = 4,
        Simulation = 5,
        Strategy = 6,
        Sports = 7,
    }
}
