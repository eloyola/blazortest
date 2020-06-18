using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared = Beam.Shared;

namespace Blazor.Server.Mapper
{
    public static class FrequencyMapper
    {
        public static Shared.Frequency ToShared(this Blazor.Data.Models.Frequency f)
        {
            return new Shared.Frequency()
            {
                Id = f.FrequencyId,
                Name = f.Name
            };
        }
        public static Blazor.Data.Models.Frequency ToData(this Shared.Frequency f)
        {
            return new Blazor.Data.Models.Frequency()
            {
                FrequencyId = f.Id,
                Name = f.Name
            };
        }
    }
}
