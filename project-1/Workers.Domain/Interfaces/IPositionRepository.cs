using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers.Domain.Interfaces
{
    public interface IPositionRepository
    {
        void Add(Position position);
        Position GetPositionById(int positionId);
    }
}
