using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;
using BitMexAPI.Json;
using BitMexAPI.Messages;
using ServiceStack.Text;

namespace BitMexAPI.Responses.Instruments
{
    public class InstrumentResponse : ResponseBase
    {
        public override MessageType Op => MessageType.Instrument;

        public Instrument[] Data { get; set; }

        internal static bool TryHandle(JsonObject response, ISubject<InstrumentResponse> subject)
        {
            if (response?["table"]?.ToString() != "instrument")
                return false;

            var parsed = BitmexJsonSerializer.Handle<InstrumentResponse>(response);
            subject.OnNext(parsed);

            return true;
        }
    }
}
