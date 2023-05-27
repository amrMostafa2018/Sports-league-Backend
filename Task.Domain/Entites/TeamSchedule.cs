using System.ComponentModel.DataAnnotations.Schema;
using Task.Domain.Base;


namespace Task.Domain.Entites
{
    public class TeamSchedule : AuditEntityWithSoftDelete<int>
    {

        public DateTime ScheduleDate { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }


    }
}
