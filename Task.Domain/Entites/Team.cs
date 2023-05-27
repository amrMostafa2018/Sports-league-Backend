using System.ComponentModel.DataAnnotations.Schema;
using Task.Domain.Base;

namespace Task.Domain.Entites
{
    public class Team : AuditEntityWithSoftDelete<int>
    {
        public Team()
        {
            TeamMemebers = new HashSet<TeamMemeber>();
            TeamHomeSchedules = new HashSet<TeamSchedule>();
            TeamAwaySchedules = new HashSet<TeamSchedule>();
        }

        public string Name { get; set; }
        public string City { get; set; }
        public string Coach { get; set; }
        public ICollection<TeamMemeber> TeamMemebers { get; set; }

        [InverseProperty("HomeTeam")]
        public ICollection<TeamSchedule> TeamHomeSchedules { get; set; }
        [InverseProperty("AwayTeam")]
        public ICollection<TeamSchedule> TeamAwaySchedules { get; set; }


    }
}
