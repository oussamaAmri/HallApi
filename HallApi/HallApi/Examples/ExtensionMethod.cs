namespace HallApi.Examples
{
    public class ExtensionMethod
    {
        public void Execute()
        {
            var team = new Team
            {
                Id = 1,
                Sport = "Football"
            };

            var myVar1 = team.IsFootball_1(); // Appel de la méthode directement sur l'objet

            var myVar2 = ExtensionForTeam.IsFootball_2(team); // Appel de la méthode via la classe de la méthode
        }
    }

    public class Team
    {
        public int Id { get; set; }
        public string Sport { get; set; } = string.Empty;
    }

    public static class ExtensionForTeam
    {
        public static bool IsFootball_1(this Team team)
        {
            if (team.Sport == "Football")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsFootball_2(Team team)
        {
            if (team.Sport == "Football")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
