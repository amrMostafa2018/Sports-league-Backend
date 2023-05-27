using Task.Domain.Base;


namespace Task.Domain.Entites
{
    public class TeamMemeber : AuditEntityWithSoftDelete<int>
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Number { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }


    }
}
