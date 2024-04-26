using Antiban.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Antiban
{
    public class Antiban
    {
        /// <summary>
        /// Добавление сообщений в систему, для обработки порядка сообщений
        /// </summary>
        /// <param name="eventMessage"></param>
        List<EventMessage> _pushedMessages;

        public Antiban()
        {
            _pushedMessages = new List<EventMessage>();
        }

        public void PushEventMessage(EventMessage eventMessage)
        {
            if (eventMessage != null && !_pushedMessages.Contains(eventMessage))
                _pushedMessages.Add(eventMessage);
        }

        /// <summary>
        /// Вовзращает порядок отправок сообщений
        /// </summary>
        /// <returns></returns>
        public List<AntibanResult> GetResult()
        {
            //Example

            var result = new List<AntibanResult>();
            var sortedMessages = new List<EventMessage>();
            var messagesByPhone = new List<EventMessage>();
            var messagesByPhoneAndPriority = new List<EventMessage>();


            for (int i = 0; i < _pushedMessages.Count; i++)
            {
                sortedMessages = sortedMessages.OrderBy(m => m.DateTime).ToList();
                messagesByPhone = sortedMessages.FindAll(m => m.Phone == _pushedMessages[i].Phone)
                    .OrderBy(s => s.DateTime).ToList();
                messagesByPhoneAndPriority = sortedMessages
                    .FindAll(m => m.Phone == _pushedMessages[i].Phone && m.Priority == 1).OrderBy(s => s.DateTime)
                    .ToList();

                var newDate = new DateTime();
                if (sortedMessages.Count > 0)
                {
                    if (_pushedMessages[i].Priority == 0)
                    {
                        if (messagesByPhone.Count > 0)
                        {
                            if (_pushedMessages[i].DateTime -
                                messagesByPhone[messagesByPhone.Count - 1].DateTime <
                                TimeSpan.FromMinutes(1))
                            {
                                newDate = new DateTime(_pushedMessages[i].DateTime.Year, _pushedMessages[i].DateTime.Month, _pushedMessages[i].DateTime.Day, messagesByPhone[messagesByPhone.Count - 1].DateTime.Hour, messagesByPhone[messagesByPhone.Count - 1].DateTime.Minute, messagesByPhone[messagesByPhone.Count - 1].DateTime.Second).AddMinutes(1);
                                sortedMessages.Add(_pushedMessages[i]);
                                sortedMessages[i].DateTime = newDate;
                                result.Add(_pushedMessages[i].EventMessageToAntibanResult(newDate));
                            }
                            else
                            {
                                if (_pushedMessages[i].DateTime - sortedMessages[sortedMessages.Count - 1].DateTime <
                                    TimeSpan.FromSeconds(10))
                                {
                                    newDate = new DateTime(_pushedMessages[i].DateTime.Year, _pushedMessages[i].DateTime.Month, _pushedMessages[i].DateTime.Day, messagesByPhone[messagesByPhone.Count - 1].DateTime.Hour, messagesByPhone[messagesByPhone.Count - 1].DateTime.Minute, messagesByPhone[messagesByPhone.Count - 1].DateTime.Second).AddSeconds(10);
                                    sortedMessages.Add(_pushedMessages[i]);
                                    sortedMessages[i].DateTime = newDate;
                                    result.Add(_pushedMessages[i].EventMessageToAntibanResult(newDate));
                                }
                                else
                                {
                                    sortedMessages.Add(_pushedMessages[i]);
                                    result.Add(_pushedMessages[i].EventMessageToAntibanResult());
                                }
                            }
                        }
                        else
                        {
                            if (_pushedMessages[i].DateTime - sortedMessages[sortedMessages.Count - 1].DateTime <
                                TimeSpan.FromSeconds(10))
                            {
                                newDate = new DateTime(_pushedMessages[i].DateTime.Year, _pushedMessages[i].DateTime.Month, _pushedMessages[i].DateTime.Day, messagesByPhone[messagesByPhone.Count - 1].DateTime.Hour, messagesByPhone[messagesByPhone.Count - 1].DateTime.Minute, messagesByPhone[messagesByPhone.Count - 1].DateTime.Second).AddSeconds(10);
                                sortedMessages.Add(_pushedMessages[i]);
                                sortedMessages[i].DateTime = newDate;
                                result.Add(_pushedMessages[i].EventMessageToAntibanResult(newDate));
                            }
                            else
                            {
                                sortedMessages.Add(_pushedMessages[i]);
                                result.Add(_pushedMessages[i].EventMessageToAntibanResult());
                            }
                        }
                    }
                    else
                    {
                        if (messagesByPhoneAndPriority.Count > 0)
                        {
                            if (_pushedMessages[i].DateTime -
                            messagesByPhoneAndPriority[messagesByPhoneAndPriority.Count - 1].DateTime <
                            TimeSpan.FromDays(1))
                            {
                                newDate = new DateTime(_pushedMessages[i].DateTime.Year, _pushedMessages[i].DateTime.Month, _pushedMessages[i].DateTime.Day, messagesByPhone[messagesByPhone.Count - 1].DateTime.Hour, messagesByPhone[messagesByPhone.Count - 1].DateTime.Minute, messagesByPhone[messagesByPhone.Count - 1].DateTime.Second).AddDays(1);
                                sortedMessages.Add(_pushedMessages[i]);
                                sortedMessages[i].DateTime = newDate;
                                result.Add(_pushedMessages[i].EventMessageToAntibanResult(newDate));
                            }
                            else
                            {
                                if (_pushedMessages[i].DateTime -
                                    messagesByPhone[messagesByPhone.Count - 1].DateTime <
                                    TimeSpan.FromMinutes(1))
                                {
                                    newDate = new DateTime(_pushedMessages[i].DateTime.Year, _pushedMessages[i].DateTime.Month, _pushedMessages[i].DateTime.Day, messagesByPhone[messagesByPhone.Count - 1].DateTime.Hour, messagesByPhone[messagesByPhone.Count - 1].DateTime.Minute, messagesByPhone[messagesByPhone.Count - 1].DateTime.Second).AddMinutes(1);
                                    sortedMessages.Add(_pushedMessages[i]);
                                    sortedMessages[i].DateTime = newDate;
                                    result.Add(_pushedMessages[i].EventMessageToAntibanResult(newDate));
                                }
                                else
                                {
                                    if (_pushedMessages[i].DateTime - sortedMessages[sortedMessages.Count - 1].DateTime <
                                        TimeSpan.FromSeconds(10))
                                    {
                                        newDate = new DateTime(_pushedMessages[i].DateTime.Year, _pushedMessages[i].DateTime.Month, _pushedMessages[i].DateTime.Day, messagesByPhone[messagesByPhone.Count - 1].DateTime.Hour, messagesByPhone[messagesByPhone.Count - 1].DateTime.Minute, messagesByPhone[messagesByPhone.Count - 1].DateTime.Second).AddSeconds(10);
                                        sortedMessages.Add(_pushedMessages[i]);
                                        sortedMessages[i].DateTime = newDate;
                                        result.Add(_pushedMessages[i].EventMessageToAntibanResult(newDate));
                                    }
                                    else
                                    {
                                        sortedMessages.Add(_pushedMessages[i]);
                                        result.Add(_pushedMessages[i].EventMessageToAntibanResult());
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (_pushedMessages[i].DateTime -
                                messagesByPhone[messagesByPhone.Count - 1].DateTime <
                                TimeSpan.FromMinutes(1))
                            {
                                newDate = new DateTime(_pushedMessages[i].DateTime.Year, _pushedMessages[i].DateTime.Month, _pushedMessages[i].DateTime.Day, messagesByPhone[messagesByPhone.Count - 1].DateTime.Hour, messagesByPhone[messagesByPhone.Count - 1].DateTime.Minute, messagesByPhone[messagesByPhone.Count - 1].DateTime.Second).AddMinutes(1);
                                sortedMessages.Add(_pushedMessages[i]);
                                sortedMessages[i].DateTime = newDate;
                                result.Add(_pushedMessages[i].EventMessageToAntibanResult(newDate));
                            }
                            else
                            {
                                if (_pushedMessages[i].DateTime - sortedMessages[sortedMessages.Count - 1].DateTime <
                                    TimeSpan.FromSeconds(10))
                                {
                                    newDate = new DateTime(_pushedMessages[i].DateTime.Year, _pushedMessages[i].DateTime.Month, _pushedMessages[i].DateTime.Day, messagesByPhone[messagesByPhone.Count - 1].DateTime.Hour, messagesByPhone[messagesByPhone.Count - 1].DateTime.Minute, messagesByPhone[messagesByPhone.Count - 1].DateTime.Second).AddSeconds(10);
                                    sortedMessages.Add(_pushedMessages[i]);
                                    sortedMessages[i].DateTime = newDate;
                                    result.Add(_pushedMessages[i].EventMessageToAntibanResult(newDate));
                                }
                                else
                                {
                                    sortedMessages.Add(_pushedMessages[i]);
                                    result.Add(_pushedMessages[i].EventMessageToAntibanResult());
                                }
                            }
                        }
                    }
                }
                else
                {
                    sortedMessages.Add(_pushedMessages[i]);
                    result.Add(_pushedMessages[i].EventMessageToAntibanResult());
                }
            }
            return result.OrderBy(r => r.SentDateTime).ToList();
        }
    }
}
