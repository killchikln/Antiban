using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antiban.Mapper
{
    internal static class AntibanMapper
    {
        public static AntibanResult EventMessageToAntibanResult(this EventMessage message)
        {
            return new AntibanResult
            {
                SentDateTime = message.DateTime,
                EventMessageId = message.Id
            };
        }
        public static AntibanResult EventMessageToAntibanResult(this EventMessage message, DateTime newDate)
        {
            return new AntibanResult
            {
                SentDateTime = newDate,
                EventMessageId = message.Id
            };
        }
    }
}
