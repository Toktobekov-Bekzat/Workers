using System;
namespace Workers.Domain.Interfaces
{
    public interface IGenderRepository
    {
        Gender GetGenderByKey(int genderKey);
    }
}

