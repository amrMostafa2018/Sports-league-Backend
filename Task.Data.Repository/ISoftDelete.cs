using System;

namespace Task.Data.Repository
{
    public interface ISoftDelete
    {
       bool IsDeleted { get; set; }
       DateTime? DeleteDate { get; set; }
    }
}
